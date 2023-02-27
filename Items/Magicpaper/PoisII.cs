using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class PoisII : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("二阶毒池符咒");
            Tooltip.SetDefault("在正下方释放一个剧毒池,释放出毒气\n液体中无效\n冷却10s");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.width = 26;//长度
            item.height = 40;//高度
            item.maxStack = 999;//最大叠加
            item.damage = 280;
            item.value = 5000;//价值
            item.rare = 2;//稀有度
            base.item.useStyle = 1;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.MagicCool == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 25, mod.ProjectileType("PoisonSummon"), 0, 0.5f, Main.myPlayer, 280, 11);
                mplayer.MagicCool += 600;
                item.stack--;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PoisI", 3);
            recipe.AddIngredient(68, 20);
            recipe.AddIngredient(521, 15);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "PoisI", 3);
            recipe2.AddIngredient(1330, 20);
            recipe2.AddIngredient(521, 15);
            recipe2.requiredTile[0] = 26;
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}