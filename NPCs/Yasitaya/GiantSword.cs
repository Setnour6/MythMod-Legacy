using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using MythMod;

namespace MythMod.NPCs.Yasitaya
{
    public class GiantSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            projectile.width = 164;
            projectile.height = 426;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.magic = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 1080;
            projectile.penetrate = 1;
            projectile.scale = 1;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        private int n = -1;

        public override void AI()
        {
            if (projectile.timeLeft == 1079)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordUp"), (int)projectile.Center.X, (int)projectile.Center.Y);
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
                if (projectile.timeLeft == 1078)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)projectile.Center.X, (int)projectile.Center.Y);
                    projectile.position = Main.npc[n].Center;
                    //projectile.scale = 0;
                }
                if (projectile.timeLeft < 1078)
                {
                    projectile.position = Main.npc[n].Center + new Vector2(20 * Main.npc[n].spriteDirection - 82, 0);
                }
                projectile.velocity = Main.npc[n].velocity;
            }
        }
        public static bool OpenEffw = false;
        public static float Range = 0;
        public static float RangeAdd = 0.03f;
        public static Vector2 WavCent = new Vector2(0);
        public override void Kill(int timeLeft)
        {
            OpenEffw = true;
            WavCent = projectile.Bottom - Main.screenPosition;
            Projectile.NewProjectile(projectile.Bottom.X, projectile.Bottom.Y, 0, 0, mod.ProjectileType("WavePoint"), 0, 0f, Main.myPlayer, 0f, 0f);
            for(int g = 0;g < 15;g++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f,20f)).RotatedByRandom(MathHelper.TwoPi);
                Projectile.NewProjectile(projectile.Bottom.X, projectile.Bottom.Y, v.X, v.Y, mod.ProjectileType("RedDust"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 36, 1f, 0f);
            for (int i = 0; i < 270; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(projectile.Bottom.X, projectile.Bottom.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 180; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(8 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(projectile.Bottom.X, projectile.Bottom.Y) + v * 20f, 0, 0, 183, 0f, 0f, 100, Color.White, (float)(2f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
                Main.dust[num5].rotation = Main.rand.NextFloat(0, (float)(MathHelper.TwoPi));
            }
            Texture2D tex = Main.projectileTexture[base.projectile.type];
            Color[] colorTex = new Color[tex.Width * tex.Height];
            tex.GetData(colorTex);
            for (int y = 0; y < tex.Height; y += 1)
            {
                for (int x = 0; x < tex.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex.Width].R, colorTex[x + y * tex.Width].G, colorTex[x + y * tex.Width].B) != new Color(0, 0, 0))
                    {
                        if(Main.rand.Next(5) == 1)
                        {
                            Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2f * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                            int num5 = Dust.NewDust(projectile.position + new Vector2(x, y), 0, 0, 183, 0f, 0f, 100, Color.White, 1f);
                            Main.dust[num5].velocity = v;
                            Main.dust[num5].noGravity = true;
                        }
                    }
                }
            }
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordCrash"), (int)projectile.Center.X, (int)projectile.Center.Y);
            RangeAdd = 0.03f;
            Range = 0;
        }
        private int Dely = 0;
        private float Col = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Dely = (1080 - projectile.timeLeft) * 6;
            if(Dely > 426)
            {
                Dely = 426;
            }
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), Lighting.GetColor((int)(projectile.Center.X / 16d), (int)(projectile.Center.Y / 16d)), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            if(Dely < 426)
            {
                for (int g = 1; g < 5; g++)
                {
                    Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY + Dely + 2 * g - 10), new Rectangle?(new Rectangle(0, Dely + 2 * g, texture2D.Width, 2)), new Color(0.2f * g, 0.2f * g, 0.2f * g, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
                }
            }
            else
            {
                if(!Main.gamePaused && Col < 0.7f)
                {
                    Col += 0.05f;
                }
                if(Col >= 0.7f)
                {
                    Col = 0.7f;
                    projectile.tileCollide = true;
                }
                Main.spriteBatch.Draw(mod.GetTexture("NPCs/Yasitaya/GiantSwordGlow"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), new Color(Col, Col, Col, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < projectile.oldPos.Length; ++i)
            {
                if (projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 90;
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(82, 356), color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(82, 356), color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + new Vector2(0, 22), Color.White, new Vector3(0, 0.5f, 1));
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
                mod.GetEffect("Effects/TrailGiantSword").Parameters["uTransform"].SetValue(model * projection);
                mod.GetEffect("Effects/TrailGiantSword").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                mod.GetEffect("Effects/TrailGiantSword").CurrentTechnique.Passes[0].Apply();


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