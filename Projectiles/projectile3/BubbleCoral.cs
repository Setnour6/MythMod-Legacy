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
namespace MythMod.Projectiles.projectile3
{
    public class BubbleCoral : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("气泡珊瑚");
        }
        private bool num100 = true;
        private Vector2 v = new Vector2(0, 0);
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = (int)1.5f;
            Projectile.timeLeft = 450;
            Projectile.alpha = 0;
            Projectile.penetrate = 2;
            Projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void AI()
        {
            int num12 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 88, 0f, 0f, 0, default(Color), 0.8f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            if (num100)
            {
                float num7 = Main.rand.Next(-2000, 2000) / 40000f;
                v = Projectile.velocity.RotatedBy(Math.PI * num7) * Main.rand.Next(9000, 11000) / 10000f;
                if (base.Projectile.ai[0] != 0)
                {
                    float num6 = Main.rand.Next(0, 20000) / 10000f;
                    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI * num6);
                    Projectile.timeLeft = (int)(200 / Projectile.ai[0]);
                }
                num100 = false;
            }
            if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 1.5f)
            {
                base.Projectile.velocity *= 1.1f;
            }
            if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 2f)
            {
                base.Projectile.velocity *= 0.96f;
            }
            Projectile.velocity = Projectile.velocity * 0.95f + v * 0.2f;
            Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.Next(-200, 200) / 1000f);
            base.Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
            NPC target = null;
            float num2 = base.Projectile.Center.X;
			float num3 = base.Projectile.Center.Y;
			float num4 = 400f;
            bool flag = false;
            if(Main.rand.Next(0, (int)(20 * (base.Projectile.ai[0] + 1) * (base.Projectile.ai[0] + 1))) == 5 && base.Projectile.ai[0] < 2 && Projectile.timeLeft <= 420 && !WeakeningFlag)
            {
                int num5 = Main.rand.Next(2, 3);
                for(int i = 0; i < num5; i++)
                {
                    v = v.RotatedBy(Main.rand.NextFloat(-0.8f,0.8f));
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("BubbleCoral").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, base.Projectile.ai[0] + 1, 0f);
                }
                Projectile.velocity = new Vector2(0, 0);
                Projectile.timeLeft = 30;
            }
            if (WeakeningFlag)
            {
                Projectile.velocity *= 0.95f;
            }
        }
        public bool WeakeningFlag = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            Projectile.timeLeft = 30;
            WeakeningFlag = true;
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 20;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            if(Projectile.timeLeft < 80)
            {
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                    Color color = Projectile.GetAlpha(lightColor) * (((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) / 80f * (float)Projectile.timeLeft);
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/靛蓝色"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/红色").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                    Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/靛蓝色"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/红色").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}