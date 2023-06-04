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
    public class LemonSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("berry Sweat Slime");
			Main.npcFrameCount[base.NPC.type] = 2;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "柠檬糖史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 1;
			base.NPC.damage = 182;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 90;
			base.NPC.lifeMax = 600;
			base.NPC.knockBackResist = 0f;
			this.AnimationType = 81;
			base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.scale = 0.85f;
            base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("LemonslimeBanner").Type;
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
        }
        private int Ene = 0;
        public override void AI()
        {
            NPC.ai[0] += 0.05f;
            if (base.NPC.collideX && base.NPC.collideY)
            {
                NPC.active = false;
            }
            if (NPC.velocity.Length() < 0.05f)
            {
                Ene += 1;
            }
            if (Ene == 180)
            {
                for (int g = 0; g < 6; g++)
                {
                    Vector2 v = new Vector2(0, -9 * Main.rand.NextFloat(0.5f, 1f)).RotatedBy(Main.rand.NextFloat(-0.5f, 0.5f));
                    Projectile.NewProjectile(NPC.Center.X + v.X, NPC.Center.Y + v.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("LemonProj").Type, NPC.damage, 0, Main.myPlayer, 0, 0f);
                }
                Ene = 0;
            }
        }
        public override void OnKill()
        {
            if (Main.rand.Next(50) == 1)
            {
                int type = 0;
                switch (Main.rand.Next(1, 4))
                {
                    case 1:
                        type = base.Mod.Find<ModItem>("LemonGun").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("LemonStaff").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("LemonswKnife").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
        }
    }
}
