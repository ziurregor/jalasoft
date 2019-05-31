namespace EventsAndDelegates
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class Alarmclock
    {
        //1 define a delegate

        //2 define an event
        //3 raise the event
        public delegate void DelegadoAlarma(object o, EventArgs e);

        public event DelegadoAlarma AlarmaEvento;

            
        public void Alarm(Alarma msg)
        {
            Console.WriteLine("Alarma");

            //Thread.Sleep(3000);
            int i=0, j=0;
            do { 
            i = DateTime.Now.Second;
            if (i % 12 == 0  && j != i)
                {
                    j = i;
                    Console.WriteLine(DateTime.Now.Second);
                    onAlarma();
                }
            if (i % 30 == 0 && j != i)
            {
                j = i;
                Console.WriteLine(DateTime.Now.Second);
                onAlarma();
            }
            } while (DateTime.Now.Second < 59);


        }

        protected virtual void onAlarma()
        {

           // if (AlarmaEvento() != null)
                AlarmaEvento(this, EventArgs.Empty);

        }

    }
}