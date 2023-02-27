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
			base.DisplayName.SetDefault("鲜血獠牙残骸");
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
			base.npc.damage = 0;
			base.npc.width = 110;
			base.npc.height = 132;
			base.npc.defense = 0;
			base.npc.lifeMax = 1;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 0;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.aiStyle = -1;
            npc.behindTiles = true;
            this.aiType = -1;
			base.npc.dontTakeDamage = true;
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color color = Lighting.GetColor((int)(npc.Center.X / 16d), (int)(npc.Center.Y / 16d));
            color = npc.GetAlpha(color) * ((255 - npc.alpha) / 255f);

            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskBroken"), npc.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}
