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

namespace MythMod.Projectiles.projectile3
{
    public class WindChild2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("风之子");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 54;
            base.projectile.height = 54;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 20;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private float num4;
        private float Dx = 0;
        private int k = 0;
        private int l = 0;
        private int D = -1;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.WindC = 2;
            //p.statLife = mplayer.WindC;
            if (Main.time % 8 == 1)
            {
                if (projectile.frame < 5)
                {
                    projectile.frame += 1;
                }
                else
                {
                    projectile.frame = 0;
                }
            }
            Vector2 v2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v2 = v2 / v2.Length();
            projectile.velocity = v2 * 15f;
            projectile.position = p.Center + v2 - new Vector2(27, 27);
            projectile.spriteDirection = p.direction;
            Player player = Main.player[projectile.owner];
            projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            if(Main.mouseRight)
            {
                projectile.timeLeft = 2;
            }
            for (int u = 0; u < 20; u++)
            {
                int r = Dust.NewDust(Main.screenPosition + new Vector2(Main.mouseX - 400, Main.mouseY - 400), 800, 800, mod.DustType("Wind"), 0, 0, 0, default(Color), 1.5f);
            }
            int y = -1;
            for(int i = 0;i < 1000;i++)
            {
                if(Main.projectile[i].type == mod.ProjectileType("WindChild2"))
                {
                    if(y != -1)
                    {
                        Main.projectile[i].Kill();
                        y = i;
                    }
                    else
                    {
                        y = i;
                    }
                }
            }
            if(player.statMana <= 2)
            {
                projectile.Kill();
            }
            for (int m = 0; m < 200; m++)
            {
                if ((Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length() <= 300 && Main.npc[m].friendly == false && Main.npc[m].dontTakeDamage == false)
                {
                    Main.npc[m].velocity += ((new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition) - Main.npc[m].Center) / (Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length() * (300 - (Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length()) * 10f / (Main.npc[m].height * Main.npc[m].width);
                }
            }
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
                int y = num * base.projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255, 255, 255, 0), base.projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
            }
            else
            {
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
                int y = num * base.projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255,255,255,0), base.projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
            }
            return false;
        }
    }
}
