using System;
using System.Text;

namespace TestMainApp.GameCore
{
    abstract class GameObject
    {
        public GameObject()
        {
            Gamemanager.Register(this);
        }
        public abstract void Update();
    }
}
