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
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class FireworkRedBreak2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("烟花火球红散裂2");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 7;
            Projectile.height = 7;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 600;
            Projectile.alpha = 105;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float z;
        public override void AI()
        {
            if (initialization)
            {
                if (Projectile.velocity.Length() >= 1)
                {
                    z = Projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                X = (float)Math.Sqrt((double)Projectile.velocity.X * (double)Projectile.velocity.X + (double)Projectile.velocity.Y * (double)Projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Cos((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            Projectile.velocity *= 0.995f;
            NPC target = null;
            if (Projectile.timeLeft < 595)
            {
                Vector2 vector = base.Projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), (float)Projectile.scale * 0.8f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            if (Projectile.timeLeft < 480)
            {
                if (Main.rand.Next(70) == 1)
                {
                    int num = Main.rand.Next(3, 7);
                    for (int u = 0; u < num; u++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 22500f * Projectile.scale;
                        int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) + base.Projectile.velocity.X, (float)((float)l * Math.Sin((float)a)) + base.Projectile.velocity.Y, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[num2].scale = Projectile.scale * 1.3f;
                    }
                    SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.6f), new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y));
                    Projectile.timeLeft = 0;
                }
            }
            if (Projectile.timeLeft < 100+ (float)b)
            {
                Projectile.scale *= 0.95f;
            }
            Projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
            if (Projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/烟花火球红light"), base.Projectile.Center - Main.screenPosition, null, new Color(Projectile.scale * (Projectile.timeLeft - 300) / (1200f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (1200f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (1200f * z * z), 0), base.Projectile.rotation, new Vector2(56f, 56f), 1 + (800 - Projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return false;
		}
    }
}