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
			ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 36;
			base.Projectile.height = 36;
			base.Projectile.netImportant = true;
			base.Projectile.friendly = true;
			base.Projectile.minionSlots = 1f;
			base.Projectile.aiStyle = 54;
			base.Projectile.timeLeft = 18000;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft *= 5;
			base.Projectile.minion = true;
			this.AIType = 317;
			base.Projectile.tileCollide = false;
			base.Projectile.usesLocalNPCImmunity = true;
			base.Projectile.localNPCHitCooldown = 10;
		}
		public override void AI()
		{
			if (base.Projectile.localAI[0] == 0f)
			{
				int num = 36;
				for (int i = 0; i < num; i++)
				{
					Vector2 vector = Vector2.Normalize(base.Projectile.velocity) * new Vector2((float)base.Projectile.width / 2f, (float)base.Projectile.height) * 0.75f;
					vector = Utils.RotatedBy(vector, (double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.Projectile.Center;
					Vector2 vector2 = vector - base.Projectile.Center;
					int num2 = Dust.NewDust(vector + vector2, 0, 0, 5, vector2.X * 1.5f, vector2.Y * 1.5f, 100, default(Color), 1.4f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector2;
				}
				base.Projectile.localAI[0] += 1f;
			}
            bool flag = base.Projectile.type == base.Mod.Find<ModProjectile>("根系精灵").Type;
			Player player = Main.player[base.Projectile.owner];
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            player.AddBuff(base.Mod.Find<ModBuff>("GXJL").Type, 3600, true);
			if (flag)
			{
				if (player.dead)
				{
                    modPlayer.GXJL = false;
				}
                if (modPlayer.GXJL)
				{
					base.Projectile.timeLeft = 2;
				}
			}
		}
	}
}
