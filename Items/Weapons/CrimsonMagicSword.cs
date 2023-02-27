using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class CrimsonMagicSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("附魔血剑");
            DisplayName.SetDefault("附魔血剑");
        }
        public override void SetDefaults()
        {
            item.damage = 18;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 42;
            item.rare = 2;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 8;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("MagicTusk");
            item.shootSpeed = 7f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 24);
            recipe.AddIngredient(989, 1); 
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v = new Vector2(speedX, speedY);
            for (int k = -3; k < 3; k++)
            {
                Vector2 v2 = v.RotatedBy(k / 11.5f);
                int u = Projectile.NewProjectile(position.X, position.Y, v2.X, v2.Y, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}
