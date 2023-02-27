using Terraria.DataStructures;
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
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 42;
            Item.rare = 2;
            Item.useAnimation = 14;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 8;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("MagicTusk").Type;
            Item.shootSpeed = 7f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "BoneLiquid", 24);
            recipe.AddIngredient(989, 1); 
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
