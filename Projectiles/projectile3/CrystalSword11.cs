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
    public class CrystalSword11 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("冰晶石剑影");
        }
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 255;
            Projectile.penetrate = 1;
            Projectile.scale = 0.5f;
        }
        private bool initialization = true;
        private double X;
        private float Omega = 0;
        private float b;
        public override void AI()
        {
            Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
            if (Projectile.timeLeft < 590)
            {
                Projectile.tileCollide = true;
            }
            else
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.timeLeft < 52)
            {
                Projectile.alpha += 5;
                Projectile.tileCollide = false;
            }
            if(Projectile.velocity.Y < 30)
            {
                Projectile.velocity.Y += 0.25f;
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
            for (int a = 0; a < 8; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Crystal").Type, v.X, v.Y, 0, default(Color), 1.4f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            if (timeLeft > 52)
            {
                //float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑1"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑2"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑3"), projectile.scale);
                //Gore.NewGore(projectile.position, projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑4"), projectile.scale);
            }
            for (int j = 0; j < 200; j++)
            {
                if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - Projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                {
                    Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - Projectile.Center).Length(), (int)((Main.npc[j].Center.X - Projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - Projectile.Center.X)));
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int p = (255 - Projectile.alpha);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, new Color(p / 255f, p / 255f, p / 255f, (255 - p) / 255f), Projectile.rotation, new Vector2(110, 110), Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}