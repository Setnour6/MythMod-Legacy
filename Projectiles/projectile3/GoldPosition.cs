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
    public class GoldPosition : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("金相");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 62;
            base.projectile.height = 62;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
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
            int num10 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity + base.projectile.velocity.RotatedBy(Math.PI / 2d) * 0.2f * Math.Abs(12 - (projectile.timeLeft % 24)), 4, 4, 64, 0f, 0f, 100, default(Color), 1.7f);
            Main.dust[num10].noGravity = true;
            Main.dust[num10].velocity *= 0.2f;
            int num11 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity + base.projectile.velocity.RotatedBy(-Math.PI / 2d) * 0.2f * Math.Abs(12 - (projectile.timeLeft % 24)), 4, 4, 64, 0f, 0f, 100, default(Color), 1.7f);
            Main.dust[num11].noGravity = true;
            Main.dust[num11].velocity *= 0.2f;
            if(projectile.timeLeft % 12 == 0)
            {
                for (int p = 0; p < 10; p++)
                {
                    int num12 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity, 4, 4, 113, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num12].noGravity = true;
                    Main.dust[num12].velocity *= 0.2f;
                }
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.3f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            for (int a = 0; a < 180; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 64, v.X, v.Y, 0, default(Color), Main.rand.NextFloat(1.1f, 2.2f));
                Main.dust[num].velocity = v;
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("GoldPosiDust"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(92, 143);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 10)
                {
                    Main.npc[i].StrikeNPC((int)(projectile.damage / 6f), 0, 1);
                }
            }
            target.AddBuff(mod.BuffType("GoldFlame"), 600);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(31, 31), projectile.scale, SpriteEffects.None, 0f);
            for(int i =0;i < 4;i++)
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i * 3f, null, new Color(1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, (1 - 1 / 4f * (float)i) * projectile.alpha / 255f), projectile.rotation, new Vector2(31, 31), projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
