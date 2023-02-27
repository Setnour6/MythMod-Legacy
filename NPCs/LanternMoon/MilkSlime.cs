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
    public class MilkSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Milk Sweat Slime");
			Main.npcFrameCount[base.npc.type] = 2;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "奶糖史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 1;
			base.npc.damage = 182;
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 90;
			base.npc.lifeMax = 600;
			base.npc.knockBackResist = 0f;
			this.animationType = 81;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.npc.alpha = 0;
            base.npc.scale = 0.85f;
            base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("MilkSlimeBanner");
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
        }
        private int Ene = 0;
        public override void AI()
        {
            npc.ai[0] += 0.05f;
            if (base.npc.collideX && base.npc.collideY)
            {
                npc.active = false;
            }
            if (npc.velocity.Length() < 0.05f)
            {
                Ene += 1;
            }
            if (Ene == 180)
            {
                for (int g = 0; g < 6; g++)
                {
                    Vector2 v = new Vector2(0, -9 * Main.rand.NextFloat(0.5f, 1f)).RotatedBy(Main.rand.NextFloat(-0.5f, 0.5f));
                    Projectile.NewProjectile(npc.Center.X + v.X, npc.Center.Y + v.Y, v.X, v.Y, base.mod.ProjectileType("MilkProj"), npc.damage, 0, Main.myPlayer, 0, 0f);
                }
                Ene = 0;
            }
        }
        public override void NPCLoot()
		{
		}
    }
}
