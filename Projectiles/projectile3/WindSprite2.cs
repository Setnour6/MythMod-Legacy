using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            bool flag2 = Projectile.type == Mod.Find<ModProjectile>("WindSprite1").Type;
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (Projectile.active)
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
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("WindBall").Type, Projectile.damage * 2 / 3, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (l != -1)
            { 
                Projectile.velocity *= 0.98f;
            }

        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = Mod.GetTexture("Projectiles/projectile3/WindLoop");
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            if(Projectile.velocity.Length() > 10)
            {
                if((Projectile.velocity.Length() - 10) / 40f > 1)
                {
                    Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), null, new Color(1f, 1f, 1f, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)texture2D.Height / 2f), base.Projectile.scale, effects, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), null, new Color((Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)texture2D.Height / 2f), base.Projectile.scale, effects, 0f);
                }
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawOrigin = new Vector2(texture2D.Width * 0.5f, texture2D.Height * 0.5f);
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                    Color color = new Color((Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, (Projectile.velocity.Length() - 10) / 40f, 0) * ((40 - k) / 40f);
                    //color.A = 0;
                    spriteBatch.Draw(texture2D, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale * (80 - k) / 80f, effects, 0f);
                }
            }
            return true;
        }
    }
}
