using System;

namespace DecRom
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int dec = 0;
            string number = "";
            Console.WriteLine("Decimal to Roman");
            Console.WriteLine("Type the number:");
            number =Console.ReadLine();
            dec = Convert.ToInt32(number);
            number = DecimalToRoman(dec);
            Console.WriteLine("The number in Romand is:"+number);

        }
        public static string DecimalToRoman(int i)
        {
            string roman = "";
            int j = i;
            int d=0;

            while (j > 0)
            {
                if (j < 5)
                {
                    if (j >= (5 - 1))
                    {
                        roman = roman+"IV";
                        j = j - (5 - 1);
                    }
                    else 
                    {
                        roman = roman + "I";
                        j = j - 1;
                        d = j / (1);
                        for(int k=1;k<d;k++)
                        {
                            roman = roman + "I";
                            j = j - 1;
                        }
                    }
                    

                }
                else if (j < 10)
                {
                    if (j >= (10 - 1))
                    {
                        roman = roman + "IX";
                        j = j - (10 - 1);
                    }
                    else
                    {
                        roman = roman + "V";
                        j = j -5;
                       // d = j / (1);
                       // for (int k = 1; k < d; k++)
                       // {
                       //     roman = roman + "I";
                       //     j = j - 1;
                       // }
                    }
                }
                else if(j<50)
                {
                    if (j >= (50- 10))
                    {
                        roman = roman + "XL";
                        j = j - (50 - 10);
                    }
                    else
                    {
                        roman = roman + "X";
                        j = j - 10;
                        // d = j / (1);
                        // for (int k = 1; k < d; k++)
                        // {
                        //     roman = roman + "I";
                        //     j = j - 1;
                        // }
                    }
                }
                else if(j<100)
                {
                    if (j >= (100 - 10))
                    {
                        roman = roman + "XC";
                        j = j - (100 - 10);
                    }
                    else
                    {
                        roman = roman + "L";
                        j = j - 50;
                        // d = j / (1);
                        // for (int k = 1; k < d; k++)
                        // {
                        //     roman = roman + "I";
                        //     j = j - 1;
                        // }
                    }
                }
                else if(j<500)
                {
                    if (j >= (500 - 100))
                    {
                        roman = roman + "CD";
                        j = j - (500 - 100);
                    }
                    else
                    {
                        roman = roman + "C";
                        j = j - 100;
                        // d = j / (1);
                        // for (int k = 1; k < d; k++)
                        // {
                        //     roman = roman + "I";
                        //     j = j - 1;
                        // }
                    }
                }
                else if(j<1000)
                {
                    if (j >= (1000 - 100))
                    {
                        roman = roman + "CM";
                        j = j - (1000 - 100);
                    }
                    else
                    {
                        roman = roman + "D";
                        j = j - 500;
                        // d = j / (1);
                        // for (int k = 1; k < d; k++)
                        // {
                        //     roman = roman + "I";
                        //     j = j - 1;
                        // }
                    }
                }
                else if (j<5000)
                {
                    if (j >= (5000 - 1000))
                    {
                        roman = roman + "MMMM";
                        j = j - (5000 - 1000);
                    }
                    else
                    {
                        roman = roman + "M";
                        j = j - 1000;
                        // d = j / (1);
                        // for (int k = 1; k < d; k++)
                        // {
                        //     roman = roman + "I";
                        //     j = j - 1;
                        // }
                    }
                }
                else
                {
                    roman = "Can't convert number!!!";
                }
            }
            return roman;
        }
    }
}
