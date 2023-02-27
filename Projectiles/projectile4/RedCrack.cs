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

namespace MythMod.Projectiles.projectile4
{
    public class RedCrack : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("绯红割裂");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 10;
            base.projectile.height = 10;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.extraUpdates = 24;
            base.projectile.timeLeft = 601;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 400;
            base.projectile.tileCollide = false;
        }
        private float lig = 0;
        private double Rot = 0;
        private float Squ = 0;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig, lig, lig, 0));
        }
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            if (projectile.timeLeft < 601)
            {
                lig = 1f;
                projectile.velocity *= 1.02f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
            //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = mod.GetTexture("Projectiles/projectile4/RedCrack");
            int Times = (int)((Math.Sin((500 - projectile.timeLeft) / 1200d * Math.PI) + 0.15f) * 1000f / Math.Log(projectile.timeLeft + 4));
            float a = (600 - projectile.timeLeft) / 600f * (float)Times;
            for (int y = 0; y < Times; y++)
            {
                //Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                Vector2 v1 = projectile.Center + projectile.velocity / projectile.velocity.Length() * (float)y * 10f;
                float Rot2 = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
                float Sca = 1;
                int x = 0;
                if (y < a)
                {
                    x = (int)((Math.Cos(y / a * Math.PI) + 1) * 2.5f);
                }
                else
                {
                    x = (int)((Math.Cos(Math.PI * y / (Times - a) - a * Math.PI / (Times - a)) + 1) * 2.5f);
                }
                spriteBatch.Draw(Main.projectileTexture[projectile.type], v1 - Main.screenPosition, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 50f, lig * (Times - y) / 50f, lig * (Times - y) / 50f, 0), Rot2, new Vector2(5, 5 - x), projectile.scale, SpriteEffects.None, 0f);
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], v1, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f), Rot2, new Vector2(5, 5), projectile.scale, SpriteEffects.None, 0f);
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], v1 - Main.screenPosition, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, 0), Rot2, new Vector2(1, 15), projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        private float DisFri = 0;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            DisFri = 20;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}