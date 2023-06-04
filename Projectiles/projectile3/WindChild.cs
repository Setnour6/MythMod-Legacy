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

namespace MythMod.Projectiles.projectile3
{
    public class WindChild : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("风之子");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 54;
            base.Projectile.height = 54;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 26;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
        }
        private float num4;
        private float Dx = 0;
        private int k = 0;
        private int l = 0;
        private int D = -1;
        private Vector2 v = new Vector2(1, 0);
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            p.AddBuff(Mod.Find<ModBuff>("WindSprite1").Type, 3600, true);
            if (Projectile.timeLeft == 16)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("WindSprite1").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.timeLeft == 14)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("WindSprite2").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (Main.time % 8 == 1)
            {
                if (Projectile.frame < 5)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
            if (k == 0)
            {
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                k += 1;
            }
            v = v / v.Length();
            Projectile.velocity = v * 20f;
            Projectile.position = p.Center + v - new Vector2(27, 27);
            Projectile.spriteDirection = D;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            //p.ChangeDir(base.projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            Projectile.alpha = 0;
            k = 1;
            l += 1;
            if (l <= 27)
            {
                v = v.RotatedBy(0.1011f * D);
            }
            else
            {
                if (Main.mouseX > Main.screenWidth / 2)
                {
                    p.direction = 1;
                }
                else
                {
                    p.direction = -1;
                }
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                l = 0;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
                Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
                int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
                int y = num * base.Projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255, 255, 255, 0), base.Projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
            }
            else
            {
                Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
                int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
                int y = num * base.Projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255,255,255,0), base.Projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
            }
            return false;
        }
    }
}
