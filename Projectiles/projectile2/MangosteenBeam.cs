using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000618 RID: 1560
    public class MangosteenBeam : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("山竹剑气");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.Projectile.width = 28;
            base.Projectile.height = 28;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            if(Main.rand.Next(0,150) > 75)
            {
                int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity * 6f, 0, 0, 114, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            else
            {
                int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity * 6f, 0, 0, 112, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f, (float)(255 - base.Projectile.alpha) * 0.49f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f);
		}
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void Kill(int timeLeft)
        {
			float num60 = (float)Main.rand.Next(0 , 10000);
			int num80 = Main.rand.Next(-1000 , 1000) / 100;
			double num90 = (double)Math.Sqrt(100 - (int)num80 * (int)num80);
			Vector2 v1 = Vector2.Normalize(new Vector2((float)num80,(float)num90)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num80,(float)num90);
			float num100 = (float)Main.rand.Next(0, 10000) / 1000;
			float T = (float)(Main.rand.Next(0, 10000) / 5000 * Math.PI);
            for (int i = 0; i < 125; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 62.5f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 27, (float)num80, (float)num90, 150, Color.Black, 1.8f);
                int p2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 60, (float)num80, (float)num90, 150, default(Color), 1.8f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 2.5f;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].noGravity = true;
                Main.dust[p2].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 1.4f;
                Main.dust[p2].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p2].noGravity = true;
            }
            int num10 = 0;
			while ((float)num10 < 200)
			{
                Vector2 v = new Vector2(Main.rand.Next(Main.rand.Next(0, 1000), 1000) / 200f, 0).RotatedByRandom(Math.PI * 2);
                int num8 = Main.rand.Next(3);
				if (num8 == 0)
				{
					num8 = 114;
				}
				else if (num8 == 1)
				{
					num8 = 114;
				}
				else
				{
					num8 = 114;
				}
				int num9 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, num8, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num9].noGravity = true;
				Main.dust[num9].position.X = base.Projectile.Center.X;
				Main.dust[num9].position.Y = base.Projectile.Center.Y;
				Dust dust = Main.dust[num9];
				dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
				Dust dust2 = Main.dust[num9];
				dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                Main.dust[num9].velocity = v;
                num10++;
			}
        }
		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
	}
}
