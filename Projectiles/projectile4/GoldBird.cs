using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
    public class GoldBird : ModProjectile
    {
        private float num = 0;
        private float num16 = 0;
        private float num12 = 0;
        private int num18 = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金乌");
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 32;
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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.HasBuff(Mod.Find<ModBuff>("GoldBird").Type))
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
            bool flag2 = Projectile.type == Mod.Find<ModProjectile>("GoldBird").Type;
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (Projectile.active)
            {
                player.AddBuff(Mod.Find<ModBuff>("GoldBird").Type, 3600, true);
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
            if (l != -1 && Projectile.timeLeft % 30 == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v = (Main.npc[l].Center - Projectile.Center) / (Main.npc[l].Center - Projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f) * 50f;
                    v = v + Main.npc[l].velocity;
                    Projectile.velocity = v;
                }
            }
            if (l != -1 && Projectile.timeLeft % 120 == 1)
            {
                Vector2 v = (Main.npc[l].Center - Projectile.Center) / (Main.npc[l].Center - Projectile.Center).Length() * Main.rand.NextFloat(0.85f, 1.15f) * 25f;
                v = v.RotatedBy(Main.rand.NextFloat(-0.3f, 0.3f));
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("WindBall"), projectile.damage * 2 / 3, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (l != -1)
            { 
                Projectile.velocity *= 0.98f;
            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int k = Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, 0, 612, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - Projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 10)
                {
                    Main.npc[i].StrikeNPC((int)(Projectile.damage / 6f), 0, 1);
                }
            }
            Main.projectile[k].timeLeft = 30;
            target.AddBuff(189, 400, false);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 150, 150));
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = Mod.GetTexture("Projectiles/projectile4/GoldBird");
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            if(Projectile.velocity.Length() > 10)
            {
                if((Projectile.velocity.Length() - 10) / 40f > 1)
                {
                    Main.spriteBatch.Draw(texture2D, Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle(0, Projectile.frame * Projectile.height, Projectile.width,Projectile.height), new Color(1f, 1f, 1f, 0), base.Projectile.rotation, new Vector2((float)Projectile.width / 2f, (float)Projectile.height / 2f), base.Projectile.scale, effects, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture2D, Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle(0, Projectile.frame * Projectile.height, Projectile.width, Projectile.height), new Color((Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, 0), base.Projectile.rotation, new Vector2((float)Projectile.width / 2f, (float)Projectile.height / 2f), base.Projectile.scale, effects, 0f);
                }
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawOrigin = new Vector2(texture2D.Width * 0.5f, texture2D.Height * 0.5f);
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + new Vector2(1f, Projectile.gfxOffY) + new Vector2(14, 16);
                    Color color = new Color((Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, 0) * ((40 - k) / 40f);
                    //color.A = 0;
                    spriteBatch.Draw(texture2D, drawPos, new Rectangle(0, Projectile.frame * Projectile.height, Projectile.width, Projectile.height), color, Projectile.rotation, new Vector2((float)Projectile.width / 2f, (float)Projectile.height / 2f), Projectile.scale * (80 - k) / 80f, effects, 0f);
                }
            }
            return true;
        }
    }
}
