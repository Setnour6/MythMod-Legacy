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
    public class EvilSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("邪魔剑气");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            projectile.alpha = 255;
            base.projectile.extraUpdates = 3;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            projectile.tileCollide = true;
            base.projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            if (projectile.alpha > 5)
            {
                projectile.alpha -= 5;
            }
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - (base.projectile.velocity * 3f).RotatedBy(((float)Math.Sin(Main.time / 3d) / 3f)), 4, 4, 27, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.2f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            //int k = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            //Main.projectile[k].timeLeft = 30;
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 27, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            for (int i = 0; i < 9; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 27, v.X, v.Y, 100, default(Color), 1.8f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 v = projectile.velocity.RotatedByRandom(Math.PI * 2) * 0.4f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("EvilSword2"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 20);
            }
            target.AddBuff(153, 900);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(20, 20), projectile.scale, SpriteEffects.None, 0f);
            for(int i =0;i < 4;i++)
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i * 3f, null, new Color(1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, (1 - 1 / 4f * (float)i) * projectile.alpha / 255f), projectile.rotation, new Vector2(20, 20), projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
