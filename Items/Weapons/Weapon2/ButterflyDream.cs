using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Weapons.Weapon2
{
    public class ButterflyDream : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "蓝蝶幻梦");
        }
        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.mana = 16;
            item.width = 48;
            item.height = 48;
            item.useTime = 15;
            item.rare = 7;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 1;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("ButterflyDream");
            item.shootSpeed = 8f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 5; i++)
            {
                Projectile.NewProjectile(position.X + speedX * 1f, position.Y + speedY * 1f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(mod.ItemType("EvilChrysalis"), 1);
            modRecipe.AddIngredient(1611, 3);
            modRecipe.requiredTile[0] = 134;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
