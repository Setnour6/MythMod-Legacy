using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;

namespace MythMod.Projectiles.CorruptMoth
{
    public class ButterflyDream : ModProjectile
    { public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("蓝蝶幻梦");
            ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            base.projectile.width = 24;
            base.projectile.height = 24;
            base.projectile.netImportant = true;
            base.projectile.friendly = true;
            base.projectile.penetrate = 3;
            base.projectile.timeLeft = 900;
            base.projectile.tileCollide = true;
            base.projectile.usesLocalNPCImmunity = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
       
        private float K = 10;
        public override void AI()
		{
            projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;
            float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 400f;
            
            if(K >= 40)
            {
                K *= 0.96f;
            }
            if (K <= 6)
            {
                K *= 1.05f;
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            bool flag = false;
            if(projectile.timeLeft == 899)
            {
                projectile.frame = Main.rand.Next(2);
                projectile.timeLeft -= Main.rand.Next(29);
            }
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 20);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4 && projectile.timeLeft > 120)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                    if (num7 < 20)
                    {
                        Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f,1.15f)), projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        projectile.penetrate--;
                        NPC target = Main.npc[j];
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag && projectile.timeLeft % 30 > 15)
			{
				float num8 = 5f;
				Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 10f + num9) / 11f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 10f + num10) / 11f;
			}
            else
            {
                projectile.velocity = projectile.velocity.RotatedBy(Main.rand.Next(-20000, 20000) / 400000f);
            }
            if (projectile.timeLeft < 120)
			{
                projectile.tileCollide = false;
				flag = false;
                projectile.alpha = (int)(255 - 255 * (projectile.timeLeft / 120f));
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f * (projectile.timeLeft / 120f));
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f * (projectile.timeLeft / 120f));
                    }
                }
            }
            else
            {
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f);
                    }
                }
            }
            if (!flag)
			{
            }
			if (base.projectile.frame > 2)
			{
				base.projectile.frame = 0;
			}
			if(base.projectile.timeLeft % 10 == 0)
			{
				base.projectile.frame++;
			}
		}
        private int y = 0;
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 18; i++)
            {
                Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 0);
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

                int width = 30;
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Blue, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
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
                MythMod.DefaultEffectB2.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectB2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorBlueD;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectB2.CurrentTechnique.Passes[0].Apply();


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
