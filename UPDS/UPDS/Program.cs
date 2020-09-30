using System;


//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Jalasift">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Mravi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int l;
            double[,] mat;
            double[] vec;
            if (args.Length == 0)
            {
                l = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                l = Convert.ToInt32(args[0]);
            }

            mat = new double[l - 1, 4];
            vec = new double[l];

            List<string> tests = new List<string>();

            if (args.Length == 0)
            {
                for (int i = 0; i < l - 1; i++)
                {
                    string line = Console.ReadLine();
                    tests.Add(line);
                    foreach (var test in tests)
                    {
                        string[] split = test.Split(new char[] { ' ' }, StringSplitOptions.None);
                        mat[i, 0] = Convert.ToDouble(split[0]);
                        mat[i, 1] = Convert.ToDouble(split[1]);
                        mat[i, 2] = Convert.ToDouble(split[2]);
                        mat[i, 3] = Convert.ToDouble(split[3]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < l - 1; i++)
                {
                    string line = args[i + 1];

                    tests.Add(line);

                    foreach (string test in tests)
                    {
                        string[] split = test.Split(new char[] { ' ' }, StringSplitOptions.None);
                        mat[i, 0] = Convert.ToDouble(split[0]);
                        mat[i, 1] = Convert.ToDouble(split[1]);
                        mat[i, 2] = Convert.ToDouble(split[2]);
                        mat[i, 3] = Convert.ToDouble(split[3].Trim());

                    }
                    tests.Remove(line);
                }
            }

            if (args.Length == 0)
            {



                string line1 = Console.ReadLine();
                List<string> tests1 = new List<string>();
                tests1.Add(line1);
                foreach (var test1 in tests1)
                {
                    string[] split = test1.Split(new char[] { ' ' }, StringSplitOptions.None);
                    for (int k = 0; k < l; k++)
                    {
                        vec[k] = Convert.ToDouble(split[k]);
                    }

                    // vec[1] = Convert.ToInt32(split[1]);
                    // vec[2] = Convert.ToInt32(split[2]);
                    //// vec[3] = Convert.ToInt32(split[3]);
                }
            }
            else
            {
                string line1 = args[args.Length - 1];//Console.ReadLine();
                List<string> tests1 = new List<string>();
                tests1.Add(line1);
                foreach (var test1 in tests1)
                {
                    string[] split = test1.Split(new char[] { ' ' }, StringSplitOptions.None);
                    for (int k = 0; k < l; k++)
                    {
                        vec[k] = Convert.ToDouble(split[k]);
                    }


                }

            }

            int r1 = Convert.ToInt32(mat[0, 0]);
            for (int i = 0; i < l - 1; i++)
            {
                if (mat[i, 0] > r1)
                {
                    r1 = Convert.ToInt32(mat[i, 0]);
                }

            }

            int r2 = 0;
            int sw = 0;
            int el1 = 0;
            for (int i = 0; i < l - 1; i++)
            {
                if (mat[i, 0] == r1)
                {
                    if (vec[Convert.ToInt32(mat[i, 1]) - 1] > 0 && sw == 0)
                    {
                        r2 = Convert.ToInt32(vec[Convert.ToInt32(mat[i, 1]) - 1]);
                        sw = 1;
                        el1 = Convert.ToInt32(mat[i, 1]) - 1;
                    }

                    if (r2 > vec[Convert.ToInt32(mat[i, 1]) - 1] && vec[Convert.ToInt32(mat[i, 1]) - 1] > 0)
                    {
                        r2 = Convert.ToInt32(vec[Convert.ToInt32(mat[i, 1]) - 1]);
                        el1 = Convert.ToInt32(mat[i, 1]) - 1;

                    }

                }
            }

            //Console.WriteLine("r2:" + r2);

            //Console.WriteLine("El valor de Vec["+ el1+"] = " + r2);

            int l1 = l - 1;
            int el2 = el1 + 1;
            double data1 = vec[el1];
            double dr = 0;
            double[] vec1;
            vec1 = new double[l];


            for (int n = 0; n < l; n++)
            {
                if (vec[n] > 0)
                {
                    dr = EncOrigenEnL(mat, vec, l, n);
                    vec1[n] = dr;
                }
                else
                {
                    //
                    vec1[n] = -1;
                }

            }



            Console.WriteLine(vec1.Max());//data1);
        }

        public static double EncOrigenEnL(double[,] mat, double[] vec, int l, int el1)
        {
            double result = vec[el1];
            int el2 = el1 + 1;
            int l1 = l - 1;

            while (l1 > 1)
            {
                for (int i = 0; i < l - 1; i++)
                {
                    if (mat[i, 1] == el2)
                    {
                        if (mat[i, 3] == 1)
                        {
                            result = Math.Sqrt(result);
                        }
                        result = (result * 100) / mat[i, 2];
                        el2 = Convert.ToInt32(mat[i, 0]);
                        l1 = el2;
                    }

                }

            }

            return result;
        }


    }
}
