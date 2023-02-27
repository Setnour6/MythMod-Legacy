using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
	public class TrapYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
            base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 410f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 410f, 14f);
            if (Main.rand.Next(30) == 0)
            {
                float num4 = (float)(Main.rand.Next(500, 4000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 1500f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 1500f;
                int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, 185, (int)((double)base.Projectile.damage * 0.5f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
                Main.projectile[num].timeLeft = 120;
            }
            if (Main.rand.Next(30) == 0)
            {
                float num4 = (float)(Main.rand.Next(500, 4000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 1500f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 1500f;
                int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, 15, (int)((double)base.Projectile.damage * 0.5f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
                Main.projectile[num].timeLeft = 120;
            }
            if(Main.time % 8 == 0)
            {
                for(int k = 0;k < 200;k++)
                {
                    if(Main.npc[k].HasBuff(Mod.Find<ModBuff>("BIAOJISJRYoyo").Type) && Main.npc[k].active)
                    {
                        Vector2 v = Main.npc[k].Center - Projectile.Center;
                        v = v / v.Length() * 20f;
                        int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X,v.Y, 259, base.Projectile.damage, 0.2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num2].timeLeft = 200;
                        Main.projectile[num2].hostile = false;
                        Main.projectile[num2].friendly = true;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
            for (int i = 0; i < 8; i++)
            {
                int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 4f) * Math.PI + num7) * 7 / 1.5f * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 4f) * Math.PI + num7) * 7) / 1.5f * 2.88f, 259, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                Main.projectile[num2].timeLeft = 200;
                Main.projectile[num2].hostile = false;
                Main.projectile[num2].friendly = true;
            }
            target.AddBuff(Mod.Find<ModBuff>("BIAOJISJRYoyo").Type, 60);
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/机关球Glow"), base.Projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.Projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
    }
}
