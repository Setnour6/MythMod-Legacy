using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile3
{
    public class BloodGold : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("暗金屠杀刃");
        }
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 400;
            Projectile.alpha = 255;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            if (Projectile.timeLeft > 350)
            {
                Projectile.velocity *= 0.5f;
                Projectile.rotation += Omega;
                Projectile.alpha -= 5;
                Omega += 0.02f;
            }
            else
            {
                if(Projectile.timeLeft <= 350 && initialization)
                {
                    int l = -1;
                    for (int i = 0; i < 200; i++)
                    {
                        float Dist = (Main.npc[i].Center - Projectile.Center).Length();
                        if (!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].active && Main.npc[i].CanBeChasedBy() && Dist < 600)
                        {
                            if(l == -1)
                            {
                                l = i;
                            }
                            else if ((Main.npc[i].Center - Projectile.Center).Length() < (Main.npc[l].Center - Projectile.Center).Length())
                            {
                                l = i;
                            }
                        }
                    }
                    if (l != -1)
                    {
                        Projectile.velocity = ((Main.npc[l].Center - Projectile.Center) / (Main.npc[l].Center - Projectile.Center).Length() * 45f);
                        Omega = 0;
                        initialization = false;
                    }
                    else
                    {
                        Projectile.velocity *= 0;
                    }
                }
                if(Projectile.velocity.Length() > 0)
                {
                    Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y * - Projectile.spriteDirection, Projectile.velocity.X * -Projectile.spriteDirection));
                }
                else
                {
                    Projectile.rotation += Omega;
                }
                Projectile.velocity *= 0.975f;
                if (Projectile.timeLeft < 52)
                {
                    Projectile.alpha += 5;
                    Projectile.tileCollide = false;
                }
            }
            if (Projectile.timeLeft < 52)
            {
                Projectile.alpha += 5;
            }
            Projectile.spriteDirection = (int)Projectile.ai[0];
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.timeLeft > 55)
            {
                Projectile.timeLeft = 55;
            }
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void Kill(int timeLeft)
        {
            if(Projectile.timeLeft > 1)
            {
                for (int i = 0; i <= 32; i++)
                {
                    float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 120f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 120f;
                    int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("RedGemDust").Type, (int)((double)base.Projectile.damage * 0.1f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
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
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            float p = (255 - Projectile.alpha) / 255f;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, new Color(p, p, p, (1 - p) / 255f), Projectile.rotation, new Vector2(19, 21), Projectile.scale, effects, 0f);
            for (int i = 0; i < 15; i++)
            {
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 0.25f), Projectile.rotation, new Vector2(19, 21), Projectile.scale, effects, 0f);
            }
            if(Projectile.velocity.Length() < 1 && Projectile.timeLeft > 240 && initialization)
            {
                for (int i = 0; i < 15; i++)
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 0.25f), Projectile.rotation - Omega * i * 0.1f, new Vector2(19, 21), Projectile.scale, effects, 0f);
                }
            }
            if(Projectile.velocity.Length() == 0 && Projectile.timeLeft <= 240 && initialization)
            {
                for (int i = 0; i < Projectile.timeLeft / 16; i++)
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 0.25f), Projectile.rotation - Omega * i * 0.1f, new Vector2(19, 21), Projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}