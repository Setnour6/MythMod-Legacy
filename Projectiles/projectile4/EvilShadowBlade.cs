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
    public class EvilShadowBlade : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("魔影太刀");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 30;
            base.projectile.height = 30;
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
            if(projectile.timeLeft == 601)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)projectile.Center.X, (int)projectile.Center.Y);
                projectile.position = p.Center + new Vector2(-20, -20).RotatedBy(projectile.timeLeft / 400d);
                projectile.scale = 0;
                Rot = Main.rand.NextFloat(-0.5f,0.5f);
                Squ = Main.rand.NextFloat(0.42f, 1);
            }
            if (projectile.timeLeft < 601)
            {
                lig = 1f;
                Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - projectile.timeLeft) / 400d * Math.PI * p.direction);
                projectile.position = p.Center + new Vector2(v0.X,v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                projectile.scale = (float)Math.Sin(projectile.timeLeft / 600d * Math.PI) * 3;
                projectile.rotation = (float)(Math.Atan2((p.Center - projectile.Center).Y, (p.Center - projectile.Center).X) + Math.PI / 2d);
            }
            /*int num22 = Dust.NewDust(projectile.position - new Vector2(4, 4), projectile.width, projectile.height, mod.DustType("DarkF2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;*/
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
            //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = mod.GetTexture("Projectiles/projectile4/EvilShadowBlade");
            int Times = (int)((Math.Sin((500 - projectile.timeLeft) / 1200d * Math.PI) + 0.15f) * 400f / Math.Log(projectile.timeLeft + 4));
            for (int y = 0;y < Times;y++)
            {
                Vector2 v0 = new Vector2(-60 * p.direction, -60).RotatedBy((600 - projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                Vector2 v1 = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                float Rot2 = (float)(Math.Atan2((p.Center - (v1 + new Vector2(15, 15))).Y, (p.Center - (v1 + new Vector2(15, 15))).X) + Math.PI / 2d);
                float Sca = (float)Math.Sin((projectile.timeLeft - y * 2f) / 600d * Math.PI) * 3;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2,30), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f), Rot2, new Vector2(1, 15), projectile.scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2, 30), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, 0), Rot2, new Vector2(1, 15), projectile.scale, SpriteEffects.None, 0f);
                if (y == 0 && p.direction == 1)
                {
                    spriteBatch.Draw(mod.GetTexture("Items/Weapons/Bottle/EvilShadowBlade"), v1 + new Vector2(15, 15) - Main.screenPosition, null, Color.White, Rot2 + (float)(Math.PI / 4d * 3 * p.direction), new Vector2(29, 36), 1, SpriteEffects.None, 0f);
                }
                if (y == 0 && p.direction == -1)
                {
                    spriteBatch.Draw(mod.GetTexture("Items/Weapons/Bottle/EvilShadowBlade"), v1 + new Vector2(15, 15) - Main.screenPosition, null, Color.White, Rot2 + (float)(Math.PI / 4d * 3 * p.direction), new Vector2(29, 36), 1, SpriteEffects.FlipHorizontally, 0f);
                }
            }
            if(!Main.gamePaused)
            {
                Vector2 v = (projectile.Center - p.Center) / 25f;
                Projectile.NewProjectile(p.Center.X, p.Center.Y, v.X, v.Y, mod.ProjectileType("littleEvilfire0"), projectile.damage, 0f, Main.myPlayer, 0, 0f);
            }
            return false;
        }
        private float DisFri = 0;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            DisFri = 60;
            target.AddBuff(153, 900);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}