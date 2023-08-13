using System;
using System.Collections.Generic;
using System.Text;

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
    abstract class GameObject
    {
        public GameObject()
        {
            Gamemanager.Register(this);
        }
        public abstract void Update();
    }
    class LivingEntity : GameObject, IAnimated
    {
        public override void Update()
        {

        }
        void IAnimated.UpdateAnimation()
        {
        }

        void IAnimated.DrawAnimation()
        {
        }
    }



    class Player : LivingEntity
    {
        public override void Update()
        {
            
        }
        public Player() :base()
        {

        }
    }



    interface IAnimated
    {
        void UpdateAnimation();
        void DrawAnimation();
    }
}
