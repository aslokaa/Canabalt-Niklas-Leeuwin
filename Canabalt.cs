using Centipede.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede
{
    public class Canabalt : GameEnvironment
    {

        static PlayingState playingState;
        static GameOver gameOver;
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1280, 720);
            playingState = new PlayingState();
            gameOver = new GameOver();
            ApplyResolutionSettings();
            gameStateManager.AddGameState("TitleScreen",new TitleScreen());
            gameStateManager.AddGameState("PlayingState", playingState);
            gameStateManager.AddGameState("GameOver", gameOver);
            gameStateManager.SwitchTo("TitleScreen");
        }
        
        public static void Reset()
        {
            playingState.Reset();
        }
    }
}
