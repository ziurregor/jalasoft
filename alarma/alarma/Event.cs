using System;
namespace alarma
{
   
    public class CustomEventArgs
    {
        public CustomEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }

}
