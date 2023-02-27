using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Projectiles.projectile2
{
    // Token: 0x020007D0 RID: 2000
    public class PoisonRayPurple : ModProjectile
    {
        // Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
        private float num4;
        private bool num5 = true;
        private float num7 = 0;
        private float num2 = 0;
        private bool num6 = true;
        private Vector2 vector3;
        private float Distance;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("剧毒射线");
            Main.projFrames[base.projectile.type] = 5;
        }

        // Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
        public override void SetDefaults()
        {
            base.projectile.width = 50;
            base.projectile.height = 200;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.magic = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 400;
            base.projectile.alpha = 0;
            base.projectile.tileCollide = false;
        }
        // Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
        public override void AI()
        {
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].type == mod.NPCType("OceanCrystal"))
                {
                    projectile.Center = Main.npc[j].Center;
                }
            }
            if (num6)
            {
                num7 = Main.rand.Next(4);
                num6 = false;
                vector3 = base.projectile.Center;
                base.projectile.frame = 4;
            }
            if (base.projectile.timeLeft < 400 && base.projectile.timeLeft % 5 == 0 && base.projectile.frame > 0 && base.projectile.timeLeft > 250)
            {
                base.projectile.frame--;
            }
            if (base.projectile.timeLeft < 30 && base.projectile.timeLeft % 5 == 0 && base.projectile.frame < 4)
            {
                base.projectile.frame++;
            }
            if (projectile.timeLeft < 12 && projectile.timeLeft > 388)
            {
                projectile.hostile = false;
            }
            else
            {
                projectile.hostile = true;
            }
            projectile.velocity = projectile.velocity.RotatedBy(-0.04f);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.projectile.timeLeft >= 24)
            {
                num2 += 0.0014f;
            }
            if (base.projectile.timeLeft >= 18 && base.projectile.timeLeft < 24)
            {
                num2 -= 0.0022f;
            }
            if (base.projectile.timeLeft >= 6 && base.projectile.timeLeft < 18)
            {
                num2 += 0.006f;
            }
            if (base.projectile.timeLeft < 6)
            {
                num2 -= 0.01f;
            }
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float maxDistance = 5000f;
            float step = 40f;
            Vector2 unit = projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation();
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            for (float i = 0; i < maxDistance; i += step)
            {
                Texture2D texture;
                if (i == 0)
                {
                    texture = base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端");
                }
                else
                {
                    texture = Main.projectileTexture[projectile.type];
                }
                if (i > 0)
                {
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], base.projectile.Center + unit * (i + 60) - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                }
                if (i == 0 && projectile.timeLeft > 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端"), base.projectile.Center + unit * (i + 110) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 50, 50)), base.projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                }
                if (i == 0 && projectile.timeLeft <= 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端"), base.projectile.Center + unit * (i + 110) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 50, 50)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), r - (float)Math.PI / 2f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                }
                if (Main.rand.Next(55) == 1 && i < 2000)
                {
                    Projectile.NewProjectile((base.projectile.Center + unit * (i + 105)).X, (base.projectile.Center + unit * (i + 110)).Y, base.projectile.velocity.Y * 0.01f * i, -base.projectile.velocity.X * 0.01f * i, base.mod.ProjectileType("PoisonBubblePurple"), 130, 0, Main.myPlayer, 0f, 0f);
                }
            }
            return false;
        }
        public override void CutTiles()
        {
            Vector2 unit = projectile.velocity;
            Terraria.Utils.PlotTileLine(base.projectile.Center, base.projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 unit = projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), base.projectile.Center, base.projectile.Center + unit * Distance * 40, 50, ref point);
        }
    }
}
