using Centipede.GameStates;
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
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1280, 720);
            ApplyResolutionSettings();
            gameStateManager.AddGameState("StartingState",new StartingState());
            gameStateManager.SwitchTo("StartingState");
            // TODO: use this.Content to load your game content here
        }
        
    }
}
