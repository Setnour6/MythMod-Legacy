using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics;

namespace MythMod.NPCs
{
    public class ExploreMonster2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("防御型探测怪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "防御型探测怪");
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }
        public override void SetDefaults()
        {
            base.npc.aiStyle = -1;
            base.npc.damage = 60;
            base.npc.width = 34;
            base.npc.height = 34;
            base.npc.defense = 15;
            base.npc.lifeMax = 300;
            base.npc.knockBackResist = 1;
            base.npc.lavaImmune = true;
            base.npc.noGravity = true;
            base.npc.noTileCollide = true;
            base.npc.buffImmune[24] = true;
        }
        private bool Stop = false;
        private bool Kil = false;
        private int time2 = -60;
        public override void AI()
        {
            npc.velocity *= 0.92f;
            if (npc.velocity.Length() < 0.01f && npc.velocity.Length() > 0)
            {
                npc.velocity *= 0;
                Stop = true;
            }
            if (Stop && !Kil)
            {
                if (time2 < 60)
                {
                    time2++;
                }
                else
                {
                    time2 = 60;
                }
            }
            if (Stop && Kil)
            {
                time2 -= 1;
                if (time2 < -60)
                {
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14, 1f, 0f);
                    npc.position.X = npc.position.X + (float)(npc.width / 2);
                    npc.position.Y = npc.position.Y + (float)(npc.height / 2);
                    npc.position.X = npc.position.X - (float)(npc.width / 2);
                    npc.position.Y = npc.position.Y - (float)(npc.height / 2);
                    for (int i = 0; i < 2; i++)
                    {
                        int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num].velocity *= 3f;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num].scale = 0.5f;
                            Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                        }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 3f);
                        Main.dust[num2].noGravity = true;
                        Main.dust[num2].velocity *= 5f;
                        num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num2].velocity *= 2f;
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        float scaleFactor = 0.33f;
                        if (k == 1)
                        {
                            scaleFactor = 0.66f;
                        }
                        if (k == 2)
                        {
                            scaleFactor = 1f;
                        }
                        int num3 = Gore.NewGore(new Vector2(npc.position.X + (float)(npc.width / 2) - 24f, npc.position.Y + (float)(npc.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore = Main.gore[num3];
                        gore.velocity.X = gore.velocity.X + 1f;
                        Gore gore2 = Main.gore[num3];
                        gore2.velocity.Y = gore2.velocity.Y + 1f;
                        num3 = Gore.NewGore(new Vector2(npc.position.X + (float)(npc.width / 2) - 24f, npc.position.Y + (float)(npc.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore3 = Main.gore[num3];
                        gore3.velocity.X = gore3.velocity.X - 1f;
                        Gore gore4 = Main.gore[num3];
                        gore4.velocity.Y = gore4.velocity.Y + 1f;
                        num3 = Gore.NewGore(new Vector2(npc.position.X + (float)(npc.width / 2) - 24f, npc.position.Y + (float)(npc.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore5 = Main.gore[num3];
                        gore5.velocity.X = gore5.velocity.X + 1f;
                        Gore gore6 = Main.gore[num3];
                        gore6.velocity.Y = gore6.velocity.Y - 1f;
                        num3 = Gore.NewGore(new Vector2(npc.position.X + (float)(npc.width / 2) - 24f, npc.position.Y + (float)(npc.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore7 = Main.gore[num3];
                        gore7.velocity.X = gore7.velocity.X - 1f;
                        Gore gore8 = Main.gore[num3];
                        gore8.velocity.Y = gore8.velocity.Y - 1f;
                    }
                    npc.active = false;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 37, 1f, 0f);
            if (npc.life < 50)
            {
                npc.life = 1;
                npc.dontTakeDamage = true;
                npc.active = true;
                Kil = true;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            float QD = time2 > 0 ? 3 : (time2 + 60) / 20f;
            if (QD > 0)
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);

                var center = npc.Center - Main.screenPosition;
                float num89 = 0f;
                if (npc.ai[3] > 0f && npc.ai[3] <= 30f)
                {
                    num89 = 1f - npc.ai[3] / 30f;
                }
                if (Stop)
                {
                    if (time2 > 0)
                    {
                        DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 1200, 800), new Color(255, 0, 0, 0) * (QD * 0.8f), npc.rotation, new Vector2(600f, 400f), npc.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                        GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                        GameShaders.Misc["ForceField"].Apply(drawData);
                        drawData.Draw(Main.spriteBatch);
                    }
                    else
                    {
                        DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, (int)(1200 + time2 * time2 * 0.6f), (int)(800 + time2 * time2 * 0.6f)), new Color(255, 0, 0, 0) * (QD * 0.8f), npc.rotation, new Vector2(600f + time2 * time2 * 0.3f, 400f + time2 * time2 * 0.3f), npc.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                        GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                        GameShaders.Misc["ForceField"].Apply(drawData);
                        drawData.Draw(Main.spriteBatch);
                    }
                }
                Main.spriteBatch.End();
                Main.spriteBatch.Begin();
                SpriteEffects effects = SpriteEffects.None;
                if (base.npc.spriteDirection == 1)
                {
                    effects = SpriteEffects.FlipHorizontally;
                }
                Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
                Vector2 vector2 = value - Main.screenPosition;
                vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/ExploreMonster2Glow").Width, (float)(base.mod.GetTexture("NPCs/ExploreMonster2Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
                vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
                Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/ExploreMonster2Glow"), vector2, new Rectangle?(base.npc.frame), new Color(1, 1, 1, 0), base.npc.rotation, vector, 1f, effects, 0f);
                return;
            }
        }
    }
}
