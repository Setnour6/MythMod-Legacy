﻿using System;
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

namespace MythMod.NPCs.Yasitaya
{
    public class DarkKnife : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("深渊烈焰刀");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 80;
            base.projectile.height = 80;
            base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.extraUpdates = 0;
            base.projectile.timeLeft = 26;
            base.projectile.usesLocalNPCImmunity = false;
            /*base.projectile.localNPCHitCooldown = 400;*/
            base.projectile.tileCollide = false;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private float lig = 0;
        private double Rot = 0;
        private float Squ = 0;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig, lig, lig, 0));
        }
        public int n = -1;
        private Vector2[] Vd = new Vector2[30];
        public override void AI()
        {
            projectile.velocity = new Vector2(10, -10).RotatedBy(projectile.rotation);
            if (projectile.timeLeft == 26)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == mod.NPCType("Yasitaya"))
                    {
                        n = i;
                        break;
                    }
                }
            }
            if (n != -1)
            {
                if (projectile.timeLeft == 25)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)projectile.Center.X, (int)projectile.Center.Y);
                    projectile.position = Main.npc[n].Center + new Vector2(-20, -20).RotatedBy(projectile.timeLeft / 16.66667d);
                    Vd[projectile.timeLeft] = new Vector2(-20, -20).RotatedBy(projectile.timeLeft / 16.66667d);
                    projectile.scale = 0;
                    Rot = Main.rand.NextFloat(-0.5f, 0.5f);
                    Squ = Main.rand.NextFloat(0.42f, 1);
                }
                if (projectile.timeLeft < 25)
                {
                    lig = 1f;
                    Vector2 v0 = new Vector2(-90 * Main.npc[n].spriteDirection, -90).RotatedBy((25 - projectile.timeLeft) / 16.6667d * Math.PI * Main.npc[n].spriteDirection);
                    projectile.position = Main.npc[n].Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                    Vd[projectile.timeLeft] = new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot);
                    projectile.scale = (float)Math.Sin(projectile.timeLeft / 25d * Math.PI) * 6;
                    projectile.rotation = (float)(Math.Atan2((Main.npc[n].Center - projectile.Center).Y, (Main.npc[n].Center - projectile.Center).X) + Math.PI / 2d);
                }
            }
            /*int num22 = Dust.NewDust(projectile.position - new Vector2(4, 4), projectile.width, projectile.height, mod.DustType("DarkF2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;*/
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
            if (n != -1)
            {
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
                Texture2D texture = mod.GetTexture("NPCs/Yasitaya/YasitayaBlade");
                int Times = (int)((Math.Sin((500 - projectile.timeLeft) / 50d * Math.PI) + 0.15f) * 9600f / Math.Log(projectile.timeLeft + 4));
                int y = 0;
                Vector2 v0 = new Vector2(-45 * Main.npc[n].spriteDirection, -45).RotatedBy((25 - projectile.timeLeft - y * 2f) / 16.66667d * Math.PI * Main.npc[n].spriteDirection);
                Vector2 v1 = Main.npc[n].Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                float Rot2 = (float)(Math.Atan2((Main.npc[n].Center - (v1 + new Vector2(15, 15))).Y, (Main.npc[n].Center - (v1 + new Vector2(15, 15))).X) + Math.PI / 2d);
                Color color2 = Lighting.GetColor((int)(Main.npc[n].Center.X / 16d), (int)(Main.npc[n].Center.Y / 16d));
                if (y == 0 && Main.npc[n].spriteDirection == 1)
                {
                    spriteBatch.Draw(mod.GetTexture("NPCs/Yasitaya/DarkKnife"), v1 + new Vector2(15, 15) - Main.screenPosition, null, color2, Rot2 + (float)(Math.PI / 4d * 3 * Main.npc[n].spriteDirection), new Vector2(55, 61), 1, SpriteEffects.None, 0f);
                }
                if (y == 0 && Main.npc[n].spriteDirection == -1)
                {
                    spriteBatch.Draw(mod.GetTexture("NPCs/Yasitaya/DarkKnife"), v1 + new Vector2(15, 15) - Main.screenPosition, null, color2, Rot2 + (float)(Math.PI / 4d * 3 * Main.npc[n].spriteDirection), new Vector2(55, 61), 1, SpriteEffects.FlipHorizontally, 0f);
                }
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.velocity += (projectile.Center - Main.npc[n].Center) / (projectile.Center - Main.npc[n].Center).Length() * 10f;
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序

            for (int i = 1; i < 24 - projectile.timeLeft; ++i)
            {
                if (projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                float M = 126;
                if(projectile.timeLeft < 6)
                {
                    M = projectile.timeLeft * 11;
                }
                M *= ((24 - projectile.timeLeft) - i) / (float)(24 - projectile.timeLeft);
                int width = (int)M;
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(40, 40) + Vd[i + projectile.timeLeft] * 0.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(40, 40) + Vd[i + projectile.timeLeft] * 0.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();
            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
                triangleList.Add(bars[1]);
                triangleList.Add(vertex);
                for (int i = 0; i < bars.Count - 2; i += 2)
                {
                    triangleList.Add(bars[i]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 1]);

                    triangleList.Add(bars[i + 1]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 3]);
                }


                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                // 干掉注释掉就可以只显示三角形栅格
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // 把变换和所需信息丢给shader
                mod.GetEffect("Effects/Trail").Parameters["uTransform"].SetValue(model * projection);
                mod.GetEffect("Effects/Trail").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                mod.GetEffect("Effects/Trail").CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
                triangleList.Add(bars[1]);
                triangleList.Add(vertex);
                for (int i = 0; i < bars.Count - 2; i += 2)
                {
                    triangleList.Add(bars[i]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 1]);

                    triangleList.Add(bars[i + 1]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 3]);
                }


                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                // 干掉注释掉就可以只显示三角形栅格
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // 把变换和所需信息丢给shader
                mod.GetEffect("Effects/Trail").Parameters["uTransform"].SetValue(model * projection);
                mod.GetEffect("Effects/Trail").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                mod.GetEffect("Effects/Trail").CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
        }


        // 自定义顶点数据结构，注意这个结构体里面的顺序需要和shader里面的数据相同
        private struct CustomVertexInfo : IVertexType
        {
            private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement[3]
            {
                new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
                new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
            });
            public Vector2 Position;
            public Color Color;
            public Vector3 TexCoord;

            public CustomVertexInfo(Vector2 position, Color color, Vector3 texCoord)
            {
                this.Position = position;
                this.Color = color;
                this.TexCoord = texCoord;
            }

            public VertexDeclaration VertexDeclaration
            {
                get
                {
                    return _vertexDeclaration;
                }
            }
        }
    }
}