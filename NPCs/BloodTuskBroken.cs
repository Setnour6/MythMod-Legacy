using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{ 
    public class BloodTuskBroken : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("鲜血獠牙残骸");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "鲜血獠牙残骸");
		}
        private bool X = true;
        private int num10;
        private float num13;
        private bool T = false;
        private Vector2[] V = new Vector2[9];
        private Vector2[] VMax = new Vector2[9];
        private int[] I = new int[9];
        public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 110;
			base.NPC.height = 132;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 1;
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.boss = false;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.aiStyle = -1;
            NPC.behindTiles = true;
            this.AIType = -1;
			base.NPC.dontTakeDamage = true;
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Color color = Lighting.GetColor((int)(NPC.Center.X / 16d), (int)(NPC.Center.Y / 16d));
            color = NPC.GetAlpha(color) * ((255 - NPC.alpha) / 255f);

            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskBroken"), NPC.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}
