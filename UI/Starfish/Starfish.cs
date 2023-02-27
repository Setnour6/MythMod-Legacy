using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
//using System.Drawing;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.Liquid;
using Terraria.Graphics;

namespace MythMod.UI.Starfish
{
    public class Starfish : UIState
    {
        private bool living = true;
        public static bool Open = false;
        private StarfishMain StarfishMain = new StarfishMain();
        public override void OnInitialize()
        {
            StarfishMain = new StarfishMain();
            StarfishMain.Width.Set(422, 0);
            StarfishMain.Height.Set(424, 0);
            StarfishMain.Left.Set(Main.screenWidth * 0.5f - 315, 0);
            StarfishMain.Top.Set(Main.screenHeight * 0.5f - 318, 0);

            Append(StarfishMain);
        }
        Vector2 offset;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Player player = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx2 = innerDimensions.X;
            float shopy2 = innerDimensions.Y;
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
        }
    }
    public class StarfishMain : UIElement
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();

            spriteBatch.Draw(mod.GetTexture("UIImages/吸在屏幕上的海星"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
