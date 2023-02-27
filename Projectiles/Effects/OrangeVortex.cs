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

namespace MythMod.Projectiles.Effects
{
    public class OrangeVortex : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("OrangeVortex");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 50;
            base.projectile.height = 50;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 60;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private float num4;
        private int ML = 0;
        private int D = 0;
        private int E = 1;
        private int MR = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            D += 1;
            if(Main.mouseLeft && E < 60 && p.statMana > 13)
            {
                E += 1;
                projectile.timeLeft = E;
            }
            else
            {
                if(E > 2)
                {
                    E -= 1;
                    projectile.timeLeft = E;
                }
                else
                {
                    mplayer.Ost = true;
                    projectile.Kill();
                }
            }
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.Center + v;
            projectile.spriteDirection = p.direction;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            if (mplayer.SD2 > 0 && mplayer.SD == 5)
            {
                base.projectile.timeLeft = 2;
            }
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            float Lig = 1;
            for (int step = 1; step < 40; step++)
            {
                Lighting.AddLight(base.projectile.Center + step * projectile.velocity, (float)(255 - base.projectile.alpha) * 1.2f / 255f * (40 - (float)step) / 40f * Lig, (float)(255 - base.projectile.alpha) * 0.8f / 255f * (40 - (float)step) / 40f * Lig, (float)(255 - base.projectile.alpha) * 0f / 255f * (40 - (float)step) / 40f * Lig);
            }
            p.direction = projectile.spriteDirection;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            float nu = (float)Math.Sin(D / 20f) * 0.15f + 1;
            float nv = (float)Math.Sin(D / 40f) * 0.06f;
            Vector2 v = projectile.velocity * 5;
            for(int i = 0;i < 5;i++)
            {
                Vector2 v1 = new Vector2(v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).X, v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).Y / 3f);
                Vector2 v2 = v1.RotatedBy(Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + Math.PI * 0.5f + nv) * nu;
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + v + v2 - new Vector2(25,25), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(0.95f, 0.45f, 0,0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), 0.5f / 60f * (float)E, SpriteEffects.None, 0f);
            }
            float nu2 = (float)Math.Cos(D / 20f) * 0.15f + 1;
            float nv2 = (float)Math.Cos(D / 40f) * 0.06f;
            Vector2 v3 = projectile.velocity * 4;
            for (int i = 0; i < 5; i++)
            {
                Vector2 v5 = new Vector2(v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).X, v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).Y / 3f);
                Vector2 v4 = v5.RotatedBy(Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + Math.PI * 0.5f + nv2) * nu2;
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/Effects/GreenVortex"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + v3 + v4 - new Vector2(25, 25), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(0.95f, 0.45f, 0, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), 0.3f / 60f * (float)E, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
