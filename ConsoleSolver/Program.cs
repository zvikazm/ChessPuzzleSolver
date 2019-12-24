using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessPuzzleSolver;
using System.IO;

namespace ConsoleSolver
{
    class Program
    {
        public static string mTxtLog = "";
        static void Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Usage: ConsoleServer [position file name] [logLevel (optionally)]");
                return;
            }

            //SolveFenProblem(args);
            ReadPgnFile(args);

            Console.ReadLine();
        }

        public static void ReadPgnFile(string[] args)
        {
            ChessUtils ut = new ChessUtils();
            Game game = ut.ReadGameFromPgnFile(args[0]);
        }

        public static void SolveFenProblem(string[] args)
        {
            ChessUtils ut = new ChessUtils();
            Position initPos = ut.ReadPositionFromFenFile(args[0]);
            if (initPos == null)
            {
                Console.WriteLine(args[0] + ": file not found or in wrong format\n");
                Console.ReadLine();
                return;
            }
            int logLevel = 0;
            if (args.Length == 2)
            {
                try
                {
                    logLevel = int.Parse(args[1]);
                }
                catch (Exception exc) { }
            }

            Solver sol = new Solver(initPos, 2, LogToFile, logLevel);
            sol.SolveFunc();

            TextWriter txt;
            txt = new StreamWriter("SolveLog.txt");
            txt.WriteLine(mTxtLog);
            txt.Close();
            Console.WriteLine("finish");
        }

        public static bool Log(String text)
        {
            Console.WriteLine(text);
            return true;
        }

        public static bool LogToFile(String text)
        {
            mTxtLog += text;
            return true;
        }

    }   
}