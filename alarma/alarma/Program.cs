namespace EventsAndDelegates
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program1
    {
        static void Main()
        {
            var palabra = new Alarma() { msg = "Mensaje de alarma" };
            var AlarmaV = new Alarmclock();//piblisher

            var ShowA = new ShowAlarm();//subscriver

            AlarmaV.AlarmaEvento += ShowA.onAlarma;



            AlarmaV.Alarm(palabra);


        }
    }

    public class ShowAlarm
    { 
     public void onAlarma(object source,EventArgs e)
        {
            Console.WriteLine("Muestra la alarma");

        }
    }
}