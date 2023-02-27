using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Input;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Skies;

namespace MythMod.NPCs.Yuanbao
{
	public class GoldBellShield : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("金钟罩");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "金钟罩");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 1;
			base.NPC.height = 1;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 9999999;
			base.NPC.knockBackResist = 0;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
            base.NPC.aiStyle = -1;
            NPC.dontTakeDamage = true;
        }
        private int time2 = 300;
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            time2 -= 1;
            if(time2 < -60)
            {
                NPC.active = false;
                mplayer.DONTTAKEDAMDGE = false;
            }
            if((player.Center - NPC.Center).Length() <= 300 && NPC.active)
            {
                mplayer.DONTTAKEDAMDGE = true;
            }
            else
            {
                mplayer.DONTTAKEDAMDGE = false;
            }
            NPC.velocity *= 0;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
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
                if(time2 > 0)
                {
                    DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 1200, 600), new Color(226, 136, 0, 0) * (QD * 0.8f), NPC.rotation, new Vector2(600f, 300f), NPC.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                    GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                    GameShaders.Misc["ForceField"].Apply(drawData);
                    drawData.Draw(Main.spriteBatch);
                }
                else
                {
                    DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, (int)(1200 + time2 * time2 * 0.6f), (int)(600 + time2 * time2 * 0.3f)), new Color(226, 136, 0, 0) * (QD * 0.8f), NPC.rotation, new Vector2(600f + time2 * time2 * 0.3f, 300f + time2 * time2 * 0.15f), NPC.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                    GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                    GameShaders.Misc["ForceField"].Apply(drawData);
                    drawData.Draw(Main.spriteBatch);
                }
                Main.spriteBatch.End();
                Main.spriteBatch.Begin();
                return;
            }
        }
    }
}
