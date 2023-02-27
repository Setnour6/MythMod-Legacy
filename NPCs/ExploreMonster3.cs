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
        private int A = -1;
        private int B = 0;
        private float R = 0;
        private Vector2 v3 = Vector2.Zero;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            npc.velocity *= 0.97f;
            A += 1;
            if((npc.Center - player.Center).Length() > 300)
            {
                if(A % 90 == 0)
                {
                    npc.velocity += (player.Center - npc.Center).RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) / (player.Center - npc.Center).Length() * 12f;
                }
                B = 0;
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) * 0.05f + R * 0.95f;
                R = npc.rotation % (float)(Math.PI * 2);
            }
            else
            {
                B += 1;
                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 12f;
                v3 = v;
                npc.rotation = R * 0.95f + (float)Math.Atan2(v.Y, v.X) * 0.05f;
                R = npc.rotation % (float)(Math.PI * 2);
                if (B >= 99)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("RedWave"), npc.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                    B = 0;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 37, 1f, 0f);
            if (npc.life <= 0)
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
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/ExploreMonster3Glow").Width, (float)(base.mod.GetTexture("NPCs/ExploreMonster3Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/ExploreMonster3Glow"), vector2, new Rectangle?(base.npc.frame), new Color(255, 255, 255, 0), base.npc.rotation, vector, 1f, effects, 0f);
            if(B > 0)
            {
                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/RedCircleQuarter"), vector2 + v3 * (B - B % 10) / 20f, null, new Color(0.8f * (255 - npc.alpha) / 255f, 0.8f * (255 - npc.alpha) / 255f, 0.8f * (255 - npc.alpha) / 255f, 0), base.npc.rotation, new Vector2(125, 125), (B - B % 10) / 20f, effects, 0f);
            }
            return;
        }
    }
}
