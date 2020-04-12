using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace RSA1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file;
            StreamReader sr;
            StreamWriter sw;
            int cases = 0;
            string m, ed, n;
            int count;
            int choice;
            long diff;
            long totalTime;
            file = new FileStream("SampleRSA.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            cases = int.Parse(sr.ReadLine());
            string[] result1 = new string[cases];
            count = 0;
            totalTime = 0;

            for (int i = 0; i < cases; i++)
            {
                n = sr.ReadLine();
                ed = sr.ReadLine();
                m = sr.ReadLine();
                choice = int.Parse(sr.ReadLine());

                Big_Integer b = new Big_Integer();
                diff = 0;

                if (choice == 0)
                {
                    long timeBefore = System.Environment.TickCount;
                    result1[count++] = b.encrypt(m, ed, n);
                    long timeAfter = System.Environment.TickCount;
                    diff = timeAfter - timeBefore;
                }

                else if (choice == 1)
                {
                    long timeBefore = System.Environment.TickCount;
                    result1[count++] = b.decrypt(m, ed, n);
                    long timeAfter = System.Environment.TickCount;
                    diff = timeAfter - timeBefore;
                }

                Console.Write("Time of test case #" + (i + 1) + " is " + diff + " ms");
                Console.WriteLine();
                totalTime += diff;

            }

            Console.Write("Total time of Sample test is " + totalTime + " ms");
            Console.WriteLine();
            Console.WriteLine();

            sr.Close();
            file.Close();

            file = new FileStream("SampleTest_Output.txt", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(file);

            for (int i = 0; i < cases; i++)
            {
                sw.Write(result1[i]);
                sw.WriteLine();
            }
            sw.Close();
            file.Close();

            if (File.Exists("SampleTest_Output.txt"))
            {
                Console.Write("SampleTest_Output file is added.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.Write("SampleTest_Output file isn't added.");
                Console.WriteLine();
                Console.WriteLine();
            }


            file = new FileStream("TestRSA.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            cases = int.Parse(sr.ReadLine());

            count = 0;
            totalTime = 0;

            for (int i = 0; i < cases; i++)
            {

                n = sr.ReadLine();
                ed = sr.ReadLine();
                m = sr.ReadLine();
                choice = int.Parse(sr.ReadLine());

                diff = 0;
                Big_Integer b = new Big_Integer();
                if (choice == 0)
                {
                    long timeBefore = System.Environment.TickCount;
                    result1[count++] = b.encrypt(m, ed, n);
                    long timeAfter = System.Environment.TickCount;
                    diff = timeAfter - timeBefore;
                }
                else if (choice == 1)
                {
                    long timeBefore = System.Environment.TickCount;
                    result1[count++] = b.decrypt(m, ed, n);
                    long timeAfter = System.Environment.TickCount;
                    diff = timeAfter - timeBefore;
                }

                Console.Write("Time of test case #" + (i + 1) + " is " + diff + " ms");
                Console.WriteLine();
                totalTime += diff;
            }
            Console.Write("Total time of Complete test is " + totalTime + " ms");
            Console.WriteLine();
            Console.WriteLine();
            sr.Close();
            file.Close();


            file = new FileStream("CompleteTest_Output.txt", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(file);

            for (int i = 0; i < cases; i++)
            {
                sw.Write(result1[i]);
                sw.WriteLine();
            }
            sw.Close();
            file.Close();

            if (File.Exists("CompleteTest_Output.txt"))
            {
                Console.Write("CompleteTest_Output file is added.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.Write("CompleteTest_Output file isn't added.");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
