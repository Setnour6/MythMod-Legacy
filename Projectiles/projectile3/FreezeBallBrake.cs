using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
	// Token: 0x0200067D RID: 1661
    public class FreezeBallBrake : ModProjectile
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰封球");
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001D6574 File Offset: 0x001D4774
		public override void SetDefaults()
		{
			base.Projectile.width = 32;
			base.Projectile.height = 32;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 100;
            base.Projectile.extraUpdates = 10;
            base.Projectile.hostile = false;
            Projectile.tileCollide = false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, 0));
            }
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            if(Projectile.timeLeft / 25f > 5)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), 5);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
            }
            else
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), Projectile.timeLeft / 25f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
            }
            Projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != Mod.Find<ModNPC>("千年桔树妖之眼").Type)
            {
                if(!target.HasBuff(Mod.Find<ModBuff>("Freeze").Type))
                {
                    target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                    target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
                }
            }
            if(target.type == 113)
            {
                for(int i = 0;i < 200;i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        if (!target.HasBuff(Mod.Find<ModBuff>("Freeze").Type))
                        {
                            target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                            target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
                        }
                    }
                }
            }
            if (target.type == 114)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        if (!target.HasBuff(Mod.Find<ModBuff>("Freeze").Type))
                        {
                            target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                            target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
                        }
                    }
                }
            }
        }
	}
}
