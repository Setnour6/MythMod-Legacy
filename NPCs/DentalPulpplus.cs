using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class DentalPulpplus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("牙髓");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "牙髓");
        }
        private Texture2D[] T = new Texture2D[6];
        private int n = 0;
        private Vector2 drawPos = new Vector2(0, 90);
        private bool Attack = false;
        private float X = 0;
        private bool St = true;
        public override void SetDefaults()
        {
            NPC.behindTiles = true;

            base.NPC.damage = 0;
            base.NPC.width = 2;
            base.NPC.height = 2;
            base.NPC.defense = 0;
            base.NPC.lifeMax = 1;
            base.NPC.knockBackResist = 0f;
            base.NPC.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
            base.NPC.alpha = 255;
            base.NPC.boss = false;
            base.NPC.lavaImmune = true;
            base.NPC.noGravity = false;
            base.NPC.noTileCollide = false;
            base.NPC.HitSound = SoundID.NPCHit1;
            base.NPC.dontTakeDamage = true;
        }
        public override void AI()
        {
            Player player = Main.player[base.NPC.target];
            if (St)
            {
                NPC.localAI[0] = 0;
                St = false;
            }
            base.NPC.localAI[0] += 1;
            bool expertMode = Main.expertMode;
            float num6 = expertMode ? 5f : 3f;
            if (base.NPC.localAI[0] >= 2)
            {
                if ((base.NPC.collideY || base.NPC.collideX) && !Attack)
                {
                    NPC.velocity *= 0;
                }
                if (NPC.velocity.Length() == 0 && !Attack)
                {
                    int type = base.Mod.Find<ModProjectile>("CrimsonTusk1plus").Type;
                    int num7 = Projectile.NewProjectile((int)base.NPC.Center.X, (int)base.NPC.Center.Y - 12, 0, 0, type, (int)(8 * num6), 2f, Main.myPlayer, 0f, 0f);
                    X = 1;
                    NPC.alpha = 0;
                    n = Main.rand.Next(6);
                    Attack = true;
                }
            }

            if (X == 1 && drawPos.Y > 0.05f)
            {
                drawPos.Y *= 0.9f;
            }
            if (drawPos.Y <= 0.05)
            {
                X = 2;
            }
            if (X == 2)
            {
                drawPos.Y += 1f;
                if (drawPos.Y > 92)
                {
                    NPC.active = false;
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Color color = Lighting.GetColor((int)((NPC.Center.X / 16d) + drawPos.X), (int)((NPC.Center.Y / 16d) + drawPos.Y - 30));
            color = NPC.GetAlpha(color) * ((255 - NPC.alpha) / 255f);
            T[n] = Mod.GetTexture("Projectiles/BloodyTusk/Tuskplus" + n.ToString());
            if(color.R + color.G + color.B > 0.05f)
            {
                Main.spriteBatch.Draw(T[n], NPC.position - Main.screenPosition + drawPos - new Vector2(0, 30), null, color, base.NPC.rotation, new Vector2(T[n].Width / 2f, T[n].Height / 2f), 1f, SpriteEffects.None, 0f);
            }

            return false;
        }
    }
}
