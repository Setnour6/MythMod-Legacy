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

namespace MythMod.Projectiles.Effects
{
    public class OrangeVortex : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("OrangeVortex");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 50;
            base.Projectile.height = 50;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 60;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
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
                Projectile.timeLeft = E;
            }
            else
            {
                if(E > 2)
                {
                    E -= 1;
                    Projectile.timeLeft = E;
                }
                else
                {
                    mplayer.Ost = true;
                    Projectile.Kill();
                }
            }
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.Center + v;
            Projectile.spriteDirection = p.direction;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            if (mplayer.SD2 > 0 && mplayer.SD == 5)
            {
                base.Projectile.timeLeft = 2;
            }
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            float Lig = 1;
            for (int step = 1; step < 40; step++)
            {
                Lighting.AddLight(base.Projectile.Center + step * Projectile.velocity, (float)(255 - base.Projectile.alpha) * 1.2f / 255f * (40 - (float)step) / 40f * Lig, (float)(255 - base.Projectile.alpha) * 0.8f / 255f * (40 - (float)step) / 40f * Lig, (float)(255 - base.Projectile.alpha) * 0f / 255f * (40 - (float)step) / 40f * Lig);
            }
            p.direction = Projectile.spriteDirection;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            float nu = (float)Math.Sin(D / 20f) * 0.15f + 1;
            float nv = (float)Math.Sin(D / 40f) * 0.06f;
            Vector2 v = Projectile.velocity * 5;
            for(int i = 0;i < 5;i++)
            {
                Vector2 v1 = new Vector2(v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).X, v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).Y / 3f);
                Vector2 v2 = v1.RotatedBy(Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + Math.PI * 0.5f + nv) * nu;
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY) + v + v2 - new Vector2(25,25), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(0.95f, 0.45f, 0,0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), 0.5f / 60f * (float)E, SpriteEffects.None, 0f);
            }
            float nu2 = (float)Math.Cos(D / 20f) * 0.15f + 1;
            float nv2 = (float)Math.Cos(D / 40f) * 0.06f;
            Vector2 v3 = Projectile.velocity * 4;
            for (int i = 0; i < 5; i++)
            {
                Vector2 v5 = new Vector2(v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).X, v.RotatedBy((D / 4f + Math.PI * 2 / 5f * i)).Y / 3f);
                Vector2 v4 = v5.RotatedBy(Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + Math.PI * 0.5f + nv2) * nu2;
                Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/Effects/GreenVortex"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY) + v3 + v4 - new Vector2(25, 25), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(0.95f, 0.45f, 0, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), 0.3f / 60f * (float)E, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
