using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal interface IGameManager
    {
        void Start();
        void KeyPressed(Key key);
    }
}
