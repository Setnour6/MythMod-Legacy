using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x02000A56 RID: 2646
	public class Cyclone : ModProjectile
	{
		private bool initialization = true;
        private float X;
		// Token: 0x06003182 RID: 12674 RVA: 0x0000EF18 File Offset: 0x0000D118
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 600f;
        }
		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			if (initialization)
            {
                X = 0;
				initialization = false;
            }
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 3600f, 600f, 16f);
            float i = (float)Math.Sin((float)X / 20 * Math.PI);
			float j = (float)Math.Cos((float)X / 20 * Math.PI);
			int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 16, 0, 0, 150, default(Color), 2.4f);
			Main.dust[num].velocity.Y = (float)i * 6f;
			Main.dust[num].velocity.X = (float)j * 6f;
            Main.dust[num].scale *= 1.02f;
			Main.dust[num].alpha = (int)(255 - 255 * (float)Main.dust[num].scale / 1.2f);
			Main.dust[num].velocity *= 1.02f;
		    Main.dust[num].noGravity = true;
			int num1 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 16, 0, 0, 150, default(Color), 2.4f);
			Main.dust[num1].velocity.Y = (float)-i * 6f;
			Main.dust[num1].velocity.X = (float)-j * 6f;
            Main.dust[num1].scale *= 1.02f;
			Main.dust[num1].alpha = (int)(255 - 255 * (float)Main.dust[num1].scale / 1.2f);
			Main.dust[num1].velocity *= 1.02f;
		    Main.dust[num1].noGravity = true;
			X ++;
            for(int m = 0;m < 200; m++)
            {
                if((Main.npc[m].Center - base.projectile.Center).Length() <= 150 && Main.npc[m].friendly == false && Main.npc[m].dontTakeDamage == false)
                {
                    Main.npc[m].velocity += (base.projectile.Center - Main.npc[m].Center) / (Main.npc[m].Center - base.projectile.Center).Length() * (150 - (Main.npc[m].Center - base.projectile.Center).Length()) * 10f / (Main.npc[m].height * Main.npc[m].width);
                }
            }
            for (int n = 0; n < 600; n++)
            {
                if ((Main.projectile[n].Center - base.projectile.Center).Length() <= 150 && Main.projectile[n].type != mod.ProjectileType("Cyclone"))
                {
                    Main.projectile[n].velocity += (base.projectile.Center - Main.projectile[n].Center) / (Main.projectile[n].Center - base.projectile.Center).Length() * (150 - (Main.projectile[n].Center - base.projectile.Center).Length()) * 0.1f;
                }
                if ((Main.projectile[n].Center - base.projectile.Center).Length() <= 10 && Main.projectile[n].type != mod.ProjectileType("Cyclone"))
                {
                    Main.projectile[n].friendly = true;
                    Main.projectile[n].hostile = false;
                }
            }
            //for (int x = -10; x < 10; x++)
            //{
                //for (int y = -10; y < 10; y++)
                //{
                   // Dust.NewDust(new Vector2(base.projectile.Center.X + x * 16, base.projectile.Center.Y + y * 16),16,16, (ModTile)(Main.tile[x, y].dustType),)
                //}
            //}
        }
        // Token: 0x06003183 RID: 12675 RVA: 0x001AA8C0 File Offset: 0x001A8AC0
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(1) == 0)
			{
				//Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Main.rand.Next(-4, 4), -1.2f, base.mod.ProjectileType("台风之影"), (int)((float)base.projectile.damage * 0.75f), 3f, base.projectile.owner, 0f, 0f);
                //Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Main.rand.Next(-4, 4), -1.2f, base.mod.ProjectileType("台风之影"), (int)((float)base.projectile.damage * 0.75f), 3f, base.projectile.owner, 0f, 0f);
			}
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000064C1 File Offset: 0x000046C1
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
