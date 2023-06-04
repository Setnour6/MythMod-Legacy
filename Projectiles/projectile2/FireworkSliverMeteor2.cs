using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class FireworkSliverMeteor2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("烟花火球银流星");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 700;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private float b;
        private float z;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void AI()
        {
            if (initialization)
            {
                b = Main.rand.Next(-50, 50);
                if (Projectile.velocity.Length() >= 1)
                {
                    z = Projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
            }
            Projectile.velocity *= 0.995f;
            NPC target = null;
            if (Projectile.timeLeft < 480 + (float)b)
            {
                Projectile.scale *= 0.992f;
            }
            Projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D t = base.Mod.GetTexture("Projectiles/烟花火球金棕色尾迹");
            int frameHeight = 14;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                Color color = new Color(255, 255, 255, 0) * ((float)(Projectile.oldPos.Length - k * k / 90) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * Projectile.frame, 14, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale * 0.5f, SpriteEffects.None, 0f);
            }
            if (Projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/烟花火球银light"), base.Projectile.Center - Main.screenPosition, null, new Color(Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), 0), base.Projectile.rotation, new Vector2(56f, 56f), 1 + (800 - Projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}