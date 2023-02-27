using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;

namespace MythMod.Projectiles.Clubs
{
    public class FreezingPlusClub : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("冰封耀天极");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 64;
            base.projectile.height = 64;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 2;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
            projectile.frame = 0;
        }
        private int lz = 0;
        public override void AI()
        {
            lz += 1;
            base.projectile.rotation += 0.4f;
            Player p = Main.player[Main.myPlayer];
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.position + v + new Vector2(-(projectile.width / 2 - p.width / 2), -10);
            projectile.spriteDirection = p.direction;
            if (projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.projectile.timeLeft = 2;
            }
            if (p.dead)
            {
                projectile.Kill();
            }
            if (lz % 3 == 1)
            {
                projectile.friendly = true;
            }
            else
            {
                projectile.friendly = false;
            }
            if (lz % 20 == 19)
            {
                Vector2 vk = new Vector2((float)Main.screenPosition.X + Main.mouseX - p.Center.X, (float)Main.screenPosition.Y + Main.mouseY - p.Center.Y);
                vk = vk / vk.Length() * 8f;
                int i = Projectile.NewProjectile(p.Center.X + vk.X, p.Center.Y + vk.Y, vk.X, vk.Y, mod.ProjectileType("FreezeClub2"), projectile.damage, projectile.knockBack * 0.5f, p.whoAmI, 0, 0);
            }
            if (lz % 2 == 1)
            {
                Vector2 vk = new Vector2((float)Main.screenPosition.X + Main.mouseX - p.Center.X, (float)Main.screenPosition.Y + Main.mouseY - p.Center.Y).RotatedBy(-Main.time / 4f);
                vk = vk / vk.Length() * 34f;
                int i = Projectile.NewProjectile(p.Center.X + vk.X, p.Center.Y + vk.Y, vk.X, vk.Y, 337, projectile.damage, projectile.knockBack * 0.5f, p.whoAmI, 0, 0);
                Main.projectile[i].hostile = false;
                Main.projectile[i].friendly = true;
                int i2 = Projectile.NewProjectile(p.Center.X + vk.X, p.Center.Y + vk.Y, -vk.X, -vk.Y, 337, projectile.damage, projectile.knockBack * 0.5f, p.whoAmI, 0, 0);
                Main.projectile[i2].hostile = false;
                Main.projectile[i2].friendly = true;
            }
            float li = Main.rand.NextFloat(-32f,32f);
            int num25 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4) + new Vector2(li, li).RotatedBy(projectile.rotation), 0, 0, 20, 0, 0, 0, default(Color), 2f);
            Main.dust[num25].noGravity = true;
            Main.dust[num25].velocity = new Vector2(li, li).RotatedBy(Math.PI / 2 + projectile.rotation) * 0.15f;
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Player p = Main.player[Main.myPlayer];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(32, 32), projectile.scale, effects, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(15) == 1)
            {
                target.AddBuff(47, 150);
                target.AddBuff(46, 150);
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("千年桔树妖之眼"))
                {
                    target.AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                    target.AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                        }
                    }
                }
            }
        }
    }
}
