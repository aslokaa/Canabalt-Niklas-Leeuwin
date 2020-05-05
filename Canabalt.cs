﻿using Centipede.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Canabalt : GameEnvironment
    {

        static PlayingState playingState;
        static GameOver gameOver;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1280, 720);
            playingState = new PlayingState();
            gameOver = new GameOver();
            ApplyResolutionSettings();
            gameStateManager.AddGameState("TitleScreen",new TitleScreen());
            gameStateManager.AddGameState("PlayingState", playingState);
            gameStateManager.AddGameState("GameOver", gameOver);
            gameStateManager.SwitchTo("TitleScreen");
            // TODO: use this.Content to load your game content here
        }
        
        public static void Reset()
        {
            playingState.Reset();
        }
    }
}
