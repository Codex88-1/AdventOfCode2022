using System;
using System.IO;
using Xunit;

namespace AdventOfCode2022
{
    public class TempTests
    {

        [Fact]
        public void CalenderDay2()
        {
            int totalScore = 0;
            int totalScore2 = 0;
            foreach (string line in File.ReadLines("data\\input2.txt"))
            {
                var opponentMove = GetMove(line[0]);
                var yourMove = GetMove(line[2]);
                var yourMove2 = GetYourMove(opponentMove, line[2]);
                totalScore = totalScore + GetRoundScore(opponentMove, yourMove);
                totalScore2 = totalScore2 + GetRoundScore(opponentMove, yourMove2);
            }

            var answer = totalScore;
            var answer2 = totalScore2;
        }

        private enum Move { Rock, Paper, Scissor}

        private Move GetMove(char playerMove)
        {
            if (playerMove == 'X' || playerMove == 'A')
                return Move.Rock;
            if (playerMove == 'Y' || playerMove == 'B')
                return Move.Paper;
            return Move.Scissor;
        }

        private int GetRoundScore(Move opponentMove, Move yourMove)
        {
            if (yourMove == Move.Rock)
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        return 4;
                    case Move.Paper:
                        return 1;
                    case Move.Scissor:
                        return 7;
                }
            }
            if (yourMove == Move.Paper)
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        return 8;
                    case Move.Paper:
                        return 5;
                    case Move.Scissor:
                        return 2;
                }
            }
            if (yourMove == Move.Scissor)
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        return 3;
                    case Move.Paper:
                        return 9;
                    case Move.Scissor:
                        return 6;
                }
            }
            throw new NullReferenceException("GetRoundScore: Da Fuck happened here?!?");
        }

        private Move GetYourMove(Move opponentMove, char outcome)
        {
            if (opponentMove == Move.Rock)
            {
                switch (outcome)
                {
                    case 'X': //lose
                        return Move.Scissor;
                    case 'Y': //Draw
                        return Move.Rock;
                    case 'Z': //Win
                        return Move.Paper;
                }
            }
            if (opponentMove == Move.Paper)
            {
                switch (outcome)
                {
                    case 'X': //lose
                        return Move.Rock;
                    case 'Y': //Draw
                        return Move.Paper;
                    case 'Z': //Win
                        return Move.Scissor;
                }
            }
            if (opponentMove == Move.Scissor)
            {
                switch (outcome)
                {
                    case 'X': //lose
                        return Move.Paper;
                    case 'Y': //Draw
                        return Move.Scissor;
                    case 'Z': //Win
                        return Move.Rock;
                }
            }
            throw new NullReferenceException("GetYourMove: Da Fuck happened here?!?");

        }
    }
}
