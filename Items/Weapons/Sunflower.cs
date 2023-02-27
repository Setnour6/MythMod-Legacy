using Terraria.DataStructures;
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
            Item.glowMask = GetGlowMask;
            Item.useStyle = 1;
			Item.shootSpeed = 9f;
			Item.shoot = Mod.Find<ModProjectile>("Sunflower").Type;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 46;
			Item.height = 46;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = 1;
            Item.damage = 11;
            Item.autoReuse = false;
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
			Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
			modRecipe.AddIngredient(63, 8);
            modRecipe.requiredTile[0] = 16;
			modRecipe.Register();
		}
	}
}
