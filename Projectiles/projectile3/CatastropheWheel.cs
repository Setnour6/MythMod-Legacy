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
    public class CatastropheWheel : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("浩劫轮回");
        }
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 400;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
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
                if(Projectile.timeLeft == 350)
                {
                    int l = -1;
                    for (int i = 0; i < 200; i++)
                    {
                        if (!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].active)
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
            base.OnHitNPC(target, damage, knockback, crit);
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
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, new Color(p, p, p, (1 - p) / 255f), Projectile.rotation, new Vector2(55, 55), Projectile.scale, effects, 0f);
            for (int i = 0; i < 15; i++)
            {
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, (1 - 1 / 15f * (float)i) * Projectile.alpha / 255f), Projectile.rotation, new Vector2(55, 55), Projectile.scale, effects, 0f);
            }
            if(Projectile.velocity.Length() < 1 && Projectile.timeLeft > 240)
            {
                for (int i = 0; i < 15; i++)
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, (1 - 1 / 15f * (float)i) * Projectile.alpha / 255f), Projectile.rotation - Omega * i * 0.1f, new Vector2(55, 55), Projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}