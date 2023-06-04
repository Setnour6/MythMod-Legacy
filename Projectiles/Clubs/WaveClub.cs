﻿using System;
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
using Terraria.ID;

namespace MythMod.Projectiles.Clubs
{
    public class WaveClub : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("碧水盘龙棍");
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 64;
            base.Projectile.height = 64;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 2;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
            Projectile.frame = 0;
        }
        private int lz = 0;
        public override void AI()
        {
            lz += 1;
            base.Projectile.rotation += 0.4f;
            Player p = Main.player[Main.myPlayer];
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.position + v + new Vector2(-(Projectile.width / 2 - p.width / 2), -10);
            Projectile.spriteDirection = p.direction;
            if (Projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.Projectile.timeLeft = 2;
            }
            if (p.dead)
            {
                Projectile.Kill();
            }
            if (lz % 4 == 1)
            {
                Projectile.friendly = true;
            }
            else
            {
                Projectile.friendly = false;
            }
            if (lz % 48 == 1)
            {
                Vector2 vk = new Vector2((float)Main.screenPosition.X + Main.mouseX - p.Center.X, (float)Main.screenPosition.Y + Main.mouseY - p.Center.Y);
                vk = vk / vk.Length() * 13f;
                int i = Projectile.NewProjectile(p.Center.X + vk.X, p.Center.Y + vk.Y, vk.X, vk.Y, Mod.Find<ModProjectile>("海浪球").Type, Projectile.damage * 6, Projectile.knockBack * 0.5f, p.whoAmI, 0, 0);
            }
            float li = Main.rand.NextFloat(-32f, 32f);
            int num25 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4) + new Vector2(li, li).RotatedBy(Projectile.rotation), 0, 0, Mod.Find<ModDust>("Wave").Type, 0, 0, 0, default(Color), 2f);
            Main.dust[num25].noGravity = true;
            Main.dust[num25].velocity = new Vector2(li, li).RotatedBy(Math.PI / 2 + Projectile.rotation) * 0.15f;
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Player p = Main.player[Main.myPlayer];
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(32, 32), Projectile.scale, effects, 0f);
            return false;
        }
    }
}
