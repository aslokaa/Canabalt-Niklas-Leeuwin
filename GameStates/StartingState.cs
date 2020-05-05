using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Centipede.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Centipede.GameStates
{
    class TitleScreen : UnplayableState
    {
        Hero hero = new Hero("waluigi");

        //different skins
        static public string[] waluigis = new string[]{
            "waluigi", "fat waluigi", "spr_kdanky_dang",
            "spr_pinky", "PacMan2", "Ghost2",
            "sprite_player","snake","sprite",
            "sonic"};
        static int characterIndex;

        static public int CharacterIndex { get => characterIndex; set => characterIndex = value; }

        public TitleScreen()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Reset();
            TextGameObject title = new TextGameObject("GameFont");
            title.Text = "WaluBalt\nPress D to change Characters";
            title.Color = Color.Purple;
            title.Position = new Vector2(Canabalt.Screen.X / 3, Canabalt.Screen.Y / 2);
            this.Add(hero, title);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            hero.Reset();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.D))
            {
                if (CharacterIndex + 1 == waluigis.Length)
                {
                    CharacterIndex = 0;
                }
                else
                {
                    CharacterIndex++;
                }
                hero = new Hero(waluigis[CharacterIndex]);
                this.Add(hero);
            }
        }
    }
}
