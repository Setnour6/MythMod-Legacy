using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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
			// base.DisplayName.SetDefault("Moon slime");
			Main.npcFrameCount[base.NPC.type] = 2;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星空史莱姆");
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{

			base.NPC.aiStyle = 1;
			base.NPC.damage = 750;
			base.NPC.width = 36;
			base.NPC.height = 26;
			base.NPC.defense = 267;
			base.NPC.lifeMax = 14680;
			base.NPC.knockBackResist = 0f;
			this.AnimationType = 81;
			base.NPC.value = (float)Item.buyPrice(0, 70, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 30;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void HitEffect(NPC.HitInfo hit)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 59, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
			if (base.NPC.life <= 0)
			{
				for (int j = 0; j < 20; j++)
				{
					Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 59, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
			}
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
            player.lastDeathPostion = player.Center;
            player.lastDeathTime = DateTime.Now;
            player.showLastDeath = true;
            if (Main.myPlayer == player.whoAmI)
            {
                player.lostCoinString = Main.ValueToCoins(player.lostCoins);
            }
            SoundEngine.PlaySound(SoundID.PlayerKilled);
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
		public override void OnKill()
        {
            if (Main.rand.Next(130) == 0)
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("ShadowWithBright").Type, 1, false, 0, false, false);
            }
       }
	}
}
