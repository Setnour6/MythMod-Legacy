using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class ExtremePointMigration : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("极值点偏移");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 30;
            base.Projectile.height = 30;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.extraUpdates = 24;
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
            if(Projectile.timeLeft == 601)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                Projectile.position = p.Center + new Vector2(-20, -20).RotatedBy(Projectile.timeLeft / 400d);
                Projectile.scale = 0;
                Rot = Main.rand.NextFloat(-0.5f,0.5f);
                Squ = Main.rand.NextFloat(0.42f, 1);
            }
            if (Projectile.timeLeft < 601)
            {
                lig = 1f;
                Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - Projectile.timeLeft) / 400d * Math.PI * p.direction);
                Projectile.position = p.Center + new Vector2(v0.X,v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                Projectile.scale = (float)Math.Sin(Projectile.timeLeft / 600d * Math.PI) * 3;
                Projectile.rotation = (float)(Math.Atan2((p.Center - Projectile.Center).Y, (p.Center - Projectile.Center).X) + Math.PI / 2d);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
            //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = Mod.GetTexture("Projectiles/projectile3/ExtremePointMigration");
            Texture2D texture2 = Mod.GetTexture("Projectiles/projectile3/ExtremePointMigration2");
            Texture2D texture3 = Mod.GetTexture("Projectiles/projectile4/Star");
            int Times = (int)((Math.Sin((500 - Projectile.timeLeft) / 1200d * Math.PI) + 0.15f) * 400f / Math.Log(Projectile.timeLeft + 4));
            for (int y = 0;y < Times;y++)
            {
                Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - Projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                Vector2 v1 = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                float Rot2 = (float)(Math.Atan2((p.Center - (v1 + new Vector2(15, 15))).Y, (p.Center - (v1 + new Vector2(15, 15))).X) + Math.PI / 2d);
                float Sca = (float)Math.Sin((Projectile.timeLeft - y * 2f) / 600d * Math.PI) * 3;
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2, 30), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 50f, lig * (Times - y) / 150f), Rot2, new Vector2(1, 15), Projectile.scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2, 30), new Color(lig * (Times - y) / 450f, lig * (Times - y) / 450f, lig * (Times - y) / 150f, 0), Rot2, new Vector2(1, 15), Projectile.scale, SpriteEffects.None, 0f);
                Vector2 v2 = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) * (float)(1.5f - Math.Sin(600 - Projectile.timeLeft - y * 2f) / 1.5f) * 0.6f + new Vector2(-10, 0);
                spriteBatch.Draw(texture2, v2 + new Vector2(15, 15) - Main.screenPosition, null, new Color(lig * (Times - y) / 100f, lig * (Times - y) / 300f, lig * (Times - y) / 100f, 0), Rot2, new Vector2(2, 2), Projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        private float DisFri = 0;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            DisFri = 60;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}