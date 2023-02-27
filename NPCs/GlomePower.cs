using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class GlomePower : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("石巨人能源");
            Main.npcFrameCount[base.npc.type] = 6;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "石巨人能源");
        }
        public override void SetDefaults()
        {
            base.npc.damage = 0;
            base.npc.width = 24;
            base.npc.height = 48;
            base.npc.defense = 0;
            base.npc.lifeMax = 4000;
            base.npc.HitSound = SoundID.NPCHit37;
            base.npc.noGravity = true;
            base.npc.knockBackResist = 0f;
        }
        private float num1 = -10;
        private bool M = true;
        private float Omega = 0;
        public override void AI()
        {
            if (M)
            {
                npc.rotation = Main.rand.NextFloat((float)Math.PI * 2);
                npc.velocity = new Vector2(0, -14).RotatedBy(Math.PI * (3 - npc.ai[0]) / 4f);
                M = false;
            }
            npc.velocity *= 0.96f;
            num1 += 0.08f;
            npc.rotation += Omega;
            Omega *= 0.99f;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override void FindFrame(int frameHeight)
        {
            if (num1 < 5)
            {
                if (num1 < 0)
                {
                    base.npc.frame.Y = 240;
                }

                else
                {
                    base.npc.frame.Y = 240 - (int)num1 * 48;
                }
            }
            else
            {
                base.npc.frame.Y = 0;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/石巨人能源Glow2").Width, (float)(base.mod.GetTexture("NPCs/石巨人能源Glow2").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = new Color(0.99f, 0.99f, 0.99f, 0);
            if (num1 % 200 >= npc.ai[0] * 40 - 40 && num1 % 200 < npc.ai[0] * 40)
            {
                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/石巨人能源Glow2"), vector2, new Rectangle?(base.npc.frame), color * (Math.Abs((num1 % 200 - npc.ai[0] * 40 + 20) / 10f) - 1), base.npc.rotation, vector, 1f, effects, 0f);
                npc.chaseable = true;
            }
            else
            {
                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/石巨人能源Glow2"), vector2, new Rectangle?(base.npc.frame), color, base.npc.rotation, vector, 1f, effects, 0f);
                npc.chaseable = false;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Omega = Main.rand.NextFloat(-0.4f, 0.4f);
            if (npc.life <= 0)
            {
                if (num1 % 200 >= npc.ai[0] * 40 - 40 && num1 % 200 < npc.ai[0] * 40)
                {
                    Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 27, 0.5f, 0f);
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/石巨人能源碎块1"), 1f);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/石巨人能源碎块2"), 1f);
                    for (int j = 0; j < 15; j++)
                    {
                        Dust.NewDust(base.npc.Center, 0, 0, 174, 0, 0, 0, default(Color), 1f);
                    }
                }
                else
                {
                    Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 27, 0.5f, 0f);
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/石巨人能源碎块1"), 1f);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/石巨人能源碎块2"), 1f);
                    for (int j = 0; j < 15; j++)
                    {
                        Dust.NewDust(base.npc.Center, 0, 0, 174, 0, 0, 0, default(Color), 1f);
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 10.5f)).RotatedByRandom(Math.PI * 2);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, base.mod.ProjectileType("石巨人能源"), 90, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }
    }
}
