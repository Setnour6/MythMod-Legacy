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
			base.npc.damage = 0;
			base.npc.width = 1;
			base.npc.height = 1;
			base.npc.defense = 0;
			base.npc.lifeMax = 9999999;
			base.npc.knockBackResist = 0;
			base.npc.alpha = 0;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
            base.npc.aiStyle = -1;
            npc.dontTakeDamage = true;
        }
        private int time2 = 300;
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            time2 -= 1;
            if(time2 < -60)
            {
                npc.active = false;
                mplayer.DONTTAKEDAMDGE = false;
            }
            if((player.Center - npc.Center).Length() <= 300 && npc.active)
            {
                mplayer.DONTTAKEDAMDGE = true;
            }
            else
            {
                mplayer.DONTTAKEDAMDGE = false;
            }
            npc.velocity *= 0;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            float QD = time2 > 0 ? 3 : (time2 + 60) / 20f;
            if (QD > 0)
            {
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);

                var center = npc.Center - Main.screenPosition;
                float num89 = 0f;
                if (npc.ai[3] > 0f && npc.ai[3] <= 30f)
                {
                    num89 = 1f - npc.ai[3] / 30f;
                }
                if(time2 > 0)
                {
                    DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 1200, 600), new Color(226, 136, 0, 0) * (QD * 0.8f), npc.rotation, new Vector2(600f, 300f), npc.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
                    GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
                    GameShaders.Misc["ForceField"].Apply(drawData);
                    drawData.Draw(Main.spriteBatch);
                }
                else
                {
                    DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, (int)(1200 + time2 * time2 * 0.6f), (int)(600 + time2 * time2 * 0.3f)), new Color(226, 136, 0, 0) * (QD * 0.8f), npc.rotation, new Vector2(600f + time2 * time2 * 0.3f, 300f + time2 * time2 * 0.15f), npc.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
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
