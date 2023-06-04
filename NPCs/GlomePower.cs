using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class GlomePower : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("石巨人能源");
            Main.npcFrameCount[base.NPC.type] = 6;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "石巨人能源");
        }
        public override void SetDefaults()
        {
            base.NPC.damage = 0;
            base.NPC.width = 24;
            base.NPC.height = 48;
            base.NPC.defense = 0;
            base.NPC.lifeMax = 4000;
            base.NPC.HitSound = SoundID.NPCHit37;
            base.NPC.noGravity = true;
            base.NPC.knockBackResist = 0f;
        }
        private float num1 = -10;
        private bool M = true;
        private float Omega = 0;
        public override void AI()
        {
            if (M)
            {
                NPC.rotation = Main.rand.NextFloat((float)Math.PI * 2);
                NPC.velocity = new Vector2(0, -14).RotatedBy(Math.PI * (3 - NPC.ai[0]) / 4f);
                M = false;
            }
            NPC.velocity *= 0.96f;
            num1 += 0.08f;
            NPC.rotation += Omega;
            Omega *= 0.99f;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
        }
        public override void FindFrame(int frameHeight)
        {
            if (num1 < 5)
            {
                if (num1 < 0)
                {
                    base.NPC.frame.Y = 240;
                }

                else
                {
                    base.NPC.frame.Y = 240 - (int)num1 * 48;
                }
            }
            else
            {
                base.NPC.frame.Y = 0;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/石巨人能源Glow2").Width, (float)(base.Mod.GetTexture("NPCs/石巨人能源Glow2").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = new Color(0.99f, 0.99f, 0.99f, 0);
            if (num1 % 200 >= NPC.ai[0] * 40 - 40 && num1 % 200 < NPC.ai[0] * 40)
            {
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/石巨人能源Glow2"), vector2, new Rectangle?(base.NPC.frame), color * (Math.Abs((num1 % 200 - NPC.ai[0] * 40 + 20) / 10f) - 1), base.NPC.rotation, vector, 1f, effects, 0f);
                NPC.chaseable = true;
            }
            else
            {
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/石巨人能源Glow2"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
                NPC.chaseable = false;
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            Omega = Main.rand.NextFloat(-0.4f, 0.4f);
            if (NPC.life <= 0)
            {
                if (num1 % 200 >= NPC.ai[0] * 40 - 40 && num1 % 200 < NPC.ai[0] * 40)
                {
                    SoundEngine.PlaySound(SoundID.Item27.WithVolumeScale(0.5f), new Vector2(base.NPC.position.X, base.NPC.position.Y));
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/石巨人能源碎块1"), 1f);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/石巨人能源碎块2"), 1f);
                    for (int j = 0; j < 15; j++)
                    {
                        Dust.NewDust(base.NPC.Center, 0, 0, 174, 0, 0, 0, default(Color), 1f);
                    }
                }
                else
                {
                    SoundEngine.PlaySound(SoundID.Item27.WithVolumeScale(0.5f), new Vector2(base.NPC.position.X, base.NPC.position.Y));
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/石巨人能源碎块1"), 1f);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/石巨人能源碎块2"), 1f);
                    for (int j = 0; j < 15; j++)
                    {
                        Dust.NewDust(base.NPC.Center, 0, 0, 174, 0, 0, 0, default(Color), 1f);
                    }
                    for (int j = 0; j < 15; j++)
                    {
                        Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 10.5f)).RotatedByRandom(Math.PI * 2);
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("石巨人能源").Type, 90, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }
    }
}
