using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile4
{
    public class FireBomb3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FireBomb");
        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 36000;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        public override void AI()
        {
            int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4), 0, 3, Mod.Find<ModDust>("Flame3").Type, 0, 0, 0, default(Color), 15f);
            Main.dust[r].noGravity = true;
            for(int i = 0; i < 5; i++)
            {
                Vector2 v = new Vector2(0, 135).RotatedBy(Projectile.timeLeft / 30d);
                int z = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) + v, 0, 0, Mod.Find<ModDust>("Flame3").Type, 0, 0, 0, default(Color), 7f);
                Main.dust[z].noGravity = true;
            }
            int K = 0;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1) && !Main.npc[j].dontTakeDamage)
                {
                    if((Main.npc[j].Center - Projectile.Center).Length() < 135)
                    {
                        Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f,1.15f)), 0, 0, Main.rand.Next(100) > 70 ? false : true);
                        K += 1;
                    }
                }
            }
            if(K > 0)
            {
                Projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/ÑÌ»¨±¬Õ¨"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360f * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("»ðÉ½½¦Éä").Type, base.Projectile.damage / 5, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int k = 0; k <= 10; k++)
            {
                if (Projectile.damage > 300)
                {
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("FireBallWave").Type, 0, 0, base.Projectile.owner, 0f, 0f);
                }
            }
            for (int i = 0; i < 170; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(5.8f, (float)(4.8 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, (float)(9f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 80; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(5.8f, (float)(4.8 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, (float)(12f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v * 0.4f;
            }
        }
    }
}