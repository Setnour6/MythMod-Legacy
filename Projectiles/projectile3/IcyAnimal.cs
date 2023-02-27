using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class IcyAnimal : ModProjectile
    {
        private float num = 0;
        private float num16 = 0;
        private float num12 = 0;
        private int num18 = 0;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("冰晶雪兽");
            ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
            Main.projFrames[base.projectile.type] = 10;
        }
        public override void SetDefaults()
        {
            projectile.width = 54;
            projectile.height = 36;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 3f;
            projectile.aiStyle = 67;
            projectile.timeLeft = 720000;
            this.aiType = -1;
            projectile.penetrate = -1;
            projectile.minion = true;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        private int OTileX = 0;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            OTileX = 1;
            return false;
        }
        private int Fl1Time = 0;
        public override void AI()
        {
            projectile.friendly = true;
            bool flag2 = base.projectile.type == base.mod.ProjectileType("IcyAnimal");
            Player player = Main.player[base.projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (flag2)
            {
                if (player.dead)
                {
                    modPlayer.IcyAnimal = false;
                }
                if (!player.HasBuff(mod.BuffType("IcyAnimal")))
                {
                    base.projectile.Kill();
                }
            }
            if(projectile.velocity.X > 0)
            {
                projectile.spriteDirection = 1;
            }
            if (projectile.velocity.X < 0)
            {
                projectile.spriteDirection = -1;
            }
            if (projectile.velocity.X == 0)
            {
                projectile.spriteDirection = (int)((projectile.Center.X - player.Center.X) / (Math.Abs(projectile.Center.X - player.Center.X) + 0.000001f));
            }
            bool flag = false;
            bool Fl1 = false;
            bool Fl2 = false;
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            Vector2 v = new Vector2(0, 0);
            float num4 = 1000f;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    v = Main.npc[j].Center + new Vector2(0, -50);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4 && !(Fl1Time > 0))
                    {
                        if(Main.npc[j].Center.Y <= projectile.Center.Y && projectile.Center.Y - Main.npc[j].Center.Y < Math.Abs(projectile.Center.X - Main.npc[j].Center.X) && OTileX == 1)
                        {
                            Fl1 = true;
                            Fl1Time = 15;
                        }
                        else
                        {
                            Fl2 = true;
                        }
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                    if (Fl1Time > 0)
                    {
                        Fl1 = true;
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
                else
                {
                }
            }
            if (flag)
            {
                if(Fl2)
                {
                    projectile.tileCollide = false;
                    projectile.rotation += 0.5f;
                    float num8 = 30f;
                    Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                    float num9 = num2 - vector3.X;
                    float num10 = num3 - vector3.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / (num11 + 0.0000001f);
                    num9 *= num11;
                    num10 *= num11;
                    base.projectile.velocity.X = (base.projectile.velocity.X * 25f + num9) / 26f;
                    base.projectile.velocity.Y = (base.projectile.velocity.Y * 25f + num10) / 26f;
                    num12 += 1;
                    projectile.frame = 8;
                }
                if (Fl1)
                {
                    Fl1Time -= 1;
                    if(OTileX == 1)
                    {
                        projectile.velocity = (v - projectile.Center) / ((v - projectile.Center).Length() + 0.0001f) * 40f;
                        OTileX = 0;
                        projectile.tileCollide = false;
                    }
                    if (projectile.timeLeft % (int)(30 / (projectile.velocity.Length() + 0.0001f) + 0.5f) == 0 && !flag && projectile.velocity.Length() > 1f)
                    {
                        if (projectile.frame < 7)
                        {
                            projectile.frame += 1;
                        }
                        else
                        {
                            projectile.frame = 0;
                        }
                    }
                    projectile.velocity.Y += 0.5f;
                }
            }
            else
            {
                int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                float num6 = (Main.player[num5].Center - projectile.Center).Length();

                if ((Main.player[num5].Center - projectile.Center).Length() > 200)
                {
                    projectile.tileCollide = false;
                    projectile.rotation += 0.5f;
                    float num8 = 30f;
                    Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                    float num9 = Main.player[num5].Center.X - vector3.X;
                    float num10 = Main.player[num5].Center.Y - vector3.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / (num11 + 0.00000001f);
                    num9 *= num11;
                    num10 *= num11;
                    base.projectile.velocity.X = (base.projectile.velocity.X * 25f + num9) / 26f;
                    base.projectile.velocity.Y = (base.projectile.velocity.Y * 25f + num10) / 26f;
                    num12 += 1;
                    projectile.frame = 8;
                }
                else
                {
                    projectile.rotation = 0;
                    if(projectile.Center.Y < player.Center.Y)
                    {
                        projectile.tileCollide = true;
                    }
                    if (projectile.timeLeft % (int)(30 / (projectile.velocity.Length() + 0.0001f) + 0.5f) == 0 && !flag && projectile.velocity.Length() > 1f)
                    {
                        if (projectile.frame < 7)
                        {
                            projectile.frame += 1;
                        }
                        else
                        {
                            projectile.frame = 0;
                        }
                    }
                    if (projectile.velocity.Length() <= 1f)
                    {
                        projectile.frame = 0;
                    }
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f - 6), base.projectile.scale, effects, 0f);
            if(projectile.velocity.Length() > 0.5f)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                    Color color = (Color.White * 0.2f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    //color.A = 0;
                    spriteBatch.Draw(texture2D, drawPos, new Rectangle(0, 36 * projectile.frame, texture2D.Width, 36), color, projectile.rotation, drawOrigin, projectile.scale, effects, 0f);
                }
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(44, 300);
        }
    }
}
