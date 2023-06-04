using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
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
            // DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            Projectile.width = 164;
            Projectile.height = 426;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 1080;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        private int n = -1;

        public override void AI()
        {
            if (Projectile.timeLeft == 1079)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordUp"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == Mod.Find<ModNPC>("Yasitaya").Type)
                    {
                        n = i;
                        break;
                    }
                }
            }
            if (n != -1)
            {
                if (Projectile.timeLeft == 1078)
                {
                    SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                    Projectile.position = Main.npc[n].Center;
                    //projectile.scale = 0;
                }
                if (Projectile.timeLeft < 1078)
                {
                    Projectile.position = Main.npc[n].Center + new Vector2(20 * Main.npc[n].spriteDirection - 82, 0);
                }
                Projectile.velocity = Main.npc[n].velocity;
            }
        }
        public static bool OpenEffw = false;
        public static float Range = 0;
        public static float RangeAdd = 0.03f;
        public static Vector2 WavCent = new Vector2(0);
        public override void Kill(int timeLeft)
        {
            OpenEffw = true;
            WavCent = Projectile.Bottom - Main.screenPosition;
            Projectile.NewProjectile(Projectile.Bottom.X, Projectile.Bottom.Y, 0, 0, Mod.Find<ModProjectile>("WavePoint").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            for(int g = 0;g < 15;g++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f,20f)).RotatedByRandom(MathHelper.TwoPi);
                Projectile.NewProjectile(Projectile.Bottom.X, Projectile.Bottom.Y, v.X, v.Y, Mod.Find<ModProjectile>("RedDust").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            }
            SoundEngine.PlaySound(SoundID.Item36, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int i = 0; i < 270; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(Projectile.Bottom.X, Projectile.Bottom.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 180; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(8 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(Projectile.Bottom.X, Projectile.Bottom.Y) + v * 20f, 0, 0, 183, 0f, 0f, 100, Color.White, (float)(2f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
                Main.dust[num5].rotation = Main.rand.NextFloat(0, (float)(MathHelper.TwoPi));
            }
            Texture2D tex = TextureAssets.Projectile[base.Projectile.type].Value;
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
                            Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2f * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                            int num5 = Dust.NewDust(Projectile.position + new Vector2(x, y), 0, 0, 183, 0f, 0f, 100, Color.White, 1f);
                            Main.dust[num5].velocity = v;
                            Main.dust[num5].noGravity = true;
                        }
                    }
                }
            }
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SwordCrash"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            RangeAdd = 0.03f;
            Range = 0;
        }
        private int Dely = 0;
        private float Col = 0;
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Dely = (1080 - Projectile.timeLeft) * 6;
            if(Dely > 426)
            {
                Dely = 426;
            }
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), Lighting.GetColor((int)(Projectile.Center.X / 16d), (int)(Projectile.Center.Y / 16d)), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            if(Dely < 426)
            {
                for (int g = 1; g < 5; g++)
                {
                    Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY + Dely + 2 * g - 10), new Rectangle?(new Rectangle(0, Dely + 2 * g, texture2D.Width, 2)), new Color(0.2f * g, 0.2f * g, 0.2f * g, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
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
                    Projectile.tileCollide = true;
                }
                Main.spriteBatch.Draw(Mod.GetTexture("NPCs/Yasitaya/GiantSwordGlow"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), new Color(Col, Col, Col, 0), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
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

                int width = 90;
                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)Projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width + new Vector2(82, 356), color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width + new Vector2(82, 356), color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // ¡ã0…70ˆ90ˆ90‡90…60ˆ4¨°0†90…10†50ˆ70‡60‹50†50‡50ˆ40ˆ2
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
                // 0†00‡70…80‹0¡Á0„40‡80ˆ10…80‹00†60ˆ10†70‡70ˆ60ˆ80‰00†30ˆ30ˆ80‡80†60‡60‹50†50‡50ˆ40ˆ20ˆ9¡è0†00Š9
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // ¡ã0ˆ5¡À0Š10†30†30†20ˆ10‡9¨´0ˆ4¨¨0ˆ40‡30ˆ30„40…90„90†00‹3shader
                Mod.GetEffect("Effects/TrailGiantSword").Parameters["uTransform"].SetValue(model * projection);
                Mod.GetEffect("Effects/TrailGiantSword").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = Mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = Mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = Mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                Mod.GetEffect("Effects/TrailGiantSword").CurrentTechnique.Passes[0].Apply();


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