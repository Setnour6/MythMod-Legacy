using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Shields
{
	public class BlackWoodShield : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.AddTranslation(GameCulture.Chinese, "拿在手上才能获得防御,并且受到伤害减少16%\n有概率挡住盾牌方向的弹幕,越慢的越容易被挡住");
            base.SetStaticDefaults();
            DisplayName.SetDefault("乌木盾");
        }
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.maxStack = 1;
            item.flame = true;
            item.value = 100;
            item.defense = 16;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 5)
            {
                mplayer.SD = 5;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, mod.ProjectileType("BlackWoodShield"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
            mplayer.AddDef = 16;
            mplayer.DisHurt = 16;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(619, 30);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}