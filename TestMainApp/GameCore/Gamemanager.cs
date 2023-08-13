using System.Collections.Generic;

namespace TestMainApp.GameCore
{
    class Gamemanager
    {
        List<GameObject> gameObjects;
        public void Start()
        {

        }
        public void Update()
        {
            foreach (var item in animateds)
                item.UpdateAnimation();
        }
        static List<IAnimated> animateds = new List<IAnimated>(); 
        public static void Register(object Registrable)
        {
            if (Registrable is IAnimated) animateds.Add(Registrable as IAnimated);
        }
    }
}
