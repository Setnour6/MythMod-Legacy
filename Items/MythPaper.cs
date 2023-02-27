using System;
using Terraria;
using Terraria.DataStructures;
using MythMod.UI.YinYangLife;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items
{
    public class MythPaper : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("神话卷轴");
            base.Tooltip.SetDefault("里面压抑着无数先辈勇士和邪恶势力相互的血海深仇和毁天灭地的烈怒\n使用它，为了无上的荣耀和财富，并带来极其可怕的诅咒降临你身\n如果你怕死，赶紧扔了它！\n \n释放了这个卷轴的力量后，你必再无宁日\n这会带来一切的仇视和敌意\nBoss金币掉落提升100倍\nBoss将掉落宝藏箱，战利品变得更加丰厚\nDebuff的持续时间会延长\n你将获得阴寿命和阳寿命各30点，死亡时阴阳寿命各-1\n当你的阴寿命或阳寿命为0时，你的生命降低为20\n你死亡时，掉光所有钱\n不要在Boss存活时使用,否则所有被封印的能量会瞬间向你袭来\n谨慎使用！");
        }
        public override void SetDefaults()
        {
            base.item.width = 28;
            base.item.height = 28;
            base.item.expert = true;
            base.item.useAnimation = 45;
            base.item.useTime = 45;
            base.item.useStyle = 4;
            base.item.UseSound = SoundID.Item105;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.expertMode;
        }
        public override bool UseItem(Player player)
        {
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
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
                        Dust.NewDust(player.position, player.width, player.height, 205, 0f, -2f, 0, default(Color), 1f);
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
                    Main.npc[i].active = false;
                    Main.npc[i].netUpdate = true;
                }
            }
            if (!MythWorld.Myth)
            {
                Mod mod = ModLoader.GetMod("MythMod");
                MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                MythWorld.Myth = true;
                MythWorld.MythIndex = 1;
                mplayer.YinLife += 30;
                mplayer.YangLife += 30;
                YinYangLife.Open = true;
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("EvilOff"), 1, false, 0, false, false);
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("EvilOn"), 1, false, 0, false, false);
                item.stack--;
            }
            Color Purple = Color.Purple;
            Color Purple2 = Color.Purple;
            return !MythWorld.Myth;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this, 1);//制作一个材料
            recipe.AddRecipe();
        }
    }
}
