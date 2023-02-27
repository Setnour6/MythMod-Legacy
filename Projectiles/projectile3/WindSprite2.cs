using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class WindSprite2 : ModProjectile
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
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
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
            bool flag2 = projectile.type == mod.ProjectileType("WindSprite1");
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (projectile.active)
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
            if (l != -1 && projectile.timeLeft % 30 == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v = (Main.npc[l].Center - projectile.Center) / (Main.npc[l].Center - projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f) * 50f;
                    v = v + Main.npc[l].velocity;
                    projectile.velocity = v;
                }
            }
            if (l != -1 && projectile.timeLeft % 120 == 1)
            {
                Vector2 v = (Main.npc[l].Center - projectile.Center) / (Main.npc[l].Center - projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f) * 25f;
                v = v.RotatedBy(Main.rand.NextFloat(-0.3f, 0.3f));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("WindBall"), projectile.damage * 2 / 3, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (l != -1)
            { 
                projectile.velocity *= 0.98f;
            }

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = mod.GetTexture("Projectiles/projectile3/WindLoop");
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            if(projectile.velocity.Length() > 10)
            {
                if((projectile.velocity.Length() - 10) / 40f > 1)
                {
                    Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), null, new Color(1f, 1f, 1f, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)texture2D.Height / 2f), base.projectile.scale, effects, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), null, new Color((projectile.velocity.Length() - 10) / 40f, (projectile.velocity.Length() - 10) / 40f, (projectile.velocity.Length() - 10) / 40f, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)texture2D.Height / 2f), base.projectile.scale, effects, 0f);
                }
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawOrigin = new Vector2(texture2D.Width * 0.5f, texture2D.Height * 0.5f);
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                    Color color = new Color((projectile.velocity.Length() - 10) / 40f, (projectile.velocity.Length() - 10) / 40f, (projectile.velocity.Length() - 10) / 40f, 0) * ((40 - k) / 40f);
                    //color.A = 0;
                    spriteBatch.Draw(texture2D, drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale * (80 - k) / 80f, effects, 0f);
                }
            }
            return true;
        }
    }
}
