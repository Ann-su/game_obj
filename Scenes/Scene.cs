using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    abstract class Scene :IGameManager
    {
        public SceneGraphic sceneGraphic = new SceneGraphic();

        public int position = 0;
        protected virtual int Position
        {
            get { return position; }
            set { position = value; }
        }
        public virtual void KeyPressed(Key key)
        {
            if (key == Key.W) Position -= 1;
            if (key == Key.S) Position += 1;
            sceneGraphic.DrawCursor(Position);
        }
        public virtual void Start()
        {
            sceneGraphic.EraseRectangle(1, 1, 195, 48);
            sceneGraphic.DrawCursor(Position);
        }
    }
}
