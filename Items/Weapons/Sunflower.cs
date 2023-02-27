using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;

namespace MythMod.Items.Weapons
{
	public class Sunflower : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("向日飞盘");
            Tooltip.AddTranslation(GameCulture.Chinese, "白天威力提升,夜晚威力下降");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.useStyle = 1;
			item.shootSpeed = 9f;
			item.shoot = mod.ProjectileType("Sunflower");
            item.melee = true;
            item.width = 46;
			item.height = 46;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 24;
			item.useTime = 24;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = 1;
            item.damage = 11;
            item.autoReuse = false;
        }
        /*public override void UpdateInventory(Player player)
        {
            if(Main.dayTime)
            {
                item.damage = 12;
            }
            else
            {
                item.damage = 10;
            }
        }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + speedX * 3f, position.Y + speedY * 3f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        /*public override bool CanUseItem(Player player)
        {
            return true;
        }*/
        public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(63, 8);
            modRecipe.requiredTile[0] = 16;
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
