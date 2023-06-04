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
using Terraria.ID;

namespace MythMod.Projectiles.Clubs
{
    public class StarDancer : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("星之舞者");
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
            float li = Main.rand.NextFloat(-32f,32f);
            if (lz % 8 == 1)
            {
                Gore.NewGore(Projectile.Center - new Vector2(4, 4) + new Vector2(li, li).RotatedBy(Projectile.rotation), new Vector2(li, li).RotatedBy(Math.PI / 2 + Projectile.rotation) * 0.3f, Main.rand.Next(16,18), 1f);
            }
            if (lz % 3 == 1)
            {
                int num25 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4) + new Vector2(li, li).RotatedBy(Projectile.rotation), 0, 0, 150, 0, 0, 0, default(Color), 1.8f);
                Main.dust[num25].noGravity = true;
                Main.dust[num25].velocity = new Vector2(li, li).RotatedBy(Math.PI / 2 + Projectile.rotation) * 0.3f;
            }
            if (lz % 3 == 0)
            {
                int num25 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4) + new Vector2(li, li).RotatedBy(Projectile.rotation), 0, 0, 58, 0, 0, 0, default(Color), 1.8f);
                Main.dust[num25].noGravity = true;
                Main.dust[num25].velocity = new Vector2(li, li).RotatedBy(Math.PI / 2 + Projectile.rotation) * 0.3f;
            }
            if (lz % 15 == 1)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2(Projectile.Center.X + X, Projectile.Center.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                int o = Projectile.NewProjectile(Projectile.Center.X + X, Projectile.Center.Y - 500f + Y, v2.X, v2.Y + 10f, 9, Projectile.damage * 2, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
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
