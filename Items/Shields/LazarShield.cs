using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Shields
{
	public class LazarShield : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.AddTranslation(GameCulture.Chinese, "拿在手上才能获得防御,并且受到伤害减少25%\n有概率挡住盾牌方向的弹幕,越慢的越容易被挡住");
            base.SetStaticDefaults();
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
            DisplayName.SetDefault("激光盾");
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 42;
            item.height = 42;
            item.maxStack = 1;
            item.flame = true;
            item.value = 10000;
            item.defense = 40;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 5)
            {
                mplayer.SD = 5;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, mod.ProjectileType("LazarShield"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
            mplayer.AddDef = 40;
            mplayer.DisHurt = 25;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LazarBattery"), 5);
            recipe.AddIngredient(mod.ItemType("IronShield"), 1);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}