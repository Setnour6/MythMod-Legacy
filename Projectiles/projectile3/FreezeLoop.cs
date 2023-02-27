using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FreezeLoop : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰环");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 100;
            base.projectile.extraUpdates = 3;
            base.projectile.hostile = false;
            projectile.tileCollide = false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, 0));
            }
        }
        float size = 0;
        public override void AI()
		{
            if(size < 1)
            {
                size += 0.0001f;
                size *= 1.2f;
            }
            Player player = Main.player[Main.myPlayer];
            if(projectile.timeLeft % 3 == 2)
            {
                if (projectile.timeLeft / 25f > 5)
                {
                    int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), 15 * size);
                    Main.dust[r].velocity.X = projectile.velocity.X * 4f;
                    Main.dust[r].velocity.Y = projectile.velocity.Y * 4f;
                    Main.dust[r].noGravity = true;
                }
                else
                {
                    int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), projectile.timeLeft / 25f * size * 3);
                    Main.dust[r].velocity.X = projectile.velocity.X * 4f;
                    Main.dust[r].velocity.Y = projectile.velocity.Y * 4f;
                    Main.dust[r].noGravity = true;
                }
            }
            projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("千年桔树妖之眼"))
            {
                if(!target.HasBuff(mod.BuffType("Freeze")))
                {
                    target.AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                    target.AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                }
            }
            if(target.type == 113)
            {
                for(int i = 0;i < 200;i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        if (!target.HasBuff(mod.BuffType("Freeze")))
                        {
                            target.AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                            target.AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
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
                        if (!target.HasBuff(mod.BuffType("Freeze")))
                        {
                            target.AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                            target.AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                        }
                    }
                }
            }
        }
	}
}
