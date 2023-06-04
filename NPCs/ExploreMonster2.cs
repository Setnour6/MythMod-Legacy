using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("防御型探测怪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "防御型探测怪");
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }
        public override void SetDefaults()
        {
            base.NPC.aiStyle = -1;
            base.NPC.damage = 60;
            base.NPC.width = 34;
            base.NPC.height = 34;
            base.NPC.defense = 15;
            base.NPC.lifeMax = 300;
            base.NPC.knockBackResist = 1;
            base.NPC.lavaImmune = true;
            base.NPC.noGravity = true;
            base.NPC.noTileCollide = true;
            base.NPC.buffImmune[24] = true;
        }
        private bool Stop = false;
        private bool Kil = false;
        private int time2 = -60;
        public override void AI()
        {
            NPC.velocity *= 0.92f;
            if (NPC.velocity.Length() < 0.01f && NPC.velocity.Length() > 0)
            {
                NPC.velocity *= 0;
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
                    SoundEngine.PlaySound(SoundID.Item14, NPC.position);
                    NPC.position.X = NPC.position.X + (float)(NPC.width / 2);
                    NPC.position.Y = NPC.position.Y + (float)(NPC.height / 2);
                    NPC.position.X = NPC.position.X - (float)(NPC.width / 2);
                    NPC.position.Y = NPC.position.Y - (float)(NPC.height / 2);
                    for (int i = 0; i < 2; i++)
                    {
                        int num = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num].velocity *= 3f;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num].scale = 0.5f;
                            Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                        }
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        int num2 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 3f);
                        Main.dust[num2].noGravity = true;
                        Main.dust[num2].velocity *= 5f;
                        num2 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 2f);
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
                        int num3 = Gore.NewGore(new Vector2(NPC.position.X + (float)(NPC.width / 2) - 24f, NPC.position.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore = Main.gore[num3];
                        gore.velocity.X = gore.velocity.X + 1f;
                        Gore gore2 = Main.gore[num3];
                        gore2.velocity.Y = gore2.velocity.Y + 1f;
                        num3 = Gore.NewGore(new Vector2(NPC.position.X + (float)(NPC.width / 2) - 24f, NPC.position.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore3 = Main.gore[num3];
                        gore3.velocity.X = gore3.velocity.X - 1f;
                        Gore gore4 = Main.gore[num3];
                        gore4.velocity.Y = gore4.velocity.Y + 1f;
                        num3 = Gore.NewGore(new Vector2(NPC.position.X + (float)(NPC.width / 2) - 24f, NPC.position.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore5 = Main.gore[num3];
                        gore5.velocity.X = gore5.velocity.X + 1f;
                        Gore gore6 = Main.gore[num3];
                        gore6.velocity.Y = gore6.velocity.Y - 1f;
                        num3 = Gore.NewGore(new Vector2(NPC.position.X + (float)(NPC.width / 2) - 24f, NPC.position.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                        Main.gore[num3].velocity *= scaleFactor;
                        Gore gore7 = Main.gore[num3];
                        gore7.velocity.X = gore7.velocity.X - 1f;
                        Gore gore8 = Main.gore[num3];
                        gore8.velocity.Y = gore8.velocity.Y - 1f;
                    }
                    NPC.active = false;
                }
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.NPC.position.X, base.NPC.position.Y));
            if (NPC.life < 50)
            {
                NPC.life = 1;
                NPC.dontTakeDamage = true;
                NPC.active = true;
                Kil = true;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            float QD = time2 > 0 ? 3 : (time2 + 60) / 20f;
            if (QD > 0)
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);

                var center = NPC.Center - Main.screenPosition;
                float num89 = 0f;
                if (NPC.ai[3] > 0f && NPC.ai[3] <= 30f)
                {
                    num89 = 1f - NPC.ai[3] / 30f;
                }
                if (Stop)
                {
                    if (time2 > 0)
                    {
                        DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 1200, 800), new Color(255, 0, 0, 0) * (QD * 0.8f), NPC.rotation, new Vector2(600f, 400f), NPC.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                        GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                        GameShaders.Misc["ForceField"].Apply(drawData);
                        drawData.Draw(Main.spriteBatch);
                    }
                    else
                    {
                        DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, (int)(1200 + time2 * time2 * 0.6f), (int)(800 + time2 * time2 * 0.6f)), new Color(255, 0, 0, 0) * (QD * 0.8f), NPC.rotation, new Vector2(600f + time2 * time2 * 0.3f, 400f + time2 * time2 * 0.3f), NPC.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                        GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                        GameShaders.Misc["ForceField"].Apply(drawData);
                        drawData.Draw(Main.spriteBatch);
                    }
                }
                Main.spriteBatch.End();
                Main.spriteBatch.Begin();
                SpriteEffects effects = SpriteEffects.None;
                if (base.NPC.spriteDirection == 1)
                {
                    effects = SpriteEffects.FlipHorizontally;
                }
                Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
                Vector2 vector2 = value - Main.screenPosition;
                vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/ExploreMonster2Glow").Width, (float)(base.Mod.GetTexture("NPCs/ExploreMonster2Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
                vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
                Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/ExploreMonster2Glow"), vector2, new Rectangle?(base.NPC.frame), new Color(1, 1, 1, 0), base.NPC.rotation, vector, 1f, effects, 0f);
                return;
            }
        }
    }
}
