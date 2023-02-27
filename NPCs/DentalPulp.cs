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
    public class DentalPulp : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("牙髓");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "牙髓");
		}
        private Texture2D[] T = new Texture2D[8];
        private int n = 0;
        private Vector2 drawPos = new Vector2(0, 50);
        private bool Attack = false;
        private float X = 0;
        private bool St = true;
        public override void SetDefaults()
		{
            npc.behindTiles = true;

            base.npc.damage = 0;
			base.npc.width = 2;
			base.npc.height = 2;
			base.npc.defense = 0;
			base.npc.lifeMax = 1;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 255;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.dontTakeDamage = true;
		}
		public override void AI()
        {
			Player player = Main.player[base.npc.target];
            if(St)
            {
                npc.localAI[0] = 0;
                St = false;
            }
			base.npc.localAI[0] += 1;
			bool expertMode = Main.expertMode;
			float num6 = expertMode ? 5f : 3f;
			if(base.npc.localAI[0] >= 2)
			{
	    		if ((base.npc.collideY || base.npc.collideX) && !Attack)
                {
                    npc.velocity *= 0;
	    		}
                if (npc.velocity.Length() == 0 && !Attack)
                {
                    int type = base.mod.ProjectileType("CrimsonTusk1");
                    int num7 = Projectile.NewProjectile((int)base.npc.Center.X, (int)base.npc.Center.Y - 12, 0, 0, type, (int)(8 * num6), 2f, Main.myPlayer, 0f, 0f);
                    X = 1;
                    npc.alpha = 0;
                    n = Main.rand.Next(8);
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
                drawPos.Y += 0.5f;
                if (drawPos.Y > 52)
                {
                    npc.active = false;
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color color = Lighting.GetColor((int)((npc.Center.X / 16d) + drawPos.X), (int)((npc.Center.Y / 16d) + drawPos.Y - 16));
            color = npc.GetAlpha(color) * ((255 - npc.alpha) / 255f);
            T[n] = mod.GetTexture("Projectiles/BloodyTusk/Tusk" + n.ToString());

            Main.spriteBatch.Draw(T[n], npc.position - Main.screenPosition + drawPos - new Vector2(0, 16), null, color, base.npc.rotation, new Vector2(T[n].Width / 2f, T[n].Height / 2f), 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}
