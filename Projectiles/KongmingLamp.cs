using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles
{
    //135596
    public class KongmingLamp : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("孔明灯");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 58;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = (int)1.5f;
            Projectile.timeLeft = 144000;
            Projectile.alpha = 30;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
        }
        //55555
        public override void AI()
        {
            int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
            if (Projectile.timeLeft >= 143930)
			{
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.045f / 255f * (float)(12 - Math.Sin(Projectile.timeLeft / 4f)) * (float)((144000 - base.Projectile.timeLeft) / 60f), (float)(255 - base.Projectile.alpha) * 0.01f / 255f * (float)(12 - Math.Sin(Projectile.timeLeft / 4f)) * (float)((144000 - base.Projectile.timeLeft) / 60f), (float)(255 - base.Projectile.alpha) * 0f / 255f * (float)(12 - Math.Sin(Projectile.timeLeft / 4f)) * (float)((144000 - base.Projectile.timeLeft) / 60f));
                if(Main.player[num5].direction == 1)
                {
                    Projectile.Center = Main.player[num5].Center + new Vector2(20, 0);
                }
                else
                {
                    Projectile.Center = Main.player[num5].Center + new Vector2(-20, 0);
                }
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.045f / 255f * (float)(12 - Math.Sin(Projectile.timeLeft / 4f)), (float)(255 - base.Projectile.alpha) * 0.01f / 255f * (float)(3 - Math.Sin(Projectile.timeLeft / 4f)), (float)(255 - base.Projectile.alpha) * 0f / 255f * (float)(3 - Math.Sin(Projectile.timeLeft / 4f)));
                Projectile.velocity.X *= 0.98f;
            }
            if (Projectile.timeLeft == 143930)
            {
                Projectile.velocity.X = Main.player[num5].velocity.X * 0.8f;
            }
            if (Projectile.timeLeft <= 143930 && Projectile.velocity.Y >= -0.35f)
			{
                Projectile.velocity.Y -= 0.0375f;
            }
            if (Projectile.timeLeft <= 143880)
            {
                Projectile.rotation += (float)Math.Sin(Projectile.timeLeft / 150f) / 750f;
            }
        }
        //14141414141414
        //14141414141414
        //14141414141414
        public override void PostDraw(Color lightColor)
        {
            int i = 1000, j = 1000;
            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)((ulong)i));
            Color color = new Color(0.15f, 0.15f, 0.15f, 0);
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            int width = 20;
            int offsetY = 0;
            int height = 20;
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            if (Projectile.timeLeft >= 143940)
            {
                for (int k = 0; k < 11; k++)
                {
                    float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.3f;
                    float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.7f;
                    Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/孔明灯Glow"), new Vector2((float)(Projectile.Center.X - (int)Main.screenPosition.X) + x, (float)(Projectile.Center.Y - (int)Main.screenPosition.Y) + y), null, color * ((144000 - Projectile.timeLeft) / 60f), Projectile.rotation, new Vector2(21f, 29f), 1f, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int k = 0; k < 11; k++)
                {
                    float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.3f;
                    float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.7f;
                    Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/孔明灯Glow"), new Vector2((float)(Projectile.Center.X - (int)Main.screenPosition.X) + x, (float)(Projectile.Center.Y - (int)Main.screenPosition.Y) + y), null, color, Projectile.rotation, new Vector2(21f, 29f), 1f, SpriteEffects.None, 0f);
                }
            }
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/KongmingLamp"), base.Projectile.Center - Main.screenPosition, null, new Color(0.3f, 0.15f, 0.15f, 0), base.Projectile.rotation, new Vector2(21f, 29f), 1f, SpriteEffects.None, 0f);
        }
    }
}