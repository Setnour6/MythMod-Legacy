using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 根系精灵 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("根系精灵");
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 36;
			base.projectile.height = 36;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.minionSlots = 1f;
			base.projectile.aiStyle = 54;
			base.projectile.timeLeft = 18000;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			this.aiType = 317;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
		}
		public override void AI()
		{
			if (base.projectile.localAI[0] == 0f)
			{
				int num = 36;
				for (int i = 0; i < num; i++)
				{
					Vector2 vector = Vector2.Normalize(base.projectile.velocity) * new Vector2((float)base.projectile.width / 2f, (float)base.projectile.height) * 0.75f;
					vector = Utils.RotatedBy(vector, (double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.projectile.Center;
					Vector2 vector2 = vector - base.projectile.Center;
					int num2 = Dust.NewDust(vector + vector2, 0, 0, 5, vector2.X * 1.5f, vector2.Y * 1.5f, 100, default(Color), 1.4f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector2;
				}
				base.projectile.localAI[0] += 1f;
			}
            bool flag = base.projectile.type == base.mod.ProjectileType("根系精灵");
			Player player = Main.player[base.projectile.owner];
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            player.AddBuff(base.mod.BuffType("GXJL"), 3600, true);
			if (flag)
			{
				if (player.dead)
				{
                    modPlayer.GXJL = false;
				}
                if (modPlayer.GXJL)
				{
					base.projectile.timeLeft = 2;
				}
			}
		}
	}
}
