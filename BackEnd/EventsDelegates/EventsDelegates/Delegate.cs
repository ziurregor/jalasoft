using System;
namespace EventsDelegates
{

        public delegate void EvenDelegate(int number);
        public class Publisher
        {
            public EvenDelegate EvenDelegate { get; set; }
            public void Publish()
            {
                for (int i = 1; i < 11; i++)
                {
                    if (i % 2 == 0)
                    {
                        EvenDelegate(i);
                    }
                }
            }
        }
        
        

}
