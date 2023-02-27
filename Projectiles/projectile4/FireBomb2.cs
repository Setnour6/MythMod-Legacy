using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile4
{
    public class FireBomb2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FireBomb");
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 36000;
            projectile.penetrate = 1;
            projectile.scale = 1;
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
            int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 3, mod.DustType("Flame3"), 0, 0, 0, default(Color), 10f);
            Main.dust[r].noGravity = true;
            for(int i = 0; i < 5; i++)
            {
                Vector2 v = new Vector2(0, 80).RotatedBy(projectile.timeLeft / 20d);
                int z = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) + v, 0, 0, mod.DustType("Flame3"), 0, 0, 0, default(Color), 5f);
                Main.dust[z].noGravity = true;
            }
            int K = 0;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1) && !Main.npc[j].dontTakeDamage)
                {
                    if((Main.npc[j].Center - projectile.Center).Length() < 80)
                    {
                        Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f,1.15f)), 0, 0, Main.rand.Next(100) > 70 ? false : true);
                        K += 1;
                    }
                }
            }
            if(K > 0)
            {
                projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/ÑÌ»¨±¬Õ¨"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("»ðÉ½½¦Éä"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int k = 0; k <= 10; k++)
            {
                if (projectile.damage > 300)
                {
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("FireBallWave"), 0, 0, base.projectile.owner, 0f, 0f);
                }
            }
            for (int i = 0; i < 170; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3.2f, (float)(2.7 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(7f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 80; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3.2f, (float)(2.7 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(9f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.4f;
            }
        }
    }
}