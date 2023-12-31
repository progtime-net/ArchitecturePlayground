﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLibrary.UI.Elements;
using MonogameLibrary.UI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace MonogameLibrary.UI.Base
{
    public static class MonoClassManagerUI
    {
        static Dictionary<int, List<MonoDrawableUI>> layerCollection;
        public static GraphicsDevice MainGraphicsDevice { get { return _graphicsDevice; } }
        public static ContentManager MainContent { get { return _content; } }
        public static SpriteFont MainBaseFont { get { return _baseFont; } }
        static GraphicsDevice _graphicsDevice;
        static ContentManager _content;
        static SpriteFont _baseFont;
        public static void InitManager(GraphicsDevice graphicsDevice, ContentManager content, string font)
        {
            _graphicsDevice = graphicsDevice;
            _content = content;
            try
            {
                _baseFont = _content.Load<SpriteFont>(font);
            }
            catch
            {
            }
            layerCollection = new Dictionary<int, List<MonoDrawableUI>>();
            for (int i = -10; i < 11; i++)
            {
                layerCollection.Add(i, new List<MonoDrawableUI>());
            }
        }
        public static KeyboardState GetKeyboardState { get { return keyboardState; } }
        static MouseState mouseState, prevmouseState;
        static KeyboardState keyboardState;
        public static void Update(GameTime gameTime)
        {
            try
            {
                keyboardState = Keyboard.GetState();
                mouseState = Mouse.GetState();
            }
            catch
            {

            }
            bool hasInteracted = false;
            foreach (var collection in layerCollection)
            {
                foreach (var item in collection.Value)
                {
                    if (item is IInteractable)
                    {
                        if (!hasInteracted)
                        {
                            hasInteracted = (item as IInteractable).InteractUpdate(mouseState, prevmouseState);
                        }
                    }
                }
            }
            prevmouseState = mouseState;
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var collection in layerCollection)
            {
                foreach (var item in collection.Value)
                {
                    item.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
        }
        public static void Register(MonoDrawableUI monoDrawableUI, int layerIndex)
        {
            if (!layerCollection.ContainsKey(layerIndex))
                layerCollection.Add(layerIndex, new List<MonoDrawableUI>());

            layerCollection[layerIndex].Add(monoDrawableUI);
        }
    }
}
