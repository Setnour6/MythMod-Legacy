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
namespace MythMod.Projectiles.projectile3
{
    public class CrystalSword5 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("冰晶石剑影");
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 240;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 0.5f;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
            if(projectile.timeLeft < 220)
            {
                projectile.tileCollide = false;
            }
            if (projectile.timeLeft < 52)
            {
                projectile.tileCollide = false;
                projectile.alpha += 5;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
                for (int a = 0; a < 10; a++)
                {
                    Vector2 vector = base.projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.15f, 0.05f) * 0.1f;
                }
            }
            if (timeLeft > 52)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑1"), projectile.scale);
                Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑2"), projectile.scale);
                Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑3"), projectile.scale);
                Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑4"), projectile.scale);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            int p = (255 - projectile.alpha);
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, new Color(p, p, p, 255 - p), projectile.rotation, new Vector2(110, 110), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}