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
    public class CrystalSword10 : ModProjectile
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
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.magic = true;
            projectile.alpha = 0;
            projectile.penetrate = 1;
            projectile.scale = 0.5f;
        }
        private bool initialization = true;
        private double X;
        private float Omega = 0;
        private float b;
        public override void AI()
        {
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
            if (projectile.timeLeft < 590)
            {
                projectile.tileCollide = true;
            }
            if (projectile.timeLeft < 52)
            {
                projectile.alpha += 5;
                projectile.tileCollide = false;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            for (int a = 0; a < 8; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 1.4f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            if (timeLeft > 52)
            {
                //float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑1"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑2"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑3"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑4"), projectile.scale);
            }
            for (int j = 0; j < 200; j++)
            {
                if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                {
                    Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - projectile.Center).Length(), (int)((Main.npc[j].Center.X - projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - projectile.Center.X)));
                }
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