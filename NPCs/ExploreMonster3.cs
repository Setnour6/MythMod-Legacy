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
    public class ExploreMonster3 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("光波探测怪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "光波探测怪");
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
        private int A = -1;
        private int B = 0;
        private float R = 0;
        private Vector2 v3 = Vector2.Zero;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            NPC.velocity *= 0.97f;
            A += 1;
            if((NPC.Center - player.Center).Length() > 300)
            {
                if(A % 90 == 0)
                {
                    NPC.velocity += (player.Center - NPC.Center).RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) / (player.Center - NPC.Center).Length() * 12f;
                }
                B = 0;
                NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) * 0.05f + R * 0.95f;
                R = NPC.rotation % (float)(Math.PI * 2);
            }
            else
            {
                B += 1;
                Vector2 v = (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 12f;
                v3 = v;
                NPC.rotation = R * 0.95f + (float)Math.Atan2(v.Y, v.X) * 0.05f;
                R = NPC.rotation % (float)(Math.PI * 2);
                if (B >= 99)
                {
                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("RedWave").Type, NPC.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                    B = 0;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.NPC.position.X, base.NPC.position.Y));
            if (NPC.life <= 0)
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
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/ExploreMonster3Glow").Width, (float)(base.Mod.GetTexture("NPCs/ExploreMonster3Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/ExploreMonster3Glow"), vector2, new Rectangle?(base.NPC.frame), new Color(255, 255, 255, 0), base.NPC.rotation, vector, 1f, effects, 0f);
            if(B > 0)
            {
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/RedCircleQuarter"), vector2 + v3 * (B - B % 10) / 20f, null, new Color(0.8f * (255 - NPC.alpha) / 255f, 0.8f * (255 - NPC.alpha) / 255f, 0.8f * (255 - NPC.alpha) / 255f, 0), base.NPC.rotation, new Vector2(125, 125), (B - B % 10) / 20f, effects, 0f);
            }
            return;
        }
    }
}
