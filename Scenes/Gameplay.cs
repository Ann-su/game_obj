using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class Gameplay :Scene
    {
        protected Random rnd = new Random();
        public int tanksNum = SelectDecoratorScene.tankList.Count;
        public List<Tank> enemyTanks = new List<Tank>();
        protected int[,] CreateBoard(int boardSize, bool forComputer)
        {
            int BOARD_SIZE = boardSize;
            int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
            Random rnd = new Random();
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++) board[i, j] = -1;
            }
            if (forComputer)
            {
                for (int i = 0; i < 3; i++)
                {
                    int x = rnd.Next(0, BOARD_SIZE);
                    int y = rnd.Next(0, BOARD_SIZE);
                    enemyTanks.Add(new Tank());
                    enemyTanks[i].X = x;
                    enemyTanks[i].Y = y;
                    board[x, y] = enemyTanks[i].HP;
                }
            }
            return board;
        }
        protected int GetTankNum()
        {
            bool correct = true;
            int input = 0;
            while (correct)
            {
                input = (int)Console.ReadKey(true).Key - 48;
                if (input >= 0 && input < SelectDecoratorScene.tankList.Count) correct = false;
            }
            return input;
        }
        protected int[] GetUserInput()
        {
            int BOARD_SIZE = 5;
            int x = 0;
            int y = 0;
            bool correct = true;

            while (correct)
            {
                Console.Write("     ");
                int input = (int)Console.ReadKey(true).Key;
                x = y;
                y = input;
                if ((x >= 'a' && x < 'a' + BOARD_SIZE || x >= 'A' && x < 'A' + BOARD_SIZE) && y >= '0' && y < '0' + BOARD_SIZE) correct = false;
            }
            if (y >= '0' && y < '0' + BOARD_SIZE) y -= '0';
            if (x >= 'A' && x < 'A' + BOARD_SIZE) x -= 'A';
            else if (x >= 'a' && x < 'a' + BOARD_SIZE) x -= 'a';

            int[] coordinates = { x, y };
            return coordinates;
        }

        protected void PrintBoard(int[,] board, int x, int y)
        {

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[j, i] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        protected int[] ComputerMove(int boardSize)
        {
            int x = rnd.Next(0, boardSize);
            int y = rnd.Next(0, boardSize);
            int[] coordinates = { x, y };
            return coordinates;
        }

        protected bool IfContains(int[,] board)
        {
            for (int i = 0; i < BattleScene.BOARD_SIZE; i++)
            {
                for (int j = 0; j < BattleScene.BOARD_SIZE; j++)
                {
                    if (board[i, j] != 0 && board[i, j] != -1) return true;
                }
            }
            return false;
        }
        protected int CheckIfHit(int[,] attackedBoard, int[] attackingBoard, int choice, List<Tank> attackedList, List<Tank> attackingList, int num)
        {
            if (attackedBoard[attackingBoard[0], attackingBoard[1]] != -1 && attackedBoard[attackingBoard[0], attackingBoard[1]] != 0)
            {
                for (int i = 0; i < num; i++)
                {
                    if (attackedList[i].X == attackingBoard[0] && attackedList[i].Y == attackingBoard[1])
                    {
                        attackedList[i].HP -= attackingList[choice].ATK;
                        if (attackedList[i].HP <= 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return attackedList[i].HP;
                        }
                    }
                }
            }
            return -1;
        }
        protected bool CheckIfInputSameInputCoor(int[] coordiantes, List<int> list)
        {
            return !((coordiantes[0] != list[list.Count - 2]) || (coordiantes[1] != list[list.Count - 1]));
           
        }
    }
}
