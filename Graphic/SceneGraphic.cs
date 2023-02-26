using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class SceneGraphic :Graphic
    {
        public void DrawMenu()
        {
            DrawAscii(AsciiAssets.Title, 6, 0);
            DrawAscii(AsciiAssets.SelectTank, 20, 15);
            DrawAscii(AsciiAssets.Exit, 20, 25);
            DrawAscii(AsciiAssets.MenuTank, 135, 30);
            DrawAscii(AsciiAssets.Use, 20, 40);
            DrawBorders(100, 50);
        }
        public void DrawSelectTank()
        {
            DrawAscii(AsciiAssets.KV1, 20, 17);
            DrawAscii(AsciiAssets.KV2, 20, 27);
            Console.SetCursorPosition(20, 48);
            Console.Write("Use WASD and Space");
            DrawAscii(AsciiAssets.KV1Description, 75, 15);
            DrawAscii(AsciiAssets.KV2Description, 75, 25);
        }
        public void DrawCursor(int Position)
        {
            EraseRectangle(5, 15, 15, 40);
            DrawAscii(AsciiAssets.Pointer, 5, Position * 10 + 15);
        }
        public void DrawDecorators()
        {
            Console.Clear();
            DrawAscii(AsciiAssets.TankBoosters, 20, 3);
            DrawAscii(AsciiAssets.HPDecorator, 20, 17);
            DrawAscii(AsciiAssets.BulletCountDecorator, 20, 27);
            DrawAscii(AsciiAssets.ATKDecorator, 20, 37);
            DrawAscii(AsciiAssets.ReloadRate, 20, 47);
            //Graphic.DrawAscii(AsciiAssets.Use, 20, 48);
        }
    }
}
