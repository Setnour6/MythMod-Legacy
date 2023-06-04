using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework.Graphics;

using Terraria.Localization;
namespace MythMod.Projectiles.projectile3
{
	class BloodLightCyanFlame : ModProjectile
	{
        public override void SetDefaults()
		{
			Projectile.width = 68;
			Projectile.height = 68;
			Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 3000;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(39, 600, false);
            for (int u = 0; u < 5; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 96, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("EndlessCurseFlame").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(Projectile.timeLeft > 2850)
            {
                if (Projectile.ai[1] != 0)
                {
                    return true;
                }
                Projectile.soundDelay = 10;
                if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
                {
                    Projectile.velocity.X = oldVelocity.X * -0.9f;
                }
                if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
                {
                    Projectile.velocity.Y = oldVelocity.Y * -0.9f;
                }
            }
			return false;
		}

		public override void AI()
		{
            float num7 = Projectile.velocity.Length();
            int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
            Projectile.rotation += 0.05f * num7;
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
            if (Projectile.timeLeft <= 2850)
            {
                if (num7 < 5f)
                {
                    base.Projectile.velocity *= 1.05f;
                }
                if (num7 > 6f)
                {
                    base.Projectile.velocity *= 0.98f;
                }
                int num3 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                Projectile.velocity = Projectile.velocity * 0.98f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 3.5f;
                base.Projectile.tileCollide = false;
            }
            else
            {
                if (num7 < 27f)
                {
                    base.Projectile.velocity *= 1.05f;
                }
                if (num7 > 27.5f)
                {
                    base.Projectile.velocity *= 0.98f;
                }
            }
            if (num6 < 40 && num7 < 10)
            {
                base.Projectile.timeLeft = 0;
            }
            if(DelOme < 120)
            {
                DelOme+= 3;
            }
        }

		public override void Kill(int timeLeft)
		{
		}
        private int DelOme = 0;
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/血光青炎Glow"), base.Projectile.Center - Main.screenPosition, null, Color.Yellow * ((float)Projectile.timeLeft / 480f), base.Projectile.rotation, new Vector2(34f, 34f), 1f, SpriteEffects.None, 0f);
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            double o1 = Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            double o2 = Math.Atan2(Projectile.oldVelocity.Y, Projectile.oldVelocity.X);
            double omega = Math.Abs(o2 - o1) % MathHelper.TwoPi;
            int width = (int)(120 - omega * 480);
            if(width <= 10)
            {
                width = 10;
            }
            if (width <= 30)
            {
                DelOme = width;
            }
            if(width > DelOme)
            {
                width = DelOme;
            }
            for (int i = 1; i < Projectile.oldPos.Length; ++i)
            {
                if (Projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);


                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)Projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width + new Vector2(34, 34), color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width + new Vector2(34, 34), color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(Projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffect2.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffect2.Parameters["uTime"].SetValue(-(float)Main.time * 0.3f);
                Main.graphics.GraphicsDevice.Textures[0] = Mod.GetTexture("UIImages/heatmapCyan");
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffect2.CurrentTechnique.Passes[0].Apply();


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
