using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
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
    //135596
    public class 混乱团2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("混乱团2");
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(Mod.Find<ModBuff>("乱流").Type, 360, true);
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            Projectile.scale += (float)(Math.Sin((double)Projectile.timeLeft / 120 * 3.14159265359f) * 0.004);
            if (initialization)
            {
                b = Main.rand.Next(-30, 30);
                Projectile.timeLeft = 120 + (int)b;
                initialization = false;
            }
            Projectile.velocity.X += Main.rand.Next(-300, 300) / 300;
            Projectile.velocity.Y += Main.rand.Next(-300, 300) / 300;
            if (Projectile.timeLeft < 100)
            {
                Projectile.scale *= 0.99f;
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.2176f / 2550f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.8196f / 2550f, (float)(255 - base.Projectile.alpha) * 0.6373f / 2550f * Projectile.scale);
        }
        //14141414141414
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
        {
		    SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.2f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int k = 0; k < 4; k++)
            {
                                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                                double num45 = Math.Cos((float)num44);
                                double num46 = Math.Sin((float)num44);
                                float num47 = (float)Main.rand.Next(0, 10000) / 8000;
                                int num40 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("混乱团3").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num40].timeLeft = 240;
            }
        }
    }
}