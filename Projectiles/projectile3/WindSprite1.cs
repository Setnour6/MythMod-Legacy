using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class WindSprite1 : ModProjectile
    {
        private float num = 0;
        private float num16 = 0;
        private float num12 = 0;
        private int num18 = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("风之精灵");
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 46;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 2f;
            projectile.timeLeft = 720000;
            projectile.aiStyle = 54;
            projectile.timeLeft *= 5;
            this.aiType = 317;
            projectile.penetrate = -1;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!player.HasBuff(mod.BuffType("WindSprite1")))
            {
                projectile.Kill();
            }
            if (projectile.frameCounter > 7)
            {
                num16 += 0.15f;
                projectile.frame = (int)num16;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 7)
            {
                projectile.frame = 0;
                num16 = 0;
            }
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if(projectile.active)
            {
                player.AddBuff(mod.BuffType("WindSprite1"), 3600, true);
            }
            bool flag = false;
            float num2 = projectile.Center.X;
            float num3 = projectile.Center.Y;
            float num4 = 800f;
            if (projectile.wet)
            {
                num4 = 1600f;
            }
            int l = -1;
            for (int i = 0; i < 200; i++)
            {
                if (!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].active && Main.npc[i].CanBeChasedBy() && (Main.npc[i].Center - projectile.Center).Length() < 1000)
                {
                    if (l == -1)
                    {
                        l = i;
                    }
                    else if ((Main.npc[i].Center - projectile.Center).Length() < (Main.npc[l].Center - projectile.Center).Length())
                    {
                        l = i;
                    }
                }
            }
            if (l != -1 && projectile.timeLeft % 90 == 1)
            {
                for(int i = 0; i < 4; i++)
                {
                    Vector2 v = (Main.npc[l].Center - projectile.Center) / (Main.npc[l].Center - projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f);
                    v = v.RotatedBy(Main.rand.NextFloat(-0.3f, 0.3f));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("WindBlade"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                }
            }
            if (l != -1)
            {
                projectile.velocity *= 0.9f;
            }

        }
    }
}
