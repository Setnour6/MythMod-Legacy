using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
            Main.projFrames[base.Projectile.type] = 10;
        }
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 36;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.minionSlots = 3f;
            Projectile.aiStyle = 67;
            Projectile.timeLeft = 720000;
            this.AIType = -1;
            Projectile.penetrate = -1;
            Projectile.minion = true;
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            Projectile.friendly = true;
            bool flag2 = base.Projectile.type == base.Mod.Find<ModProjectile>("IcyAnimal").Type;
            Player player = Main.player[base.Projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (flag2)
            {
                if (player.dead)
                {
                    modPlayer.IcyAnimal = false;
                }
                if (!player.HasBuff(Mod.Find<ModBuff>("IcyAnimal").Type))
                {
                    base.Projectile.Kill();
                }
            }
            if(Projectile.velocity.X > 0)
            {
                Projectile.spriteDirection = 1;
            }
            if (Projectile.velocity.X < 0)
            {
                Projectile.spriteDirection = -1;
            }
            if (Projectile.velocity.X == 0)
            {
                Projectile.spriteDirection = (int)((Projectile.Center.X - player.Center.X) / (Math.Abs(Projectile.Center.X - player.Center.X) + 0.000001f));
            }
            bool flag = false;
            bool Fl1 = false;
            bool Fl2 = false;
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            Vector2 v = new Vector2(0, 0);
            float num4 = 1000f;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    v = Main.npc[j].Center + new Vector2(0, -50);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4 && !(Fl1Time > 0))
                    {
                        if(Main.npc[j].Center.Y <= Projectile.Center.Y && Projectile.Center.Y - Main.npc[j].Center.Y < Math.Abs(Projectile.Center.X - Main.npc[j].Center.X) && OTileX == 1)
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
                    Projectile.tileCollide = false;
                    Projectile.rotation += 0.5f;
                    float num8 = 30f;
                    Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                    float num9 = num2 - vector3.X;
                    float num10 = num3 - vector3.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / (num11 + 0.0000001f);
                    num9 *= num11;
                    num10 *= num11;
                    base.Projectile.velocity.X = (base.Projectile.velocity.X * 25f + num9) / 26f;
                    base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 25f + num10) / 26f;
                    num12 += 1;
                    Projectile.frame = 8;
                }
                if (Fl1)
                {
                    Fl1Time -= 1;
                    if(OTileX == 1)
                    {
                        Projectile.velocity = (v - Projectile.Center) / ((v - Projectile.Center).Length() + 0.0001f) * 40f;
                        OTileX = 0;
                        Projectile.tileCollide = false;
                    }
                    if (Projectile.timeLeft % (int)(30 / (Projectile.velocity.Length() + 0.0001f) + 0.5f) == 0 && !flag && Projectile.velocity.Length() > 1f)
                    {
                        if (Projectile.frame < 7)
                        {
                            Projectile.frame += 1;
                        }
                        else
                        {
                            Projectile.frame = 0;
                        }
                    }
                    Projectile.velocity.Y += 0.5f;
                }
            }
            else
            {
                int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                float num6 = (Main.player[num5].Center - Projectile.Center).Length();

                if ((Main.player[num5].Center - Projectile.Center).Length() > 200)
                {
                    Projectile.tileCollide = false;
                    Projectile.rotation += 0.5f;
                    float num8 = 30f;
                    Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                    float num9 = Main.player[num5].Center.X - vector3.X;
                    float num10 = Main.player[num5].Center.Y - vector3.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / (num11 + 0.00000001f);
                    num9 *= num11;
                    num10 *= num11;
                    base.Projectile.velocity.X = (base.Projectile.velocity.X * 25f + num9) / 26f;
                    base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 25f + num10) / 26f;
                    num12 += 1;
                    Projectile.frame = 8;
                }
                else
                {
                    Projectile.rotation = 0;
                    if(Projectile.Center.Y < player.Center.Y)
                    {
                        Projectile.tileCollide = true;
                    }
                    if (Projectile.timeLeft % (int)(30 / (Projectile.velocity.Length() + 0.0001f) + 0.5f) == 0 && !flag && Projectile.velocity.Length() > 1f)
                    {
                        if (Projectile.frame < 7)
                        {
                            Projectile.frame += 1;
                        }
                        else
                        {
                            Projectile.frame = 0;
                        }
                    }
                    if (Projectile.velocity.Length() <= 1f)
                    {
                        Projectile.frame = 0;
                    }
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f - 6), base.Projectile.scale, effects, 0f);
            if(Projectile.velocity.Length() > 0.5f)
            {
                Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                    Color color = (Color.White * 0.2f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    //color.A = 0;
                    spriteBatch.Draw(texture2D, drawPos, new Rectangle(0, 36 * Projectile.frame, texture2D.Width, 36), color, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0f);
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
