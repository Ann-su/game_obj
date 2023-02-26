using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class GameManager 
    {
        public static int framerate = 20;  
        public static bool isRunning = true;
        private static int activeSceneID = 0;
        MenuScene menuScene = new MenuScene();
        SelectTankScene selectTankScene = new SelectTankScene();
        SelectDecoratorScene selectDecoratorScene = new SelectDecoratorScene();
        GameOverScene gameOverScene = new GameOverScene();

        private static Key[] keys = new Key[5] { Key.W, Key.A, Key.S, Key.D, Key.Space };
        private static bool[] pressedKeys = new bool[5] { false, false, false, false, false };
        public static int ActiveSceneId
        {
            get { return activeSceneID; }
            set { if (value >= 0) activeSceneID = value; }
        }

        public void Start()
        {
            menuScene.Start();
            Thread thread1 = new Thread(GameLoop);
            thread1.SetApartmentState(ApartmentState.STA);
            thread1.Start();
        }

        void GameLoop()
        {
            double time1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (isRunning)
            {
                // update keys
                for (int i = 0; i < 5; i++)
                {
                    if (Keyboard.IsKeyDown(keys[i]))
                    {
                        // key down

                        if (!pressedKeys[i])  //moment wciśnięcia
                        {
                            // key pressed
                            pressedKeys[i] = true;
                            if (ActiveSceneId == MenuScene.SceneID) menuScene.KeyPressed(keys[i]);
                            else if (ActiveSceneId == SelectTankScene.SceneID) selectTankScene.KeyPressed(keys[i]);
                            else if (ActiveSceneId == SelectDecoratorScene.SceneID) selectDecoratorScene.KeyPressed(keys[i]);
                            else if (ActiveSceneId == GameOverScene.sceneID) gameOverScene.KeyPressed(keys[i]);
                        }
                    }

                    else pressedKeys[i] = false;
                }

                while (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond < time1) Thread.Sleep(1);
                time1 += 1000.0 / framerate;
            }
        }
    }
}
