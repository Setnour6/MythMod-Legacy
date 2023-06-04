using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
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
    public class ShadowBird : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("剑影");
            Main.projFrames[base.Projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            Projectile.width = 72;
            Projectile.height = 76;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 255;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
        }
        private bool initialization = true;
        private double X;
        private float O = 2;
        private float b = -2;
        public override void AI()
        {
            if (Projectile.timeLeft % 6 == 0)
            {
                if (Projectile.frame < 7)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
            Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
            if (Projectile.timeLeft < 590)
            {
                Projectile.tileCollide = true;
            }
            else
            {
                Projectile.alpha -= 25;
            }
            if(Math.Abs(O) > 4)
            {
                O *= -0.96f;
            }
            else
            {
                O += Main.rand.NextFloat(-0.7f,0.2f);
            }
            if (Math.Abs(b) > 4)
            {
                b *= -0.96f;
            }
            else
            {
                b += Main.rand.NextFloat(-0.2f, 0.7f);
            }
            int num = Dust.NewDust(Projectile.Center - new Vector2(4, 4) + Projectile.velocity.RotatedBy(Math.PI / 2d) * O, 0, 0, 29, 0, 0, 0, default(Color), 1.4f);
            Main.dust[num].noGravity = true;
            int num2 = Dust.NewDust(Projectile.Center - new Vector2(4, 4) + Projectile.velocity.RotatedBy(Math.PI / 2d) * b, 0, 0, 29, 0, 0, 0, default(Color), 1.4f);
            Main.dust[num2].noGravity = true;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
            for (int a = 0; a < 28; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 29, v.X, v.Y, 0, default(Color), 3f);
                Main.dust[num].noGravity = true;
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

    }
}