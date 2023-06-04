using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Localization;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.Yasitaya
{
    public class BloodSwordGas : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 138;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 1081;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
        private bool Finish = false;
        private bool Ini = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f - 1f / Projectile.velocity.Length(), 1f - 1f / Projectile.velocity.Length(), 1f - 1f / Projectile.velocity.Length(), 0));
        }
        private float Cl = 0;
        public override void AI()
        {
            if(Ini)
            {
                Projectile.timeLeft = (int)(1080 + Projectile.ai[0]);
                Cl = Projectile.ai[0];
                Ini = false;
                
            }
            if(Finish)
            {
                Projectile.velocity.Y += 2f;
                Projectile.hostile = true;
            }

            if(Projectile.timeLeft == 1079)
            {
                for (int i = 0; i < 90; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                    int num5 = Dust.NewDust(new Vector2(Projectile.Top.X, Projectile.Top.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(Projectile.damage)));
                    Main.dust[num5].velocity = v;
                }
            }
            int num = Dust.NewDust(Projectile.Center - new Vector2(4, 4) + new Vector2(0, 12).RotatedBy(Projectile.timeLeft / 4f), 2, 2, Mod.Find<ModDust>("RedEffect2").Type, 0, 0, 0, default(Color), 1f);
            Main.dust[num].noGravity = false;
            Main.dust[num].velocity *= 0;
            int num20 = Dust.NewDust(Projectile.Center - new Vector2(4, 4) - new Vector2(0, 12).RotatedBy(Projectile.timeLeft / 4f), 2, 2, Mod.Find<ModDust>("RedEffect2").Type, 0, 0, 0, default(Color), 1f);
            Main.dust[num20].noGravity = false;
            Main.dust[num20].velocity *= 0;
            int num21 = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("RedEffect2").Type, 0, 0, 0, default(Color), 1.5f);
            Main.dust[num21].velocity *= 0;
            int num22 = Dust.NewDust(Projectile.Center - new Vector2(4, 4) + new Vector2(0, Main.rand.NextFloat(0, 8f)).RotatedByRandom(Math.PI * 2), 2, 2, Mod.Find<ModDust>("RedEffect2").Type, 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 90; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(Projectile.Bottom.X, Projectile.Bottom.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v * 0.3f;
            }
            for (int i = 0; i <= 32; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 40f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 40f;
                int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("RedGemDust").Type, 0, 0, base.Projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
            }
        }
        private int Dely = 0;
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            if (Projectile.timeLeft <= 1079)
            {
                Dely = (1080 - Projectile.timeLeft) * 3;
                if (Dely > 138)
                {
                    Dely = 138;
                    Finish = true;
                    Projectile.tileCollide = true;
                }
                Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), new Color(0.8f, 0.8f, 0.8f, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            }
            else
            {
                Main.spriteBatch.Draw(Mod.GetTexture("NPCs/Yasitaya/RedPixel"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY - 2000), new Rectangle?(new Rectangle(0, 0, 10, 4000)), new Color(0.8f * (Projectile.timeLeft - 1080) / Cl, 0.8f * (Projectile.timeLeft - 1080) / Cl, 0.8f * (Projectile.timeLeft - 1080) / Cl, 0), 0, new Vector2(5, 5), base.Projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void PostDraw(Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // ¡ã0ˆ50‡9¨´0ˆ70ˆ40…80‡20…80Š00…90†40‡7¨²0…60‡70…60‹20†80…70„50…1¡ã0…70ˆ90ˆ90‡90…60ˆ4¨°
            for (int i = 1; i < Projectile.oldPos.Length; ++i)
            {
                if (Projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 30;
                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)Projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width + new Vector2(19, 130) - Projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width + new Vector2(19, 130) - Projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // ¡ã0…70ˆ90ˆ90‡90…60ˆ4¨°0†90…10†50ˆ70‡60‹50†50‡50ˆ40ˆ2
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
                // 0†00‡70…80‹0¡Á0„40‡80ˆ10…80‹00†60ˆ10†70‡70ˆ60ˆ80‰00†30ˆ30ˆ80‡80†60‡60‹50†50‡50ˆ40ˆ20ˆ9¡è0†00Š9
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // ¡ã0ˆ5¡À0Š10†30†30†20ˆ10‡9¨´0ˆ4¨¨0ˆ40‡30ˆ30„40…90„90†00‹3shader
                Mod.GetEffect("Effects/Trail").Parameters["uTransform"].SetValue(model * projection);
                Mod.GetEffect("Effects/Trail").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = Mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = Mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = Mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                Mod.GetEffect("Effects/Trail").CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
        }


        // ¡Á0ˆ80…9¡§0ˆ60Š20…90„60…80Š00‡80‹50†60‰60†5¨¢0†10†10„50…1¡Á0„40ˆ60‰90ˆ90‰90†00‹20†5¨¢0†10†10ˆ00Š20†80Š70‡10Š30…80‡20‡90…60ˆ4¨°0ˆ4¨¨0ˆ60„90†20ˆ1shader0†80Š70‡10Š30…80‡20‡80‹50†60‰60ˆ3¨¤0ˆ10…1
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