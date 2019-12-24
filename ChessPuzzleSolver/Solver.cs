using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ChessPuzzleSolver
{
    public class Solver
    {
        int mMoveToMate;
        bool mStop;
        Position mInitPos;
        Func<String, bool> mLogger;
        int mLogLevel;
        string mTextLogToFile;

        public Solver(Position initPos, int moveToMate, Func<String, bool> logger, int logLevel)
        {
            mMoveToMate = moveToMate;
            mStop = false;
            mInitPos = initPos;
            mLogger = logger;
            mLogLevel = logLevel;
        }
/*

        public void SolveIn3()
        {
            List<Position> level1 = mInitPos.getAllNextLegalPositions();
            List<Position> level2;
            List<Position> level3;
            List<Position> level4;
            List<Position> level5;

            bool allBlackMovesLeadsToCheckMate = false;
            bool foundCheckMateLevelInDeepestLevel = false;
            Position solvedPos = null;


            foreach (Position posLvl1 in level1)
            {
                Log("\n--------1---------\n", 3);
                Log(posLvl1.ToString(), 2);
                //all black moves
                level2 = posLvl1.getAllNextLegalPositions();
                if (level2.Count == 0)
                {
                    Log("this is stalemate, continue\n", 3);
                    continue;
                }
                allBlackMovesLeadsToCheckMate = true;

                foreach (Position posLvl2 in level2)
                {
                    Log("\n--------2---------\n", 3);
                    Log(posLvl2.ToString(), 2);
                    //all white second moves
                    level3 = posLvl2.getAllNextLegalPositions();
                    Level3Flag = false;

                    foreach (Position posLvl3 in level3)
                    {
                        Log("\n--------3---------\n", 3);
                        Log(posLvl3.ToString(), 2);
                        //all black second move
                        level4 = posLvl3.getAllNextLegalPositions();
                        allBMLTC4 = true;
                        foreach (Position posLvl4 in level4)
                        {
                            level5 = posLvl4.getAllNextLegalPositions();
                            //all white 3rd move
                            foreach (Position posLvl5 in level5)
                            {
                                if (posLvl5.isCheckMate())
                                {
                                    foundCheckMateLevel5 = true;
                                }
                            }
                        }
                    }
                    if (!foundCheckMateLevel3)//black has move that white don't have checkmat for it, so this posLvl1 is not good
                    {
                        allBlackMovesLeadsToCheckMate = false;
                        Log("black has option to prevent checkmate\n", 2);
                        break;
                    }
                }
                if (allBlackMovesLeadsToCheckMate)
                {
                    solvedPos = posLvl1;
                    break;
                }
            }

            Log("\n\n-------------------\n\n", 0);
            if (solvedPos != null)
                Log("found checkmate\n" + solvedPos.mLastMovePiece.ToString(), 0);
            else
                Log("not found\n", 0);
            //Log("Time: " + (DateTime.Now - before).ToString() + "\n", 0);
            //Log("num of positions that were tested: " + numOfPos, 0);
        }

        */
        public void Solve()
        {            
            DateTime tmp = DateTime.Now;
            DateTime before = DateTime.Now;
            int depth = mMoveToMate * 2 - 1; // the last move is mate so it's have only half-move
            //all white first moves
            List<Position> level1 = mInitPos.getAllNextLegalPositions();
            List<Position> level2;// = new List<Position>();
            List<Position> level3;// = new List<Position>();
            bool allBlackMovesLeadsToCheckMate = false;
            bool foundCheckMateLevel3 = false;
            Position solvedPos = null;
            foreach (Position posLvl1 in level1)
            {
                Log("\n--------1---------\n", 3);
                Log(posLvl1.ToString(), 2);
                //all black moves
                level2 = posLvl1.getAllNextLegalPositions();
                if (level2.Count == 0)
                {
                    Log("this is stalemate, continue\n", 3);
                    continue;
                }
                allBlackMovesLeadsToCheckMate = true;

                foreach (Position posLvl2 in level2)
                {
                    Log("\n--------2---------\n",3);
                    Log(posLvl2.ToString(),2);
                    //all white second moves
                    level3 = posLvl2.getAllNextLegalPositions();
                    foundCheckMateLevel3 = false;

                    foreach (Position posLvl3 in level3)
                    {                        
                        if (mStop)
                            return;
                        //TimeSpan span = DateTime.Now.Subtract(tmp);
                        //if (span.Milliseconds > 100)
                        //    Log(".", 0);                        
                        //tmp = DateTime.Now;
                        
                        Log("\n--------3---------\n",3);
                        Log(posLvl3.ToString(),2);
                        numOfPosF++;
                        if (posLvl3.isCheckMate())
                        {
                            foundCheckMateLevel3 = true;
                            break;
                        }
                    }
                    if (!foundCheckMateLevel3)//black has move that white don't have checkmat for it, so this posLvl1 is not good
                    {
                        allBlackMovesLeadsToCheckMate = false;
                        Log("black has option to prevent checkmate\n",2);
                        break;
                    }
                }
                if (allBlackMovesLeadsToCheckMate)
                {
                    solvedPos = posLvl1;
                    break;
                }                
            }

            Log("\n\n-------------------\n\n",0);
            if (solvedPos != null)
                Log("found checkmate\n" + solvedPos.mLastMovePiece.ToString(),0);
            else
                Log("not found\n",0);
            Log("Time: " + (DateTime.Now - before).ToString() + "\n",0);
            Log("num of positions that were tested: " + numOfPosF, 0);           
        }

        int numOfPosF = 0;
        Position solvedPosF = null;
        bool allBlackMovesLeadsToCheckMateF = false;
        bool foundCheckMateLevel3F = false;

        public void SolveFunc()
        {        
            DateTime tmp = DateTime.Now;
            DateTime before = DateTime.Now;
            int depth = mMoveToMate;// *2 - 1; // the last move is mate so it's have only half-move
            //all white first moves
            List<Position> level1 = mInitPos.getAllNextLegalPositions();

            //Position sol = FindMate(level1, depth);

            bool found = FindMate(level1, depth);

            Log("\n\n-------------------\n\n", 0);
            //if (sol != null)
            if (found)
            {
                Log("found checkmate\n" + solvedPosF.mLastMovePiece.ToString() + "\n", 0);
            }
            else
            {
                Log("not found\n", 0);
            }
            Log("Time: " + (DateTime.Now - before).ToString() + "\n", 0);
            Log("num of positions that were tested: " + numOfPosF.ToString() + "\n", 0);

            TextWriter txt;
            txt = new StreamWriter("SolveLog.txt");
            txt.WriteLine(mTextLogToFile);
            txt.Close();
        }

        public bool FindMate(List<Position> level1, int numOfMoves)
        {
            List<Position> level2;
            
            foreach (Position posLvl1 in level1)
            {
                if (numOfMoves > 1)
                {
                    Log("\n--------1---------\n", 3);
                    Log(posLvl1.ToString(), 2);
                    //all black moves
                    level2 = posLvl1.getAllNextLegalPositions();
                    if (level2.Count == 0)
                    {
                        Log("this is stalemate, continue\n", 3);
                        continue;
                    }
                    //allBlackMovesLeadsToCheckMateF = true;

                    bool blackHasNothigToDo = f2(level2, numOfMoves);

                    if (blackHasNothigToDo/*allBlackMovesLeadsToCheckMateF*/)
                    {
                        solvedPosF = posLvl1;
                        return true;// posLvl1;                        
                        //break;
                    }
                }
                else
                {
                    if (mStop)
                        return false;
                    numOfPosF++;
                    Log("\n--------3---------\n", 3);
                    Log(posLvl1.ToString(), 2);
                    if (posLvl1.isCheckMate())
                    {
                        //foundCheckMateLevel3F = true;
                        //break;
                        return true;
                    }                
                }
                  
            }
            return false;// null;
        }

        public bool f2(List<Position> level2, int numOfMoves)
        {
            List<Position> level3;
            
            foreach (Position posLvl2 in level2)
            {
                Log("\n--------2---------\n", 3);
                Log(posLvl2.ToString(), 2);
                //all white second moves
                level3 = posLvl2.getAllNextLegalPositions();
                //foundCheckMateLevel3F = false;

                bool findMateInOne = FindMate(level3, numOfMoves - 1);

                if (!findMateInOne/*foundCheckMateLevel3F*/)//black has move that white don't have checkmat for it, so this posLvl1 is not good
                {
                    //allBlackMovesLeadsToCheckMateF = false;
                    //Log("black has option to prevent checkmate\n", 2);
                    //break;
                    return false;
                }
            }
            return true;
        }

        //find mate in one.
        // if exist mate in one, return true.
        public bool FindMateInOne(List<Position> level3)
        {            
            foreach (Position posLvl3 in level3)
            {
                if (mStop)
                    return false;
                numOfPosF++;
                Log("\n--------3---------\n", 3);
                Log(posLvl3.ToString(), 2);
                if (posLvl3.isCheckMate())
                {
                    //foundCheckMateLevel3F = true;
                    //break;
                    return true;
                }
            }
            return false;
        }

        public void Stop()
        {
            mStop = true;
        }

        private void Log(String str, int logLevel)
        {
            if (mLogger != null && logLevel <= mLogLevel)
            {
                mLogger(str);
            }
            mTextLogToFile += str;            
        }

        public void isExistCheckMate()
        {
            DateTime before = DateTime.Now;
            int depth = mMoveToMate * 2 - 1; // the last move is mate so it's have only half-move
            List<Position> posRepository = new List<Position>();
            Stack<Position> st = new Stack<Position>();
            st.Push(mInitPos);
            int i = 0;
            while (st.Count != 0)
            {
                if (mStop)
                    return;
                i++;
                Position pos = st.Pop();
                mLogger(i.ToString() + ") " + pos.ToString());
                //posRepository.Add(pos);
                if (pos.isCheckMate())
                {
                    mLogger("\n\n*******************\n");
                    mLogger("found checkmate:\n\n");
                    st.Clear();
                    do
                    {
                        st.Push(pos);
                        pos = pos.mPrevPos;
                    }
                    while (pos != null);
                    while (st.Count != 0)
                        mLogger(st.Pop().ToString() + "\n");
                    DateTime after = DateTime.Now;
                    mLogger((after - before).ToString());
                    return;
                }
                if (pos.mDepth < depth)
                {
                    foreach (Position p in pos.getAllNextLegalPositions())
                    {
                        //if (!posRepository.Contains(p))
                        st.Push(p);
                    }
                }
            }
            mLogger("\n\n*******************\n");
            mLogger("checkmate not found\n");
        }
    }
}
