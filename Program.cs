using System;
using System.Runtime.CompilerServices;

namespace Aufgaben16_12_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            ggt();
            Tannenbaum();
            PoolPuzzle();
            Console.ReadKey();
        }

        private static void ggt()
        {
            Console.WriteLine("Iterativ:");
            Console.WriteLine(ggT_Iterativ(12, 44));
            Console.WriteLine(ggT_Iterativ(14, 24));
            Console.WriteLine("Rekursiv:");
            Console.WriteLine(ggT_Rekursiv(12, 44));
            Console.WriteLine(ggT_Rekursiv(14, 24));
        }

        private static int ggT_Iterativ(int first, int second)
        {
            int big;
            int small;
            int ggt = 1;
            if (first < second)
            {
                big = second;
                small = first;
            }
            else
            {
                small = second;
                big = first;
            }

            for (int i = 1; i <= small; i++)
            {
                if (big % i != 0)
                {
                    continue;
                }

                if (small % i == 0)
                {
                    ggt = i;
                }
            }
            return ggt;
        }

        private static int ggT_Rekursiv(int first, int second)
        {
            int ggt = -1;
            if (first < second)
            {
                ggt = ggT_Rekursiv(first, second, ggt, 1);
            }
            else
            {
                ggt = ggT_Rekursiv(second, first, ggt, 1);
            }
            return ggt;
        }

        private static int ggT_Rekursiv(int small, int big, int ggt, int counter)
        {
            if (counter == small)
            {
                return ggt;
            }

            if (big % counter == 0 && small%counter == 0)
            {
                ggt = counter;
            }

            return ggT_Rekursiv(small, big, ggt, ++counter);
        }

        private static void Tannenbaum()
        {
            OhTannenbaum(5);
        }

        private static void OhTannenbaum(int leavecount)
        {
            int winWidth = (Console.WindowWidth / 2);
            string leaves = "*";
            OhTannenbaum(leavecount, leaves, winWidth);
            CenterText("| |", ++winWidth, ConsoleColor.DarkYellow);
        }
        private static void OhTannenbaum(int leavecount, string leaves, int winWidth)
        {
            if (leavecount == 1)
            {
                return;
            }

            if (leavecount != 2)
            {
                int x = winWidth + 1;
                CenterText("i"+leaves+"i", x, ConsoleColor.Green);
            }
            else
            {
                CenterText(leaves, winWidth, ConsoleColor.DarkGreen);
            }
            OhTannenbaum(--leavecount, "*"+leaves+"*", ++winWidth);
        }


        private static void CenterText(string text, int winWidth, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(String.Format("{0," + winWidth + "}", text));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PoolPuzzle()
        {
            int x = 0;
            string vers = "";
            while (x < 4)
            {
                vers = vers + "da";
                if (x < 1)
                {
                    vers = vers + " ";
                }
                vers = vers + "s";
                if (x > 1)
                {
                    vers = vers + " kind";
                    x = x + 2;
                }

                if (x == 1)
                {
                    vers = vers + "itzend ";
                }

                if (x < 1)
                {
                    vers = vers + "agt ";
                }

                x = x + 1;
            }
            Console.WriteLine(vers);
        }
    }
}
