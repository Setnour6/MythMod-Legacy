using Terraria.GameContent;
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
            Main.projFrames[base.Projectile.type] = 5;
        }

        // Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
        public override void SetDefaults()
        {
            base.Projectile.width = 50;
            base.Projectile.height = 200;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.DamageType = DamageClass.Magic;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 400;
            base.Projectile.alpha = 0;
            base.Projectile.tileCollide = false;
        }
        // Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
        public override void AI()
        {
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].type == Mod.Find<ModNPC>("OceanCrystal").Type)
                {
                    Projectile.Center = Main.npc[j].Center;
                }
            }
            if (num6)
            {
                num7 = Main.rand.Next(4);
                num6 = false;
                vector3 = base.Projectile.Center;
                base.Projectile.frame = 4;
            }
            if (base.Projectile.timeLeft < 400 && base.Projectile.timeLeft % 5 == 0 && base.Projectile.frame > 0 && base.Projectile.timeLeft > 250)
            {
                base.Projectile.frame--;
            }
            if (base.Projectile.timeLeft < 30 && base.Projectile.timeLeft % 5 == 0 && base.Projectile.frame < 4)
            {
                base.Projectile.frame++;
            }
            if (Projectile.timeLeft < 12 && Projectile.timeLeft > 388)
            {
                Projectile.hostile = false;
            }
            else
            {
                Projectile.hostile = true;
            }
            Projectile.velocity = Projectile.velocity.RotatedBy(-0.04f);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.Projectile.timeLeft >= 24)
            {
                num2 += 0.0014f;
            }
            if (base.Projectile.timeLeft >= 18 && base.Projectile.timeLeft < 24)
            {
                num2 -= 0.0022f;
            }
            if (base.Projectile.timeLeft >= 6 && base.Projectile.timeLeft < 18)
            {
                num2 += 0.006f;
            }
            if (base.Projectile.timeLeft < 6)
            {
                num2 -= 0.01f;
            }
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override bool PreDraw(ref Color lightColor)
        {
            float maxDistance = 5000f;
            float step = 40f;
            Vector2 unit = Projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation();
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            for (float i = 0; i < maxDistance; i += step)
            {
                Texture2D texture;
                if (i == 0)
                {
                    texture = base.Mod.GetTexture("Projectiles/projectile2/剧毒射线发射端");
                }
                else
                {
                    texture = TextureAssets.Projectile[Projectile.type].Value;
                }
                if (i > 0)
                {
                    spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, base.Projectile.Center + unit * (i + 60) - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.Projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                }
                if (i == 0 && Projectile.timeLeft > 60)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/剧毒射线发射端"), base.Projectile.Center + unit * (i + 110) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 50, 50)), base.Projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                }
                if (i == 0 && Projectile.timeLeft <= 60)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/剧毒射线发射端"), base.Projectile.Center + unit * (i + 110) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 50, 50)), base.Projectile.GetAlpha(lightColor) * Projectile.timeLeft * (255 / 60f), r - (float)Math.PI / 2f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影1"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / 20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/剧毒射线发射端幻影2"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 100, 100)), base.projectile.GetAlpha(lightColor) * projectile.timeLeft * (255 / 60f), projectile.timeLeft / -20f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1.6f, SpriteEffects.None, 0f);
                }
                if (Main.rand.Next(55) == 1 && i < 2000)
                {
                    Projectile.NewProjectile((base.Projectile.Center + unit * (i + 105)).X, (base.Projectile.Center + unit * (i + 110)).Y, base.Projectile.velocity.Y * 0.01f * i, -base.Projectile.velocity.X * 0.01f * i, base.Mod.Find<ModProjectile>("PoisonBubblePurple").Type, 130, 0, Main.myPlayer, 0f, 0f);
                }
            }
            return false;
        }
        public override void CutTiles()
        {
            Vector2 unit = Projectile.velocity;
            Terraria.Utils.PlotTileLine(base.Projectile.Center, base.Projectile.Center + unit * Distance, (Projectile.width + 16) * Projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), base.Projectile.Center, base.Projectile.Center + unit * Distance * 40, 50, ref point);
        }
    }
}
