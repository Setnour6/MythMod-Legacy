using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
	// Token: 0x02000487 RID: 1159
    public class StarrySlime : ModNPC
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Moon slime");
			Main.npcFrameCount[base.npc.type] = 2;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星空史莱姆");
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{

			base.npc.aiStyle = 1;
			base.npc.damage = 750;
			base.npc.width = 36;
			base.npc.height = 26;
			base.npc.defense = 267;
			base.npc.lifeMax = 14680;
			base.npc.knockBackResist = 0f;
			this.animationType = 81;
			base.npc.value = (float)Item.buyPrice(0, 70, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 30;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
			if (base.npc.life <= 0)
			{
				for (int j = 0; j < 20; j++)
				{
					Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
			}
		}
        public override void OnHitPlayer(Player player, int damage, bool crit)
		{
            player.lastDeathPostion = player.Center;
            player.lastDeathTime = DateTime.Now;
            player.showLastDeath = true;
            if (Main.myPlayer == player.whoAmI)
            {
                player.lostCoinString = Main.ValueToCoins(player.lostCoins);
            }
            Main.PlaySound(5, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
            player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            if (player.stoned)
            {
                player.headPosition = Vector2.Zero;
                player.bodyPosition = Vector2.Zero;
                player.legPosition = Vector2.Zero;
            }
            for (int j = 0; j < 100; j++)
            {
                Dust.NewDust(player.position, player.width, player.height, 235, 0f, -2f, 0, default(Color), 1f);
            }
            player.statLife = 0;
            player.dead = true;
            player.respawnTimer = 600;
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            player.handon = -1;
            player.handoff = -1;
            player.back = -1;
            player.front = -1;
            player.shoe = -1;
            player.waist = -1;
            player.shield = -1;
            player.neck = -1;
            player.face = -1;
            player.balloon = -1;
            player.mount.Dismount(player);
            if (Main.expertMode)
            {
               player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
            }
            player.immuneAlpha = 0;
            player.palladiumRegen = false;
            player.iceBarrier = false;
            player.crystalLeaf = false;
            PlayerDeathReason playerDeathReason = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
            NetworkText deathText = playerDeathReason.GetDeathText(player.name);
            if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
            {
                player.DropCoins();
            }
            else if (player.difficulty == 1)
            {
                player.DropItems();
            }
            else if (player.difficulty == 2)
            {
                player.DropItems();
                player.KillMeForGood();
            }
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x0010AEF8 File Offset: 0x001090F8
		public override void NPCLoot()
        {
            if (Main.rand.Next(130) == 0)
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("ShadowWithBright"), 1, false, 0, false, false);
            }
       }
	}
}
