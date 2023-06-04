using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile5
{
    public class GoldLanternLine3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("灯笼须");
        }
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 90;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        private float Z = 0;
        public override void AI()
        {
            Projectile.velocity = Projectile.velocity * 0.95f;
            if(Projectile.timeLeft == 90)
            {
                x = Main.rand.NextFloat(0, (float)(Math.PI * 2));
            }
        }


        public override void PostDraw(Color lightColor)
        {
            x += 0.01f;
            float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, x * 6f, new Vector2(512f, 512f), (M + K) * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, -x * 6f, new Vector2(512f, 512f), (float)Math.Sqrt(M * M + K * K) * 0.4f * Projectile.timeLeft / 90f, SpriteEffects.None, 0f);
        }
        private float x = 0;
    }
}
