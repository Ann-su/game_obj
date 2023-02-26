using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal interface IGraphic
    {
        void DrawAscii(string str, int x, int y);
        void EraseRectangle(int x, int y, int width, int height);
        void DrawBorders(int x, int y);
    }
}
