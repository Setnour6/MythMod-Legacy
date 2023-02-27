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
			base.DisplayName.SetDefault("钻地喷花");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "钻地喷花");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.damage = 182;
			base.npc.width = 34;
			base.npc.height = 42;
			base.npc.defense = 90;
			base.npc.lifeMax = 2600;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            this.banner = base.npc.type;
            npc.behindTiles = true;
            //this.bannerItem = base.mod.ItemType("青苹果糖史莱姆Banner");
        }
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
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
            if (Main.netMode != 1 && base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻地喷花碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻地喷花碎块2"), 1f);
            }
        }
        public override void AI()
        {
            npc.localAI[0] += 1;
            int pl = Player.FindClosest(npc.Center, 1, 1);
            if(npc.localAI[0] < 300 && npc.localAI[0] % 3 == 0 && npc.collideY)
            {
                float vX = Main.rand.NextFloat(-1.5f, 1.5f);
                Projectile.NewProjectile(npc.Center.X, npc.Top.Y, vX, -Main.rand.NextFloat(3f, 8f) + Math.Abs(vX * 2), mod.ProjectileType("EruptWork"), 75, 0);
            }
            if(npc.localAI[0] >= 300 && npc.localAI[0] < 326)
            {
                npc.noTileCollide = true;
                if (npc.velocity.Y < 255)
                {
                    npc.alpha += 10;
                }
                else
                {
                    npc.alpha = 255;
                }
            }
            if(npc.localAI[0] == 326)
            {
                npc.position.X = Main.player[pl].position.X + Main.rand.Next(-150, 150);
            }
            if(npc.localAI[0] >= 326)
            {
                npc.velocity.Y -= 0.3f;
                npc.noGravity = true;
                if (npc.alpha >= 10)
                {
                    npc.alpha -= 10;
                }
                else
                {
                    npc.alpha = 0;
                }
                if (npc.position.Y < Main.player[pl].position.Y + 150)
                {
                    npc.noGravity = false;
                    npc.noTileCollide = false;
                }
                if(npc.collideY && !npc.noTileCollide)
                {
                    npc.localAI[0] = 0;
                }
            }
        }
        public override void NPCLoot()
		{
		}
    }
}
