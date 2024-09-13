using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Rules
    {
        public static string GetWinner(int playerMoveIndex, int computerMoveIndex, int movesCount)
        {
            int p = movesCount / 2;

            if (playerMoveIndex == computerMoveIndex)
                return "Draw!";

            if ((playerMoveIndex > computerMoveIndex && playerMoveIndex <= computerMoveIndex + p) ||
                (playerMoveIndex < computerMoveIndex && playerMoveIndex + movesCount <= computerMoveIndex + p))
            {
                return "Win!";
            }

            return "Lose!";
        }
    }
}
