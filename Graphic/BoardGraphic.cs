using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class BoardGraphic : Graphic
    {
        public void MessageBox(string str, Nullable<int> variable)
        {
            Console.SetCursorPosition(138, 12);
            Console.WriteLine("{0} {1}", str, variable);
        }
        public void DrawTankTable(List<Tank> list)
        {
            Console.SetCursorPosition(160, 4);
            Console.WriteLine("Tanks");
            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(138, 5 + 2 * i + 1);
                Console.WriteLine("{0}. HP = {1}, ATK = {2}, Bullets = {3}, ReloadRate = {4}",
                    i, SelectDecoratorScene.tankList[i].HP, SelectDecoratorScene.tankList[i].ATK, SelectDecoratorScene.tankList[i].BulletCount, SelectDecoratorScene.tankList[i].ReloadRate);
            }

        }
        public void DrawTank(string str, int size, int x, int y, int hp)
        {
            int y_coef = size / 5;
            Console.SetCursorPosition(20 + (int)(22 * x), 8 + 11 * y);
            Console.Write("          ");
            Console.SetCursorPosition(20 + (int)(22 * x), 8 + 11 * y);
            Console.Write("HP = {0}", hp);
            DrawAscii(str, 11 + (int)(22 * x), 8 + 11 * y);
        }
        public void DrawX(string str, int size, int x, int y)
        {
            int y_coef = size / 5;
            DrawAscii(str, 5 + 135 + (int)(16 * x), 22 + 8 * y);
        }
        public void DrawBoard(int size, int xPos, int yPos)
        {
            int x_coef = (int)(size / 2.5);
            int y_coef = size / 5;
            int h = yPos + y_coef;
            int w = xPos + x_coef;
            char czar = (char)65;
            int num = 4;
            int divNum = 4;

            for (int i = 0; i < size; i += y_coef)
            {
                Console.SetCursorPosition(xPos + 3 + 2 * i, yPos - 2);
                Console.Write(czar++);
            }
            for (int i = size - 2; i >= -1; i -= y_coef)
            {
                Console.SetCursorPosition(xPos - 3, i + yPos);
                Console.Write(num--);
            }
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(xPos + 2 * i, yPos);
                Console.Write("=");
            }

            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(xPos + 2 * size, i + yPos);
                Console.Write("=");
            }

            for (int i = size; i >= 0; i--)
            {
                Console.SetCursorPosition(xPos + 2 * i, size + yPos);
                Console.Write("=");
            }

            for (int i = size; i >= 0; i--)
            {
                Console.SetCursorPosition(xPos, i + yPos);
                Console.Write("=");
            }

            for (int j = 0; j < divNum; j++)
            {
                for (int i = size - 1; i >= 1; i--)
                {
                    Console.SetCursorPosition(w, i + yPos);
                    Console.Write("|");
                }
                w += x_coef;
            }

            for (int j = 0; j < divNum; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.SetCursorPosition(xPos + 2 * i, h);
                    Console.Write("-");
                }
                h += y_coef;
            }
        }
    }
}
