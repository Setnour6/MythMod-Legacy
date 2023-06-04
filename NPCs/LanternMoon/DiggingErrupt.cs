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

namespace MythMod.NPCs.LanternMoon
{
    public class DiggingErrupt : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("钻地喷花");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "钻地喷花");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 182;
			base.NPC.width = 34;
			base.NPC.height = 42;
			base.NPC.defense = 90;
			base.NPC.lifeMax = 2600;
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
            this.Banner = base.NPC.type;
            NPC.behindTiles = true;
            //this.bannerItem = base.mod.ItemType("青苹果糖史莱姆Banner");
        }
		public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 50;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 50;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 25;
                    }
                }
            }
            if (Main.netMode != 1 && base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/钻地喷花碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/钻地喷花碎块2"), 1f);
            }
        }
        public override void AI()
        {
            NPC.localAI[0] += 1;
            int pl = Player.FindClosest(NPC.Center, 1, 1);
            if(NPC.localAI[0] < 300 && NPC.localAI[0] % 3 == 0 && NPC.collideY)
            {
                float vX = Main.rand.NextFloat(-1.5f, 1.5f);
                Projectile.NewProjectile(NPC.Center.X, NPC.Top.Y, vX, -Main.rand.NextFloat(3f, 8f) + Math.Abs(vX * 2), Mod.Find<ModProjectile>("EruptWork").Type, 75, 0);
            }
            if(NPC.localAI[0] >= 300 && NPC.localAI[0] < 326)
            {
                NPC.noTileCollide = true;
                if (NPC.velocity.Y < 255)
                {
                    NPC.alpha += 10;
                }
                else
                {
                    NPC.alpha = 255;
                }
            }
            if(NPC.localAI[0] == 326)
            {
                NPC.position.X = Main.player[pl].position.X + Main.rand.Next(-150, 150);
            }
            if(NPC.localAI[0] >= 326)
            {
                NPC.velocity.Y -= 0.3f;
                NPC.noGravity = true;
                if (NPC.alpha >= 10)
                {
                    NPC.alpha -= 10;
                }
                else
                {
                    NPC.alpha = 0;
                }
                if (NPC.position.Y < Main.player[pl].position.Y + 150)
                {
                    NPC.noGravity = false;
                    NPC.noTileCollide = false;
                }
                if(NPC.collideY && !NPC.noTileCollide)
                {
                    NPC.localAI[0] = 0;
                }
            }
        }
        public override void OnKill()
		{
		}
    }
}
