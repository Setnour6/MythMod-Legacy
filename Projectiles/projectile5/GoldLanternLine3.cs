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
            DisplayName.SetDefault("灯笼须");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.light = 0.1f;
            projectile.timeLeft = 90;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }
        private float Z = 0;
        public override void AI()
        {
            projectile.velocity = projectile.velocity * 0.95f;
            if(projectile.timeLeft == 90)
            {
                x = Main.rand.NextFloat(0, (float)(Math.PI * 2));
            }
        }


        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            x += 0.01f;
            float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, x * 6f, new Vector2(512f, 512f), (M + K) * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, -x * 6f, new Vector2(512f, 512f), (float)Math.Sqrt(M * M + K * K) * 0.4f * projectile.timeLeft / 90f, SpriteEffects.None, 0f);
        }
        private float x = 0;
    }
}
