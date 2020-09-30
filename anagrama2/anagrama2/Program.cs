using System;

namespace anagrama2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string palabra;
            palabra = "perfecto";

            //rotaCaracter(palabra);
             anagrama(palabra);

            //Console.WriteLine( incNum("000",3));
        }


        public static string incNum(string val,int nume)
        {
            int valAux = 0;
            string valorString;//= new string[nume];
            valorString = val;
            int i = valorString.Length-1;
            bool sw = true;
            do//for (int i = valorString.Length; i >=0; i--)
            {
                valAux = Convert.ToInt32(new string(valorString[i],1));
                valAux = valAux + 1;
                valorString=valorString.Remove(i, 1);
                valorString= valorString.Insert(i, valAux.ToString());
                if (valAux == nume)
                {
                    valAux = 0;//valAux - 1;
                    //valorString[i] = 'a';// Convert.ToChar(valAux);
                    valorString =valorString.Remove(i, 1).Insert(i, valAux.ToString());
                    i = i - 1;
                    sw = true;
                }
                else
                    sw = false;

            } while (i>= 0 && sw);
            return valorString;

        }

        public static void anagrama(string palabra) {

            string frase = palabra;
            string auxiliar=frase;
            int[] vec = new int[frase.Length];
            bool sw = true;
            bool sw1 = false;
            string test=null;
            for (int m = 0; m < frase.Length; m++)
            {
                vec[m] = 0;//frase.Length;
                test = test + "0";
            }
     
            while ( sw1==false) 
            {
              

                for (int k = 0; k < frase.Length; k++)
                {
                    if (vec[k] != frase.Length - 1)
                    {
                        sw1 = false;
                        break;
                    }
                    else
                        sw1 = true;
                }


                        for (int n = 0; n < frase.Length; n++)
                        {
                            int a = vec[n];
                            for (int o = 0; o < frase.Length; o++)
                            {

                                if (vec[n] == vec[o] && n!=o)
                                {
                                    sw = false;
                                    break;
                                }

                            }
                        }


                        if (sw)//vec[1] != vec[2] && vec[0] != vec[1] && vec[2] != vec[0])
                        {
                            for (int p = 0; p < frase.Length; p++)
                            {
                                Console.Write(frase[vec[p]]);
                            }
                            Console.WriteLine();

                        }

                test = incNum(test, frase.Length);
                for (int j = 0; j < frase.Length; j++)
                {
                    vec[j] = (int)char.GetNumericValue(test[j]);
                }

                sw = true;
                    }
                    
        


                

            


        }
    }
}
