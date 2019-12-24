using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Position : IEquatable<Position>, ICloneable
    {
        public enum Players { White, Black };
        public List<Piece> mWhitePieces { get; set; }
        public List<Piece> mBlackPieces { get; set; }
        public Piece mLastMovePiece { get; set; }
        public Players mTurn { get; set; }
        public int mDepth { get; set; }
        public Position mPrevPos;

        public static Players getOpsColor(Players color)
        {
            return color.Equals(Players.White) ? Players.Black : Players.White;
        }

        public Position()
        {
            mWhitePieces = new List<Piece>();
            mBlackPieces = new List<Piece>();
            mLastMovePiece = null;
            mTurn = Players.White;
            mDepth = 0;
            mPrevPos = null;
        }

        public Position(List<Piece> whitePieces, List<Piece> blackPieces, Piece lastMovePiece, Players turn, int depth, Position prevPos)
        {
            mWhitePieces = whitePieces;
            mBlackPieces = blackPieces;
            mLastMovePiece = lastMovePiece;
            mTurn = turn;
            mDepth = depth;
            mPrevPos = prevPos;
        }

        public Position(Position position)
        {
            
        }
        
        public Piece getPieceBySquare(Square square)
        {
            foreach (Piece p in this.mWhitePieces)
            {
                if (p._square.Equals(square))
                    return p;
            }
            foreach (Piece p in this.mBlackPieces)
            {
                if (p._square.Equals(square))
                    return p;
            }
            return null;
        }

        //<summary>
        // this function check if the position pos is checkmate position to the color mTurn.
        //true if mTurn lost the game.
        //</summary>
        public bool isCheckMate()
        {
            if (this.isCheck() == null)
                return false;
            List<Position> lp = this.getAllNextLegalPositions();
            if (lp.Count == 0)
                return true;
            return false;
            //old code
            //List<Piece> defender;
            //if (mTurn.Equals(Players.White))
            //{
            //    defender = this.mWhitePieces;                
            //}
            //else
            //{
            //    defender = this.mBlackPieces;                
            //}
            //List<Square> defendKingPossMoves = new List<Square>();
            ////find the defender king square
            //Square kingSquare = null;
            //foreach (Piece p in defender)
            //{
            //    if (p is King)
            //    {
            //        defendKingPossMoves = p.calcPossibleMoves(this);
            //        kingSquare = p._square;
            //        break;
            //    }
            //}

            //List<Position> positions = new List<Position>();
            //foreach (Square sq in defendKingPossMoves)
            //{
            //    Move mv = new Move(kingSquare, sq);
            //    List<Position> ps = this.GetNextPositionsByMove(mv);
            //    positions.AddRange(ps);
            //}

            //foreach (Position pos in positions)
            //{
            //    if (pos.isCheck() == null)
            //        return false;
            //}

            //return true;

            //very old code
            //List<Square> attackerPosMoves = new List<Square>();
            //foreach (Piece p in attacker)
            //{
            //    attackerPosMoves.AddRange(p.calcPossibleMoves(this));
            //}
            //foreach (Square s in defendKingPossMoves)
            //{
            //    if (!attackerPosMoves.Contains(s))
            //        return false;//defender king has square to run
            //}
            ////check if defender can kill the threaten piece
            //foreach (Piece p in defender)
            //{
            //    List<Square> pPosMoves = p.calcPossibleMoves(this);
            //    if (pPosMoves.Contains(pieceAttacker._square))//we found piece that can kill the attacker piece
            //    {
            //        Position[] nextPos = this.nextPosition(new Move(p._square, pieceAttacker._square));
            //        if (nextPos[0].isCheck() == null)//we have to check that killing the attacker doesn't cause another check
            //            return false;
            //    }
            //}
            //return true;
        }

        ///<summary>
        ///this function check if the position pos is check position to the color mTurn.
        /// return the attacker piece if true, otherwise null
        ///</summary>
        public Piece isCheck()
        {
            List<Piece> attacker;
            List<Piece> defender;
            Square kingSquare = new Square();
            if (mTurn.Equals(Players.White))
            {
                defender = this.mWhitePieces;
                attacker = this.mBlackPieces;
            }
            else
            {
                defender = this.mBlackPieces;
                attacker = this.mWhitePieces;
            }
            foreach (Piece p in defender)
            {
                if (p is King)
                {
                    kingSquare = p._square;
                    break;
                }
            }

            foreach (Piece p in attacker)
            {
                List<Square> possMoves = p.calcPossibleMoves(this);
                if (possMoves.Contains(kingSquare))
                    return p;
            }

            return null;
        }

        /// <summary>
        /// get the next position of this position with the move move
        /// return list of next positions if exist, null if:
        /// 1. no piece of mTurn in move._source.
        /// 2. there is piece of same color in move._dest
        /// 
        /// This function not return positions that are check to the side that moved, cause it's not legal
        /// 
        /// In most cases there is only one possible next move, 
        /// the unusual case is when a pawn arrive to the last rank and it can be any piece
        /// </summary>
        public List<Position> GetNextPositionsByMove(Move move)
        {
            //create new Position, same as this (clone)
            Piece pieceMoveOldPos = this.getPieceBySquare(move._source);
            if (pieceMoveOldPos == null || !pieceMoveOldPos._color.Equals(mTurn))//there is no piece in the color that own the turn in this square
                return null;
            Piece pieceCapturedOldPos = this.getPieceBySquare(move._dest);
            if (pieceCapturedOldPos != null && pieceCapturedOldPos._color.Equals(mTurn))    //there is piece of the same color in the dest square
            {
                return null;
            }
            Position retPos0 = (Position)this.Clone();            
                           
            Piece pieceMoving = retPos0.getPieceBySquare(move._source);
            pieceMoving._lastMove = new Move(move);
            retPos0.mLastMovePiece = pieceMoving;
            retPos0.mDepth++;
            retPos0.mPrevPos = this;            

            if (pieceCapturedOldPos != null)
            {
                retPos0.removePieceFromBoard(retPos0.getPieceBySquare(move._dest));
            }

            List<Position> retAllPos = new List<Position>(1);

            //if the piece is a pawn that rich to last rank, return all options
            if (pieceMoving is Pawn && (move._dest._rank == 8 || move._dest._rank == 1))
            {
                List<Piece> ll;
                if (mTurn == Players.White)
                {
                    ll = retPos0.mWhitePieces;
                }
                else
                {
                    ll = retPos0.mBlackPieces;
                }
                ll.Remove(pieceMoving); //remove the pawn from the postion

                /****** Queen *********/
                Queen q = new Queen(move._dest, mTurn);
                q._lastMove = new Move(move);
                ll.Add(q);
                retPos0.mLastMovePiece = q;
                if (retPos0.isCheck() == null)//the new position is not check
                {
                    retPos0.mTurn = getOpsColor(mTurn);
                    retAllPos.Add((Position)retPos0.Clone());
                    retPos0.mTurn = getOpsColor(mTurn);
                }
                
                ll.Remove(q);

                /****** Rook *********/
                //turn back the color to the original, for checking the next pos
                //retPos0.mTurn = getOpsColor(retPos0.mTurn);
                Rook r = new Rook(move._dest, mTurn);
                r._lastMove = new Move(move);
                ll.Add(r);
                retPos0.mLastMovePiece = r;
                if (retPos0.isCheck() == null)//the new position is not check
                {
                    retPos0.mTurn = getOpsColor(mTurn);
                    retAllPos.Add((Position)retPos0.Clone());
                    retPos0.mTurn = getOpsColor(mTurn);
                }
                ll.Remove(r);

                /****** Bishop *********/
                //turn back the color to the original, for checking the next pos
                //retPos0.mTurn = getOpsColor(retPos0.mTurn);
                Bishop b = new Bishop(move._dest, mTurn);
                b._lastMove = new Move(move);
                ll.Add(b);
                retPos0.mLastMovePiece = b;
                if (retPos0.isCheck() == null)//the new position is not check
                {
                    retPos0.mTurn = getOpsColor(mTurn);
                    retAllPos.Add((Position)retPos0.Clone());
                    retPos0.mTurn = getOpsColor(mTurn);
                }
                ll.Remove(b);

                /****** Knight *********/
                //turn back the color to the original, for checking the next pos
                //retPos0.mTurn = getOpsColor(retPos0.mTurn);
                Knight k = new Knight(move._dest, mTurn);
                k._lastMove = new Move(move);
                ll.Add(k);
                retPos0.mLastMovePiece = k;
                if (retPos0.isCheck() == null)//the new position is not check
                {
                    retPos0.mTurn = getOpsColor(mTurn);
                    retAllPos.Add((Position)retPos0.Clone());
                    retPos0.mTurn = getOpsColor(mTurn);
                }
                ll.Remove(k);
            }
            else
            {
                pieceMoving._square = move._dest;
                if (retPos0.isCheck() == null)//the new position is not check
                {
                    retPos0.mTurn = getOpsColor(mTurn);
                    retAllPos.Add(retPos0);
                }                
            }

            return retAllPos;
        }

        private void addPieceToBoard(Piece pieceCaptured)
        {
            if (pieceCaptured._color.Equals(Position.Players.White))
                this.mWhitePieces.Add(pieceCaptured);
            else
                this.mBlackPieces.Add(pieceCaptured);
        }

        private void removePieceFromBoard(Piece pieceCaptured)
        {
            if (pieceCaptured._color.Equals(Position.Players.White))
                this.mWhitePieces.Remove(pieceCaptured);
            else
                this.mBlackPieces.Remove(pieceCaptured);
        }

        public List<Position> getAllNextLegalPositions()
        {
            List<Piece> pieceTurn;
            if (mTurn.Equals(Players.White))
            {
                pieceTurn = this.mWhitePieces;
            }
            else
            {
                pieceTurn = this.mBlackPieces;
            }
            List<Position> nextPositions = new List<Position>();//in this list will be all possible positions in one step
            foreach (Piece p in pieceTurn)
            {
                List<Square> destSquares = p.calcPossibleMoves(this);
                foreach (Square s in destSquares)
                {
                    Move move = new Move(p._square, s);
                    List<Position> newPos = this.GetNextPositionsByMove(move);
                    foreach(Position pos in newPos)                    
                    {
                        if (pos != null)
                            nextPositions.Add(pos);
                    }
                    //textBox1.Text += newPos.ToString();
                }
            }
            return nextPositions;
        }

        //public bool isLegalInitPosition()
        //{
        //    bool isWhiteKing=false;
        //    bool isBlackKing=false;
        //    foreach (Piece p in _whitePieces)
        //    {
        //        if (p is King)
        //        {
        //            if(!isWhiteKing)
        //            {
        //                isWhiteKing = true;
        //            }
        //            else
        //            {
        //                isWhiteKing = false;
        //                break;
        //            }
        //        }
        //    }

        //}
        public override string ToString()
        {
            //string str = "white: \r\n";
            string str="";
            foreach (Piece p in mWhitePieces)
                str += p.ToString() + " , ";
            //str += "\r\n black: \r\n";
            str += "\r\n";
            foreach (Piece p in mBlackPieces)
                str += p.ToString() + " , ";
            str += "\r\n";
            //str += "\r\n-------------------\r\n";
            str += "depth: " + mDepth + "\n";
            str += "last Piece Move: " + mLastMovePiece + "\n";
            return str;            
        }

        #region ICloneable Members

        public object Clone()
        {
            Position retPos = new Position(new List<Piece>(this.mWhitePieces.Count),
                  new List<Piece>(this.mBlackPieces.Count),
                  null,
                  mTurn,
                  mDepth,
                  mPrevPos);            
            foreach (Piece p in this.mWhitePieces)
                retPos.mWhitePieces.Add((Piece)p.Clone());
            foreach (Piece p in this.mBlackPieces)
                retPos.mBlackPieces.Add((Piece)p.Clone());
            if (mLastMovePiece != null)
                retPos.mLastMovePiece = retPos.getPieceBySquare(mLastMovePiece._lastMove._dest);
            else
                retPos.mLastMovePiece = null;
            return retPos;
        }

        #endregion

        #region IEquatable<Position> Members

        public bool Equals(Position other)
        {
            if (mTurn != other.mTurn)
                return false;
            if (mLastMovePiece != other.mLastMovePiece)
                return false;
            if (mWhitePieces.Count != other.mWhitePieces.Count)
                return false;
            if (mBlackPieces.Count != other.mBlackPieces.Count)
                return false;

            foreach (Piece p in mWhitePieces)
            {
                if (!other.mWhitePieces.Contains(p))
                    return false;
            }
            foreach (Piece p in mBlackPieces)
            {
                if (!other.mBlackPieces.Contains(p))
                    return false;
            }
            
            return true;
        }

        #endregion
    }
}
