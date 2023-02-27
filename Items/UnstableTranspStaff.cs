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

namespace MythMod.Items
{
    public class UnstableTranspStaff : ModItem
    {
        private bool num = true;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("不稳定的传送杖");
            base.Tooltip.SetDefault("Teleport you to your mouse's mirrorpoint of you");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "不稳定的传送杖");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "传送到鼠标关于你的中心对称点");
        }
        public override void SetDefaults()
        {
            base.Item.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            base.Item.width = 32;
            base.Item.height = 32;
            base.Item.useTime = 25;
            base.Item.useAnimation = 25;
            base.Item.useTurn = true;
            base.Item.useStyle = 1;
            base.Item.value = 5000;
            base.Item.UseSound = SoundID.Item1;
            base.Item.autoReuse = true;
            base.Item.rare = 6;
        }
        public override void AddRecipes()
        {

        }
        public override bool AltFunctionUse(Player player)
        { return true; }
        public override bool CanUseItem(Player player)
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.altFunctionUse == 2)
            {
                //if(Main.tile[(int)((Main.mouseX - Main.screenWidth / 2f + player.Center.X) * 0.0625f), (int)((Main.mouseY - Main.screenHeight / 2f + player.Center.Y) * 0.0625f)].type == -1)
                //{
                //player.position = player.position + new Vector2(Main.mouseX - Main.screenWidth / 2f, Main.mouseY - Main.screenHeight / 2f);
                //}
            }
            else
            {
                for (int i = 0; i < 45; i++)
                {
                    Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y), 32, 96, 131, 0f, 0f, 0, default(Color), 0.8f);
                }
                player.position = player.position - new Vector2(Main.mouseX - Main.screenWidth / 2f, Main.mouseY - Main.screenHeight / 2f);
                if (modPlayer.LowDisorder == true && num)
                {
                    player.statLife -= player.statLifeMax / 7;
                    if (player.statLife <= 0)
                    {
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
                    }
                }
                player.AddBuff(base.Mod.Find<ModBuff>("LowDisorder").Type, 300, true);
            }
            //string key = new Vector2(Main.mouseX, Main.mouseY).ToString();
            //Color messageColor = Color.Purple;
            //Main.NewText(Language.GetTextValue(key), messageColor);
            return base.CanUseItem(player);
        }
    }
}
