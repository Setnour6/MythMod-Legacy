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
    public class AquamarineBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("海蓝剑气");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 40;
            base.projectile.height = 40;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            projectile.alpha = 255;
            base.projectile.extraUpdates = 3;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 6;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if(projectile.alpha > 5)
            {
                projectile.alpha -= 5;
            }
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 3f, 4, 4, 59, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.2f;
            int num10 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 3f + base.projectile.velocity.RotatedBy(Math.PI / 2d) * (1 + (float)Math.Sin(Main.time / 3d) / 3f), 4, 4, 59, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num10].noGravity = true;
            Main.dust[num10].velocity *= 0.2f;
            int num11 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 3f + base.projectile.velocity.RotatedBy(-Math.PI / 2d) * (1 + (float)Math.Sin(Main.time / 3d) / 3f), 4, 4, 59, 0f, 0f, 100, default(Color), 1.5f);
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
            //int k = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            //Main.projectile[k].timeLeft = 30;
            for (int i = 0;i < 15;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 59, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            for (int i = 0; i < 9; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, 59, v.X, v.Y, 100, default(Color), 1.8f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
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
