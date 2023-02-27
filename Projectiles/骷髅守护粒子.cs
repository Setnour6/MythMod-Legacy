using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles
{
    public class 骷髅守护粒子 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("骷髅守护粒子");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 6000000;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 0.7f;
            this.cooldownSlot = 1;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            if(NPC.CountNPCS(127) <= 0)
            {
                projectile.Kill();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
    }
}