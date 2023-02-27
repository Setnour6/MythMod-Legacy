using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
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
            DisplayName.SetDefault("浩劫轮回");
        }
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.scale = 1f;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            if (projectile.timeLeft > 350)
            {
                projectile.velocity *= 0.5f;
                projectile.rotation += Omega;
                projectile.alpha -= 5;
                Omega += 0.02f;
            }
            else
            {
                if(projectile.timeLeft == 350)
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
                            else if ((Main.npc[i].Center - projectile.Center).Length() < (Main.npc[l].Center - projectile.Center).Length())
                            {
                                l = i;
                            }
                        }
                    }
                    if (l != -1)
                    {
                        projectile.velocity = ((Main.npc[l].Center - projectile.Center) / (Main.npc[l].Center - projectile.Center).Length() * 45f);
                    }
                    else
                    {
                        projectile.velocity *= 0;
                    }
                }
                if(projectile.velocity.Length() > 0)
                {
                    projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y * - projectile.spriteDirection, projectile.velocity.X * -projectile.spriteDirection));
                }
                else
                {
                    projectile.rotation += Omega;
                }
                projectile.velocity *= 0.975f;
                if (projectile.timeLeft < 52)
                {
                    projectile.alpha += 5;
                    projectile.tileCollide = false;
                }
            }
            if (projectile.timeLeft < 52)
            {
                projectile.alpha += 5;
            }
            projectile.spriteDirection = (int)projectile.ai[0];
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.timeLeft > 55)
            {
                projectile.timeLeft = 55;
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            float p = (255 - projectile.alpha) / 255f;
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, new Color(p, p, p, (1 - p) / 255f), projectile.rotation, new Vector2(55, 55), projectile.scale, effects, 0f);
            for (int i = 0; i < 15; i++)
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, (1 - 1 / 15f * (float)i) * projectile.alpha / 255f), projectile.rotation, new Vector2(55, 55), projectile.scale, effects, 0f);
            }
            if(projectile.velocity.Length() < 1 && projectile.timeLeft > 240)
            {
                for (int i = 0; i < 15; i++)
                {
                    Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i / 15f, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, (1 - 1 / 15f * (float)i) * projectile.alpha / 255f), projectile.rotation - Omega * i * 0.1f, new Vector2(55, 55), projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}