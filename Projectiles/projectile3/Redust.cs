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
    public class Redust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Redust");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 40;
            base.projectile.height = 40;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 4;
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
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8) - base.projectile.velocity, 0, 0, 183, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.2f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0;i < 30;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8), 0, 0, 183, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 18; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 3f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8), 0, 0, 183, v.X, v.Y, 100, default(Color), 1.7f);
                Main.dust[num9].noGravity = true;
            }
            target.AddBuff(mod.BuffType("Break"), 300, false);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(17, 17), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
