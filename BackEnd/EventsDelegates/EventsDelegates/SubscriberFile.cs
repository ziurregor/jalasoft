using System;
namespace EventsDelegates
{
   
        public class SubscriberFile
        {
            public void Subscribe(ref EvenDelegate evenDelegate)
            {
                if (evenDelegate == null)
                {
                    evenDelegate = PrintIntoFile;
                }
                else
                {
                    evenDelegate += PrintIntoFile;
                }
            }
            public void PrintIntoFile(int number)
            {
                using (var fileStream = new FileStream(@"c:\demo\file.txt", FileMode.Append, FileAccess.Write))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine("The number is - {0}", number);
                    }
                }
            }
        }

}
