using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using TemplateMod2.Utils;


namespace MythMod.Projectiles.projectile4
{
    public class BloodGoldShader : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodGoldShader");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 29;
            /*projectile.extraUpdates = 9;*/
            projectile.scale = 1;
            projectile.knockBack = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 31;
        private int Dir = 1;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        private Vector2 vp1 = new Vector2(0, 0);
        private int Y = 0;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];         
            if (projectile.timeLeft == 29)
            {
                Dir = player.direction;
                Y = Main.rand.Next(3);
            }
            if(projectile.timeLeft % 3 == Y && projectile.timeLeft > 15 && player.direction == 1)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y,projectile.velocity.Y * 8f, -projectile.velocity.X * 8f, mod.ProjectileType("DarkFlow"), 60, 0.2f, Main.myPlayer, 0f, 0f);
            }
            if (projectile.timeLeft % 3 == Y && projectile.timeLeft > 15 && player.direction == -1)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -projectile.velocity.Y * 8f, projectile.velocity.X * 8f, mod.ProjectileType("DarkFlow"), 60, 0.2f, Main.myPlayer, 0f, 0f);
            }
            Vector2 vp0 = new Vector2(-45f * Dir + player.width / 2f, -22.5f).RotatedBy(0) + player.position;
            
            if (projectile.timeLeft >= 15)
            {
                Vector2 v = new Vector2(-45f, -22.5f).RotatedBy(Math.PI / 12.5f * (30 - projectile.timeLeft));
                projectile.position = player.position + new Vector2(v.X * Dir + player.width / 2f, v.Y);
                if(projectile.timeLeft == 29)
                {
                    projectile.velocity = (projectile.position - vp0) * 0.2f;
                    vp1 = projectile.position - vp0;
                }
                else
                {
                    vp1 = vp1.RotatedBy(Math.PI / 12.5f * Dir);
                    projectile.velocity = vp1 * 0.2f;
                }
            }
            else
            {
                K -= 3f;
                if(projectile.velocity.Length() > 0.0001f)
                {
                    projectile.velocity *= 0.96f;
                }
            }
            for (int k = 0; k < 200; ++k)
            {
                for (int i = 0; i < projectile.oldPos.Length - 1; ++i)
                {
                    if ((Main.npc[k].Center - projectile.oldPos[i]).Length() < 50 && i % 4 == 0 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly)
                    {
                        Main.npc[k].StrikeNPC((int)(20 * Main.rand.NextFloat(0.45f, 0.7f) * player.meleeDamage), projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        NPC target = Main.npc[k];
                        target.velocity += Vector2.Normalize(target.Center - player.Center) * 3f * target.knockBackResist;
                    }
                }
            }
        }
        /*public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            for (int i = 0; i <= 32; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 40f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 40f;
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("BlueGemDust"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
            }
            for (int a = 0; a < 90; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 26.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("BlueEffect2"), v.X, v.Y, 0, default(Color), 2f * Main.rand.NextFloat(0.4f, 1.2f));
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            for (int a = 0; a < 20; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 6.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4) + v * 10f, 2, 2, mod.DustType("BlueEffect"), v.X, v.Y, 0, default(Color), 1.2f * Main.rand.NextFloat(0.8f, 1.2f));
                Main.dust[num].noGravity = false;
                Main.dust[num].velocity *= 0;
            }
        }*/
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // �����еĵ㶼���ɳ���������˳��
            if(K >= 30)
            {
                for (int i = 1; i < projectile.oldPos.Length - 1; ++i)
                {
                    if (projectile.oldPos[i] == Vector2.Zero) break;
                    //spriteBatch.Draw(mod.GetTexture("UIImages/Star"), projectile.position + projectile.velocity.RotatedBy(Math.PI / 2d * Dir) * 20 - Main.screenPosition, null, new Color(0.2f, 0f, 0f, 0f), 0f, new Vector2(36f, 36f), (float)Math.Sin(projectile.timeLeft / 30d * Math.PI) * 0.2f, SpriteEffects.None, 0f);
                    //spriteBatch.Draw(mod.GetTexture("UIImages/Star"), projectile.position + projectile.velocity.RotatedBy(Math.PI / 2d * Dir) * 20 - Main.screenPosition, null, new Color(0.2f, 0f, 0f, 0f), (float)(Math.PI / 2d), new Vector2(36f, 36f), (float)Math.Sin(projectile.timeLeft / 30d * Math.PI) * 0.6f, SpriteEffects.None, 0f);

                    int width = 0;
                    if (60- (int)(i * 2f) + (projectile.timeLeft) - 30 > 0)
                    {
                        width = 60- (int)(i * 2f) + (projectile.timeLeft) - 30;
                    }
                    else
                    {
                        width = 0;
                    }
                    var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                    normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                    var alpha = (float)0;
                    if (projectile.timeLeft > 15)
                    {
                        alpha = (i + projectile.timeLeft - 15) / (float)projectile.oldPos.Length;
                    }
                    else
                    {
                        alpha = i / (float)projectile.oldPos.Length;
                    }
                    var factor = i / (float)projectile.oldPos.Length;
                    var color = Color.Lerp(Color.White, Color.Blue, factor);
                    var w = MathHelper.Lerp(1f, 0.05f, alpha);

                    /*if(i > 2)
                    {
                        for (int j = 1; j < 9; ++j)
                        {
                            float t = j / 10f;
                            float ti = t - 0.1f;
                            Vector2 vk0 = (projectile.oldPos[i - 2] * (1 - t) * (1 - t) + projectile.oldPos[i - 1] * t * 2 * (1 - t) + projectile.oldPos[i] * t * t);
                            Vector2 vk1 = (projectile.oldPos[i - 2] * (1 - ti) * (1 - ti) + projectile.oldPos[i - 1] * ti * 2 * (1 - ti) + projectile.oldPos[i] * ti * ti);
                            normalDir = vk1 - vk0;
                            normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                            bars.Add(new CustomVertexInfo(vk0 + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                            bars.Add(new CustomVertexInfo(vk0 + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                        }
                    }*/

                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                }
            }
            else
            {
                for (int i = 1; i < K - 1; ++i)
                {
                    if (projectile.oldPos[i] == Vector2.Zero) break;
                    //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                    //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                    int width = 0;
                    if (60- (int)(i * 2f) + (projectile.timeLeft) - 30 > 0)
                    {
                        width = 60- (int)(i * 2f) + (projectile.timeLeft) - 30;
                    }
                    else
                    {
                        width = 0;
                    }
                    var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                    normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                    var alpha = (float)0;
                    if (projectile.timeLeft > 15)
                    {
                        alpha = (i + projectile.timeLeft - 15) / (float)projectile.oldPos.Length;
                    }
                    else
                    {
                        alpha = i  / (float)projectile.oldPos.Length;
                    }
                    var factor = i / K;
                    var color = Color.Lerp(Color.White, Color.Blue, factor);
                    var w = MathHelper.Lerp(1f, 0.05f, alpha);

                    /*if (i > 2)
                    {
                        for (int j = 1; j < 9; ++j)
                        {
                            float t = j / 10f;
                            float ti = t - 0.1f;
                            Vector2 vk0 = (projectile.oldPos[i - 2] * (1 - t) * (1 - t) + projectile.oldPos[i - 1] * t * 2 * (1 - t) + projectile.oldPos[i] * t * t);
                            Vector2 vk1 = (projectile.oldPos[i - 2] * (1 - ti) * (1 - ti) + projectile.oldPos[i - 1] * ti * 2 * (1 - ti) + projectile.oldPos[i] * ti * ti);
                            normalDir = vk1 - vk0;
                            normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                            bars.Add(new CustomVertexInfo(vk0 + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                            bars.Add(new CustomVertexInfo(vk0 + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                        }
                    }*/
                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                }
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // ����˳������������
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 3, Color.White, new Vector3(0, 0.5f, 1));
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
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                // �ɵ�ע�͵��Ϳ���ֻ��ʾ������դ��
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // �ѱ任��������Ϣ����shader
                MythMod.DefaultEffectDarkRedGold.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectDarkRedGold.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorDarkRedGold;               
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                if (Dir == 1)
                {
                    Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor2;
                }
                else
                {
                    Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor3;
                }
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;

                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectDarkRedGold.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
        }


        // �Զ��嶥�����ݽṹ��ע������ṹ�������˳����Ҫ��shader�����������ͬ
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