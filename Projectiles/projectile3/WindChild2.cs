using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("风之子");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 54;
            base.Projectile.height = 54;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 20;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
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
                if (Projectile.frame < 5)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
            Vector2 v2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v2 = v2 / v2.Length();
            Projectile.velocity = v2 * 15f;
            Projectile.position = p.Center + v2 - new Vector2(27, 27);
            Projectile.spriteDirection = p.direction;
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            if(Main.mouseRight)
            {
                Projectile.timeLeft = 2;
            }
            for (int u = 0; u < 20; u++)
            {
                int r = Dust.NewDust(Main.screenPosition + new Vector2(Main.mouseX - 400, Main.mouseY - 400), 800, 800, Mod.Find<ModDust>("Wind").Type, 0, 0, 0, default(Color), 1.5f);
            }
            int y = -1;
            for(int i = 0;i < 1000;i++)
            {
                if(Main.projectile[i].type == Mod.Find<ModProjectile>("WindChild2").Type)
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
                Projectile.Kill();
            }
            for (int m = 0; m < 200; m++)
            {
                if ((Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length() <= 300 && Main.npc[m].friendly == false && Main.npc[m].dontTakeDamage == false)
                {
                    Main.npc[m].velocity += ((new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition) - Main.npc[m].Center) / (Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length() * (300 - (Main.npc[m].Center - (new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition)).Length()) * 10f / (Main.npc[m].height * Main.npc[m].width);
                }
            }
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
                Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
                int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
                int y = num * base.Projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255, 255, 255, 0), base.Projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
            }
            else
            {
                Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
                int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
                int y = num * base.Projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255,255,255,0), base.Projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, effects, 0f);
            }
            return false;
        }
    }
}
