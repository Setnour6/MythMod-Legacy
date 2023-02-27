using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class SolarSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("日耀剑气");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 34;
            base.projectile.height = 34;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            projectile.alpha = 255;
            base.projectile.extraUpdates = 2;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            if(projectile.alpha > 5)
            {
                projectile.alpha -= 5;
            }
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity, 4, 4, 6, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.2f;
            int num10 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity + base.projectile.velocity.RotatedBy(Math.PI / 2d), 4, 4, 6, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num10].noGravity = true;
            Main.dust[num10].velocity *= 0.2f;
            int num11 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity + base.projectile.velocity.RotatedBy(-Math.PI / 2d), 4, 4, 6, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num11].noGravity = true;
            Main.dust[num11].velocity *= 0.2f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.1f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            int k = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            Main.projectile[k].timeLeft = 30;
            if (timeLeft != 0 && timeLeft < 1050)
            {
                int uo = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 164, 0, 1, Main.myPlayer, 0f, 0f);
                Main.projectile[uo].friendly = true;
                Main.projectile[uo].hostile = false;
            }
            for (int i = 0;i < 15;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 6, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            for (int i = 0; i < 9; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 259, v.X, v.Y, 100, default(Color), 1.8f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }

            float num60 = (float)Main.rand.Next(0, 10000);
            int num80 = Main.rand.Next(-1000, 1000) / 100;
            double num90 = (double)Math.Sqrt(100 - (int)num80 * (int)num80);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num80, (float)num90)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num80, (float)num90);
            float num100 = (float)Main.rand.Next(0, 10000) / 1000f;
            float T = (float)(Main.rand.Next(0, 10000) / 5000f * Math.PI);
            for (int i = 0; i < 250; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 125f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Solar"), 0, 0, 0, default(Color), 1.8f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 0.5f;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].noGravity = true;
            }
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 20)
                {
                    Main.npc[i].StrikeNPC((int)(projectile.damage / 2f), 0, 1);
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int k = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 10)
                {
                    Main.npc[i].StrikeNPC((int)(projectile.damage / 6f), 0, 1);
                }
            }
            Main.projectile[k].timeLeft = 30;
            target.AddBuff(189, 900, false);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(17, 17), projectile.scale, SpriteEffects.None, 0f);
            for(int i =0;i < 4;i++)
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i * 3f, null, new Color(1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, (1 - 1 / 4f * (float)i) * projectile.alpha / 255f), projectile.rotation, new Vector2(17, 17), projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
