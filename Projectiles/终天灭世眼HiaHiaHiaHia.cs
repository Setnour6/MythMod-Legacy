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


namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 终天灭世眼HiaHiaHiaHia : ModProjectile
	{
        private int num = 0;
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("终天灭世眼");
			Main.projFrames[base.Projectile.type] = 3;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 110;
			base.Projectile.height = 110;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 1073741824;
			base.Projectile.alpha = 0;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (NPC.CountNPCS(Mod.Find<ModNPC>("终天灭世眼").Type) < 1 && mplayer.ZTMSY)
            {
                NPC.NewNPC((int)Projectile.Center.X, (int)Projectile.Center.Y, Mod.Find<ModNPC>("终天灭世眼").Type, 0, 0f, 0f, 0f, 0, 254);
                num += 1;
                Color messageColor = new Color(255, 0, 0);
                Main.NewText(Language.GetTextValue("勿作弊"), messageColor);
            }
            if(num > 100)
            {
                Player player = Main.player[Main.myPlayer];
                player.lastDeathPostion = player.Center;
                player.lastDeathTime = DateTime.Now;
                player.showLastDeath = true;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.lostCoinString = Main.ValueToCoins(player.lostCoins);
                }
                SoundEngine.PlaySound(SoundID.PlayerKilled, player.position);
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
                Color messageColor = new Color(255, 0, 0);
                Main.NewText(Language.GetTextValue("作弊没有好下场·"), messageColor);
            }
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}
