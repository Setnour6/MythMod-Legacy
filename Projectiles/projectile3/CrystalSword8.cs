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
namespace MythMod.Projectiles.projectile3
{
    public class CrystalSword8 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("冰晶石剑影");
        }
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 0.5f;
        }
        private bool initialization = true;
        private double X;
        private float Omega = 0;
        private float b;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (initialization)
            {
                if (Projectile.velocity.Length() > 1f)
                {
                    Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
                }
                else
                {
                    Projectile.rotation += Omega;
                    if (Omega < 1f)
                    {
                        Omega += 0.02f;
                    }
                    else
                    {
                        Projectile.velocity = (player.Center - Projectile.Center) / (player.Center - Projectile.Center).Length() * 45f;
                        initialization = false;
                        Projectile.timeLeft = 180;
                    }
                }
            }
            else
            {
                Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
                Projectile.velocity *= 0.99f;
            }
            if(Projectile.timeLeft < 52)
            {
                Projectile.alpha += 5;
            }
            Projectile.velocity *= 0.98f;
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                SoundEngine.PlaySound(SoundID.Item27, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
                for (int a = 0; a < 10; a++)
                {
                    Vector2 vector = base.Projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Crystal").Type, v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.15f, 0.05f) * 0.1f;
                }
            }
            if (timeLeft > 52)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(Projectile.position, Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑1"), Projectile.scale);
                Gore.NewGore(Projectile.position, Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑2"), Projectile.scale);
                Gore.NewGore(Projectile.position, Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑3"), Projectile.scale);
                Gore.NewGore(Projectile.position, Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑4"), Projectile.scale);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int p = (255 - Projectile.alpha);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, new Color(p, p, p, 255 - p), Projectile.rotation, new Vector2(110, 110), Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}