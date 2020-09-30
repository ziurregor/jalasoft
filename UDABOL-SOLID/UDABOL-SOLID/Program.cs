using System;

namespace UDABOL_SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            //responsabilidad Simple
            //var peta = new CocheNoS("vw");

            //peta.guardarCocheDB(peta);


            //var jeep = new CocheS("Toyota");

            //var cocheBDD = new CocheDB();
            //cocheBDD.guardarCocheDB(jeep);
            //cocheBDD.eliminarCocheDB(jeep);


            //Open Close
            //var mini = new CocheNoOC("Toyota");

            //Console.WriteLine(mini.getMarcaCoche());

            //CocheNoOC[] arrayCoches = {
            //new CocheNoOC("Renault"),
            //new CocheNoOC("Audi"),
            //new CocheNoOC("Mercedes")
            //};

            //ImprimirPrecioMedioCoche(arrayCoches);
            ////Incorrecta


            Coche[] arrayCoches2 = {
            new Renault(),
            new Audi(),
            new Mercedes()
            };
            imprimirPrecioMedioCoche2(arrayCoches2);
            ////Correcta

            ////Liskov
            //imprimirNumAsientos(arrayCoches2);
        }

        public static void ImprimirPrecioMedioCoche(CocheNoOC[] arrayCoches)
        {
            foreach (CocheNoOC coche in arrayCoches)
            {
                if (coche.marca.Equals("Renault")) Console.WriteLine(18000);
                if (coche.marca.Equals("Audi")) Console.WriteLine(25000);
            }
        }


        public static void imprimirPrecioMedioCoche2(Coche[] arrayCoches2)
        {
            foreach (Coche coche in arrayCoches2)
            {
                Console.WriteLine(coche.PrecioMedioCoche());
            }
        }

        //Liscok

        public static void imprimirNumAsientos(Coche[] arrayCoches)
        {
            foreach (Coche coche in arrayCoches)
            {
                if (coche is Renault)
                    Console.WriteLine(coche.numAsientos());
                if (coche is Audi)
                    Console.WriteLine(coche.numAsientos());
                if (coche is Mercedes)
                    Console.WriteLine(coche.numAsientos());
            }
        }


    }
    class CocheNoS
    {
        String marca;

        public CocheNoS(String marca) { this.marca = marca; }

        public String getMarcaCoche() { return marca; }

        public void guardarCocheDB(CocheNoS coche) {
            Console.WriteLine(coche.marca);
        }

    }

    class CocheS
    {
        public 
        String marca;

        public CocheS(String marca) { this.marca = marca; }

        String getMarcaCoche() { return marca; }
    }

    class CocheDB
    {
        public void guardarCocheDB(CocheS coche) {
            Console.WriteLine("Se adiciono"+coche.marca);
        }
        public void eliminarCocheDB(CocheS coche) {
            Console.WriteLine("Se elimino" + coche.marca);
        }
    }
    //Open Close
    class CocheNoOC
    {
        public String marca;

        public CocheNoOC(String marca) { this.marca = marca; }

        public String getMarcaCoche() { return marca; }
    }


    public abstract class Coche
    {
        // ...
        public abstract int PrecioMedioCoche();
        //
        public abstract string numAsientos();
    }

    class Renault : Coche
    {
        public override string numAsientos()
        {
            return "7";
        }
        public override int PrecioMedioCoche()
        {
            return 18000;
        }
    }

    class Audi : Coche
    {
        public override string numAsientos()
        {
            return "5";
        }
            public override int PrecioMedioCoche()
        {
            return 2500;
        }
    }

    class Mercedes : Coche
    {
        public override string numAsientos(){
            return "2";
        }
        public override int PrecioMedioCoche()
        {
            return 27000;
        }
    }

    


}
