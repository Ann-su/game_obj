using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class BattleScene : Gameplay
    {
        GameOverScene gameOverScene = new GameOverScene();
        public static int sceneID = 1;
        public static int size = 55;
        public const int BOARD_SIZE = 5;
        public static int playersScore = 0;
        BoardGraphic boardGraphic = new BoardGraphic();


        public override void Start()
        {
            int posX = 10;
            int posY = 6;
            while (Console.KeyAvailable) Console.ReadKey();
            GameManager.ActiveSceneId = 1;
            Console.Clear();
            boardGraphic.DrawBoard(size, posX, posY);
            boardGraphic.DrawBoard(40, 135, 21);
            boardGraphic.DrawTankTable(SelectDecoratorScene.tankList);
            Play();
        }

        /*player's board & computer's board:
         -1 -> empty, HP -> ship, -2 ->destroyed*/
       
        public void Play()
        {
            int tanksNum = SelectDecoratorScene.tankList.Count;
            int[,] computerBoard = CreateBoard(BOARD_SIZE, true);    //creates computer's board
            int[,] playerBoard = CreateBoard(BOARD_SIZE, false);     //creates player's board
            int[,] playerComputerBoard = CreateBoard(BOARD_SIZE, false);    //creates enemy's board for player where his strikes are shown

            //-----Get player's tanks positions---------------------------------------------------------------------------------
            List<int> PlayerCoordinates = new List<int>();
            PlayerCoordinates.Add(-1);
            PlayerCoordinates.Add(-1);
            bool isSame = true;

            for (int i = 0; i < tanksNum; i++)
            {
                while(isSame)
                {
                    int[] inputCoordinates = GetUserInput();
                    isSame = CheckIfInputSameInputCoor(inputCoordinates, PlayerCoordinates);
                    boardGraphic.MessageBox("                                                 ", null);
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (isSame) boardGraphic.MessageBox("You cannot select the same tank twice", null);
                    Console.ForegroundColor = ConsoleColor.White;
                    PlayerCoordinates.Add(inputCoordinates[0]);
                    PlayerCoordinates.Add(inputCoordinates[1]);
                }
                isSame = true;
                SelectDecoratorScene.tankList[i].X = PlayerCoordinates[PlayerCoordinates.Count - 2];
                SelectDecoratorScene.tankList[i].Y = PlayerCoordinates[PlayerCoordinates.Count - 1];
                playerBoard[PlayerCoordinates[PlayerCoordinates.Count - 2], PlayerCoordinates[PlayerCoordinates.Count - 1]] = SelectDecoratorScene.tankList[i].HP;
                boardGraphic.DrawTank(SelectTankScene.ChosenTank, size, PlayerCoordinates[PlayerCoordinates.Count-2], PlayerCoordinates[PlayerCoordinates.Count - 1], SelectDecoratorScene.tankList[i].HP);
            }
            //show enemy's tank cooridinates
            //for (int i = 0; i < BOARD_SIZE; i++)
            //{
            //    for (int j = 0; j < BOARD_SIZE; j++)
            //    {
            //        if (computerBoard[i, j] != -1) Console.WriteLine("Computer coordinates: {0}{1}", (char)(i + 65), j);
            //    }
            //}
            bool isTheSame = true;
            bool isZero = true;
            List<int> choices = new List<int>();
            choices.Add(-1);
            while (IfContains(computerBoard) && IfContains(playerBoard))
            {
                //-----Player's move---------------------------------------------------------------------------------------------
                while (isTheSame || isZero)
                {
                    int choice = GetTankNum();
                    boardGraphic.MessageBox("                                                 ", null);
                    boardGraphic.MessageBox("Choice = ", choice);
                    if (choice != choices[choices.Count - 1] || (SelectDecoratorScene.tankList[choice].ReloadRate))
                    {
                        isTheSame = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        boardGraphic.MessageBox("Previous and current choice cannot be the same", null);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (SelectDecoratorScene.tankList[choice].BulletCount != 0)
                    {
                        isZero = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        boardGraphic.MessageBox("Choose another tank. Bullets = ", 0);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    choices.Add(choice);
                }
                isZero = true;
                isTheSame = true;
                int[] playerCoordinates2 = GetUserInput();
                computerBoard[playerCoordinates2[0], playerCoordinates2[1]] = CheckIfHit(computerBoard, playerCoordinates2, choices[choices.Count - 1], enemyTanks, SelectDecoratorScene.tankList, tanksNum);
                playerComputerBoard[playerCoordinates2[0], playerCoordinates2[1]] = computerBoard[playerCoordinates2[0], playerCoordinates2[1]];
                if(SelectDecoratorScene.tankList[choices[choices.Count - 1]].GetType().Name is "BulletCountDecorator") SelectDecoratorScene.tankList[choices[choices.Count - 1]].BulletCount -= 6;
                else SelectDecoratorScene.tankList[choices[choices.Count - 1]].BulletCount -= 1;
                boardGraphic.DrawTankTable(SelectDecoratorScene.tankList);
                if (computerBoard[playerCoordinates2[0], playerCoordinates2[1]] == -1)
                {
                    playersScore++;
                    boardGraphic.DrawX(AsciiAssets.O, 40, playerCoordinates2[0], playerCoordinates2[1]);
                }
                else if (computerBoard[playerCoordinates2[0], playerCoordinates2[1]] == 0)
                {
                    playersScore += 3;
                    Console.ForegroundColor = ConsoleColor.Red;
                    boardGraphic.DrawX(AsciiAssets.Skull, 40, playerCoordinates2[0], playerCoordinates2[1]);
                    Console.WriteLine("Destroyed");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    boardGraphic.DrawX(AsciiAssets.X, 40, playerCoordinates2[0], playerCoordinates2[1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //-----Computer's move-------------------------------------------------------------------------------------------
                int[] computerCoordinates = ComputerMove(BOARD_SIZE);
                int computerChoice = rnd.Next(0, tanksNum);
                playerBoard[computerCoordinates[0], computerCoordinates[1]] = CheckIfHit(playerBoard, computerCoordinates, computerChoice, SelectDecoratorScene.tankList, enemyTanks, tanksNum);
                if(playerBoard[computerCoordinates[0], computerCoordinates[1]] != -1)
                {
                    boardGraphic.DrawTank(SelectTankScene.ChosenTank, size, computerCoordinates[0], computerCoordinates[1], playerBoard[computerCoordinates[0], computerCoordinates[1]]);
                }
                playerComputerBoard[playerCoordinates2[0], playerCoordinates2[1]] = playerBoard[computerCoordinates[0], computerCoordinates[1]];
            }
            gameOverScene.Start(playersScore);
            Console.Clear();
            sceneGraphic.DrawAscii(AsciiAssets.TheEnd, 50, 20);
        }
    }
}
