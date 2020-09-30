using System;

namespace anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el numero base:");
            //Cargo el numero que queres empezar la serie 
            int baseNumber = int.Parse(Console.ReadLine());
            //Declaro un vector de una posicion mas que la pedida(para dejar un hueco al final) 
            char[] palabra = new char[baseNumber + 1];
            //Convierto cada numero menor al ingresado en un caracter en el arreglo 
            for (int i = 0; i < baseNumber; i++)
                palabra[i] = char.Parse(i.ToString());
            palabra[0] = 'r';
            palabra[1] = 'o';
            palabra[2] = 'g';
            palabra[3] = 'e';
            palabra[4] = 'r';
            //Llamo a la funcion que generara las permutaciones de ese vector sin repeticion(diciendole 0 elementos fijados) 
            GenerarPermutaciones(palabra, 0);
            Console.Read();
        }

        static void GenerarPermutaciones(char[] cadenaOriginal, int posFijas)
        {
            // variable auxiliar que uso para el intercambio 
            char auxChar;
            //Debemos en realidad ordenar un elemento menos ya que no cuenta el final del string 
            //(esto es porque si se nos va el limite del arreglo C# tira excepcion)
            //Ademas de esta manera tenemos un hueco libre en el array que es el carcater nulo para ir corriendo el resto 
            int totalCaracteres = cadenaOriginal.Length - 1;

            //Como se usa recursivamente este for con el valor max totalCaracteres-posFijas simula el "sin repeticion" 
            //Ya que al usar un elemento tengo n-1 elementos para las proximas posiciones 
            for (int i = 0; i < totalCaracteres - posFijas; i++)
            {
                //Debo fijar tantas posiciones hasta que me queden solo dos elementos a intercambiar(y el hueco nulo por eso mayor estricto) 
                if (totalCaracteres - posFijas > 2)
                    GenerarPermutaciones(cadenaOriginal, posFijas + 1);
                else
                {
                    //Genero el array como una cadena de texto y la imprimo en pantalla 
                    string cadena = "";
                    foreach (char character in cadenaOriginal)
                        cadena += character;

                    Console.Write(cadena + ", ");
                }

                //Aca es donde intercambio las posiciones, del ultimo elemento fijado, con sus siguientes 
                auxChar = cadenaOriginal[posFijas];
                cadenaOriginal[posFijas] = cadenaOriginal[posFijas + i + 1];
                cadenaOriginal[posFijas + i + 1] = auxChar;
                if (posFijas + i == totalCaracteres - 1)
                {
                    //Corro todos los elementos desde la posFija hasta el final, un indice menos y en el ultimo vuelvo a dejar el hueco 
                    for (int j = posFijas; j < totalCaracteres; j++)
                        cadenaOriginal[j] = cadenaOriginal[j + 1];

                    cadenaOriginal[totalCaracteres] = (char)0;
                }
            }
        }
    }
}
