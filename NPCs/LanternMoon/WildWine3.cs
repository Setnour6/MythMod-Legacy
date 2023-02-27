using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Input;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Skies;
using MythMod.NPCs.LanternMoon;

namespace MythMod.NPCs.LanternMoon
{
    public class WildWine3 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("狂野藤蔓");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "狂野藤蔓");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.damage = 62;
			base.npc.width = 34;
			base.npc.height = 42;
			base.npc.defense = 90;
			base.npc.lifeMax = 2600;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.npc.lavaImmune = false;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            npc.dontTakeDamage = true;
            npc.dontCountMe = true;
            npc.behindTiles = true;
            npc.alpha = 255;
            NPCID.Sets.TrailingMode[npc.type] = 0;
            NPCID.Sets.TrailCacheLength[npc.type] = 400;
            //this.banner = base.npc.type;
            //this.bannerItem = base.mod.ItemType("青苹果糖史莱姆Banner");
        }
        private int G0 = -1;
        private int Dir = -1;
        private int Dir2 = -1;
        private int Maxt = 900;
        private float Green = 0;
        private float StartY = 0;
        private float Vx = 0;
        private Vector2 PurposePl;
        private Vector2 PurposeVe;
        public override void AI()
        {
            G0 += 1;
            int pl = Player.FindClosest(npc.Center, 1, 1);
            if (G0 == 0)
            {
                npc.velocity = new Vector2(0, -25).RotatedBy(Main.rand.NextFloat(-0.1f, 0.1f));
                if (Main.rand.Next(20000) > 10000)
                {
                    Dir = 1;
                }
                if (Main.rand.Next(20000) > 10000)
                {
                    Dir2 = 1;
                }
                Maxt = 2;
                StartY = npc.Center.Y;
                Vx = npc.velocity.X;
                PurposePl = npc.velocity = new Vector2(Main.rand.NextFloat(-9f, -6f) * Dir2, 0).RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f));
                PurposeVe = npc.velocity = new Vector2(0, -25).RotatedBy(Main.rand.NextFloat(-2f, 2f));
            }
            if (G0 < Maxt)
            {
                //npc.position.X += Vx / 100f;
                PurposeVe = PurposeVe.RotatedBy(Dir * 0.1);
                PurposePl = PurposePl.RotatedBy(Main.rand.NextFloat(-0.1f,0.1f)) * Main.rand.NextFloat(0.99f,1.01f);
                npc.velocity = npc.velocity * 0.9f + PurposeVe * 0.05f + PurposePl * 0.05f;
            }
            else
            {
                if (G0 < Maxt + 30)
                {
                    Vector2 v = new Vector2(0, -25f);
                    npc.velocity = npc.velocity * 0.95f + v * 0.05f;
                }
            }
            if (G0 >= Maxt + 30 && G0 < Maxt + 90)
            {
                Vector2 v = new Vector2(0, -25f);
                npc.velocity = npc.velocity * 0.92f + v * 0.05f;
            }
            if (G0 >= Maxt + 90)
            {
                Green += 0.02f;
            }
            if(Green >= 1)
            {
                npc.active = false;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < npc.oldPos.Length; ++i)
            {
                if (npc.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, npc.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);
                int width = (int)(6 * Math.Sqrt(Math.Sqrt(i)));
                var normalDir = npc.oldPos[i - 1] - npc.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = ((npc.oldPos.Length - i) / 6f) % 1f;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        Lighting.AddLight(npc.oldPos[i] + new Vector2(x, y), new Vector3(0, 0.1f, 0));
                    }
                }
                bars.Add(new CustomVertexInfo(npc.oldPos[i] + normalDir * width, color, new Vector3(factor, 1, w)));
                bars.Add(new CustomVertexInfo(npc.oldPos[i] + normalDir * -width, color, new Vector3(factor, 0, w)));
            }
            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(npc.velocity) * 30, Color.White,
                    new Vector3(0, 0.5f, 1));
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
                // 干掉注释掉就可以只显示三角形栅格
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // 把变换和所需信息丢给shader
                MythMod.DefaultEffectAll.Parameters["uTransform"].SetValue(model * projection);
                //MythMod.DefaultEffectAll.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                MythMod.DefaultEffectAll.Parameters["uGreen"].SetValue(Green);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/LanternMoon/WildWine");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/LanternMoon/WildWine");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/LanternMoon/WildWine");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectAll.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();

                x += 0.01f;
                /*float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);*/
            }
            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(npc.velocity) * 30, Color.White,
                    new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffectG.Parameters["uTransform"].SetValue(model * projection);
                //MythMod.DefaultEffectAll.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                MythMod.DefaultEffectG.Parameters["uGreen"].SetValue(Green);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/LanternMoon/WildWinevague");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/LanternMoon/WildWinevague");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/LanternMoon/WildWinevague");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectG.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
                /*float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("Images/Extra_209"), base.npc.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 0.4f * npc.timeLeft / 90f, SpriteEffects.None, 0f);*/
            }
        }
        private float x = 0;

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
