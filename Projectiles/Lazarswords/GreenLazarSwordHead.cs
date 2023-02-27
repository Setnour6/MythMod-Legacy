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

namespace MythMod.Projectiles.Lazarswords
{
    public class GreenLazarSwordHead : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("绿激光刃");
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 88;
            base.Projectile.height = 88;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 2;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            Projectile.DamageType = DamageClass.Melee;
            base.Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        private float num4;
        private float Dx = 0;
        private int k = 0;
        private int l = 0;
        private int D = -1;
        private Vector2 v = new Vector2(1 ,0);
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Projectile.frame = (int)((24 - Projectile.timeLeft) / 2f); 
            if (k == 0)
            {
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                k += 1;
            }
            v = v / v.Length();
            Projectile.velocity = v * 70f;
            Projectile.position = p.Center + v - new Vector2(44, 44);
            Projectile.spriteDirection = D;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            //p.ChangeDir(base.projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            if (Main.mouseLeft)
            {
                if(Dx < 300)
                {
                    Dx += 1f;
                }
                Projectile.alpha = 0;
                Projectile.timeLeft = 2;
                k = 1;
                l += 1;
                if(l <= 27)
                {
                    v = v.RotatedBy(0.1011f * D);
                }
                else
                {
                    if(Main.mouseX > Main.screenWidth / 2)
                    {
                        p.direction = 1;
                    }
                    else
                    {
                        p.direction = -1;
                    }
                    D = p.direction;
                    v = new Vector2(-D * 15f, -75);
                    l = 0;
                }
            }
            else
            {
                Dx = 0;
                Projectile.alpha = 255;
                Projectile.Kill();
                l = 0;
                k = 0;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (l != 0)
            {
                bool drawN = true;
                float maxDistance = 80f + Dx;
                Distance = 80f + Dx;
                float step = 4f;
                Vector2 unit = Projectile.velocity;
                unit.Normalize();
                float r = unit.ToRotation();
                int num = base.Mod.GetTexture("Projectiles/Lazarswords/GreenLazarSwordLazar").Height / Main.projFrames[base.Projectile.type];
                int y = num * base.Projectile.frame;
                for (float i = 0; i < maxDistance; i += step)
                {
                    Texture2D texture;
                    texture = base.Mod.GetTexture("Projectiles/Lazarswords/GreenLazarSwordLazar");
                    if (i > 0)
                    {
                        spriteBatch.Draw(texture, base.Projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 8, 8)), new Color(100, 100, 100, 0), r - (float)Math.PI / 4f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(base.Mod.GetTexture("Projectiles/Lazarswords/GreenLazarSwordLazar2"), base.Projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 32, 32)), new Color(20, 20, 20, 0), r - (float)Math.PI / 4f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                    }
                    float[] samples = new float[2];
                    Collision.LaserScan(Projectile.Center - v * 57f, unit, 1f, 80f + Dx, samples);
                    float maxDis = (samples[0] + samples[1]) * 0.5f;
                    if (maxDis < 80f + Dx)
                    {
                        int dustID = Dust.NewDust(base.Projectile.Center + unit * (maxDis - 42), 8, 8, 89, 0, 0, 201, Color.Green, 1.5f);/*粉尘效果不用管*/
                        Main.dust[dustID].noGravity = true;
                        maxDistance = maxDis;
                        Distance = maxDis;
                        drawN = false;
                    }
                    //Lighting.AddLight(projectile.Center + unit * (i) - Main.screenPosition, 0 / 255f, 0 / 255f, 255 / 255f * 0.25f);
                }
                if (drawN)
                {
                    for (float i = maxDistance; i < maxDistance + 38; i += 2)
                    {
                        Texture2D texture;
                        texture = base.Mod.GetTexture("Projectiles/Lazarswords/GreenLazarSwordLazar");
                        if (i > 0)
                        {
                            spriteBatch.Draw(texture, base.Projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 8, 8)), new Color(100, 100, 100, 0), r - (float)Math.PI / 4f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1 - (i - maxDistance) / 46f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/Lazarswords/GreenLazarSwordLazar2"), base.Projectile.Center + unit * (i + 1) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 32, 32)), new Color(20, 20, 20, 0), r - (float)Math.PI / 4f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1 - (i - maxDistance) / 46f, SpriteEffects.None, 0f);
                        }
                        float[] samples = new float[2];
                        Collision.LaserScan(Projectile.Center - v * 57, unit, 1f, 200f + Dx, samples);
                        float maxDis = (samples[0] + samples[1]) * 0.5f;
                        if (i > maxDis - 38)
                        {
                            for (int p = 0; p < 25; p++)
                            {
                                int dustID = Dust.NewDust(base.Projectile.Center + unit * (i - 42), 8, 8, 89, 0, 0, 201, Color.Green, 1.5f);
                                Main.dust[dustID].noGravity = true;
                            }
                            break;
                        }
                        //Lighting.AddLight(projectile.Center + unit * (i) - Main.screenPosition, 0 / 255f, 0 / 255f, 255 / 255f * 0.25f * (1 - (i - maxDistance) / 46f));
                    }
                }
            }
            return true;
        }
        public override void CutTiles()
        {
            Vector2 unit = Projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance / 70f + v * 70f, (Projectile.width + 16) * Projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * Distance / 70f + v * 70f,3, ref point);
        }
    }
}
