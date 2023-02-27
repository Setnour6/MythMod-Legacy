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

namespace MythMod.Projectiles.Lazarswords
{
    public class RedLazarSwordHead : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("红激光刃");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 88;
            base.projectile.height = 88;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 2;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            projectile.melee = true;
            base.projectile.tileCollide = false;
            projectile.alpha = 255;
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
            projectile.frame = (int)((24 - projectile.timeLeft) / 2f); 
            if (k == 0)
            {
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                k += 1;
            }
            v = v / v.Length();
            projectile.velocity = v * 70f;
            projectile.position = p.Center + v - new Vector2(44, 44);
            projectile.spriteDirection = D;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            //p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            if (Main.mouseLeft)
            {
                if(Dx < 300)
                {
                    Dx += 1f;
                }
                projectile.alpha = 0;
                projectile.timeLeft = 2;
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
                projectile.alpha = 255;
                projectile.Kill();
                l = 0;
                k = 0;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (l != 0)
            {
                bool drawN = true;
                float maxDistance = 80f + Dx;
                Distance = 80f + Dx;
                float step = 4f;
                Vector2 unit = projectile.velocity;
                unit.Normalize();
                float r = unit.ToRotation();
                int num = base.mod.GetTexture("Projectiles/Lazarswords/RedLazarSwordLazar").Height / Main.projFrames[base.projectile.type];
                int y = num * base.projectile.frame;
                for (float i = 0; i < maxDistance; i += step)
                {
                    Texture2D texture;
                    texture = base.mod.GetTexture("Projectiles/Lazarswords/RedLazarSwordLazar");
                    if (i > 0)
                    {
                        spriteBatch.Draw(texture, base.projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 8, 8)), new Color(100, 100, 100, 0), r - (float)Math.PI / 4f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(base.mod.GetTexture("Projectiles/Lazarswords/RedLazarSwordLazar2"), base.projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 32, 32)), new Color(20, 20, 20, 0), r - (float)Math.PI / 4f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f, SpriteEffects.None, 0f);
                    }
                    float[] samples = new float[2];
                    Collision.LaserScan(projectile.Center - v * 57f, unit, 1f, 80f + Dx, samples);
                    float maxDis = (samples[0] + samples[1]) * 0.5f;
                    if (maxDis < 80f + Dx)
                    {
                        int dustID = Dust.NewDust(base.projectile.Center + unit * (maxDis - 42), 8, 8, 90, 0, 0, 201, Color.White, 1.5f);/*粉尘效果不用管*/
                        Main.dust[dustID].noGravity = true;
                        maxDistance = maxDis;
                        Distance = maxDis;
                        drawN = false;

                        if (Main.rand.Next(6) == 1)
                        {
                            float num4 = (float)(Main.rand.Next(500, 8000) + 0.4f);
                            double num1 = Main.rand.Next(0, 1000) / 300f;
                            double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 540f;
                            double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 540f;
                            int num5 = Projectile.NewProjectile(base.projectile.Center.X + unit.X * (maxDis - 42), base.projectile.Center.Y + unit.Y * (maxDis - 42), (float)num2 * projectile.scale * 1.5f, (float)num3 * projectile.scale * 1.5f, base.mod.ProjectileType("RedGemDust2"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1750f;
                        }
                    }
                    //Lighting.AddLight(projectile.Center + unit * (i) - Main.screenPosition, 0 / 255f, 0 / 255f, 255 / 255f * 0.25f);
                }
                if (drawN)
                {
                    for (float i = maxDistance; i < maxDistance + 38; i += 2)
                    {
                        Texture2D texture;
                        texture = base.mod.GetTexture("Projectiles/Lazarswords/RedLazarSwordLazar");
                        if (i > 0)
                        {
                            spriteBatch.Draw(texture, base.projectile.Center + unit * (i) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 8, 8)), new Color(100, 100, 100, 0), r - (float)Math.PI / 4f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1 - (i - maxDistance) / 46f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(base.mod.GetTexture("Projectiles/Lazarswords/RedLazarSwordLazar2"), base.projectile.Center + unit * (i + 1) - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, 32, 32)), new Color(20, 20, 20, 0), r - (float)Math.PI / 4f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1 - (i - maxDistance) / 46f, SpriteEffects.None, 0f);
                        }
                        float[] samples = new float[2];
                        Collision.LaserScan(projectile.Center - v * 57, unit, 1f, 200f + Dx, samples);
                        float maxDis = (samples[0] + samples[1]) * 0.5f;
                        if (i > maxDis - 38)
                        {
                            for (int p = 0; p < 25; p++)
                            {
                                int dustID = Dust.NewDust(base.projectile.Center + unit * (i - 42), 8, 8, 90, 0, 0, 201, Color.White, 1.5f);
                                Main.dust[dustID].noGravity = true;
                            }
                            for (int c = 0; c <= 2; c++)
                            {
                                float num4 = (float)(Main.rand.Next(500, 8000) + 0.4f);
                                double num1 = Main.rand.Next(0, 1000) / 800f;
                                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 360f;
                                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 360f;
                                int num5 = Projectile.NewProjectile(base.projectile.Center.X + unit.X * (i - 42), base.projectile.Center.Y + unit.Y * (i - 42), (float)num2 * projectile.scale * 1.5f, (float)num3 * projectile.scale * 1.5f, base.mod.ProjectileType("RedGemDust2"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                                Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 2000f;
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
            Vector2 unit = projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance / 70f + v * 70f, (projectile.width + 16) * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[projectile.owner];
            Vector2 unit = projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * Distance / 70f + v * 70f,3, ref point);
        }
    }
}
