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
            // DisplayName.SetDefault("风之精灵");
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            Projectile.width = 56;
            Projectile.height = 46;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.minionSlots = 2f;
            Projectile.timeLeft = 720000;
            Projectile.aiStyle = 54;
            Projectile.timeLeft *= 5;
            this.AIType = 317;
            Projectile.penetrate = -1;
            Projectile.minion = true;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.HasBuff(Mod.Find<ModBuff>("WindSprite1").Type))
            {
                Projectile.Kill();
            }
            if (Projectile.frameCounter > 7)
            {
                num16 += 0.15f;
                Projectile.frame = (int)num16;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 7)
            {
                Projectile.frame = 0;
                num16 = 0;
            }
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if(Projectile.active)
            {
                player.AddBuff(Mod.Find<ModBuff>("WindSprite1").Type, 3600, true);
            }
            bool flag = false;
            float num2 = Projectile.Center.X;
            float num3 = Projectile.Center.Y;
            float num4 = 800f;
            if (Projectile.wet)
            {
                num4 = 1600f;
            }
            int l = -1;
            for (int i = 0; i < 200; i++)
            {
                if (!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].active && Main.npc[i].CanBeChasedBy() && (Main.npc[i].Center - Projectile.Center).Length() < 1000)
                {
                    if (l == -1)
                    {
                        l = i;
                    }
                    else if ((Main.npc[i].Center - Projectile.Center).Length() < (Main.npc[l].Center - Projectile.Center).Length())
                    {
                        l = i;
                    }
                }
            }
            if (l != -1 && Projectile.timeLeft % 90 == 1)
            {
                for(int i = 0; i < 4; i++)
                {
                    Vector2 v = (Main.npc[l].Center - Projectile.Center) / (Main.npc[l].Center - Projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f);
                    v = v.RotatedBy(Main.rand.NextFloat(-0.3f, 0.3f));
                    Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("WindBlade").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                }
            }
            if (l != -1)
            {
                Projectile.velocity *= 0.9f;
            }

        }
    }
}
