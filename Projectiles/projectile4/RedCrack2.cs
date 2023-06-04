using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile4
{
    public class RedCrack2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("爪牙");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 10;
            base.Projectile.height = 10;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.extraUpdates = 6;
            base.Projectile.timeLeft = 601;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 400;
            base.Projectile.tileCollide = false;
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
            if (Projectile.timeLeft < 601)
            {
                lig = 1f;
                Projectile.velocity *= 1.02f;
            }
            if(Projectile.timeLeft < 300)
            {
                Projectile.Kill();
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
            //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = Mod.GetTexture("Projectiles/projectile4/RedCrack");
            int Times = (int)((Math.Sin((500 - Projectile.timeLeft) / 1200d * Math.PI) + 0.15f) * 200f / Math.Log(Projectile.timeLeft + 4));
            float a = (600 - Projectile.timeLeft) / 600f * (float)Times;
            for (int y = 0; y < Times; y++)
            {
                //Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                Vector2 v1 = Projectile.Center + Projectile.velocity / Projectile.velocity.Length() * (float)y * 10f;
                float Rot2 = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
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
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1 - Main.screenPosition, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 10f, lig * (Times - y) / 10f, lig * (Times - y) / 10f, 0), Rot2, new Vector2(5, 5 - x), Projectile.scale, SpriteEffects.None, 0f);
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], v1, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f), Rot2, new Vector2(5, 5), projectile.scale, SpriteEffects.None, 0f);
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], v1 - Main.screenPosition, new Rectangle(0, x, 10, 10 - 2 * x), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, 0), Rot2, new Vector2(1, 15), projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        private float DisFri = 0;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            DisFri = 20;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}