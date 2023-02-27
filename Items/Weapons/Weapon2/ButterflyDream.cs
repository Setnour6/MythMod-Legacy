using Terraria.DataStructures;
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
            Item.damage = 40;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 16;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 15;
            Item.rare = 7;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.UseSound = SoundID.Item1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("ButterflyDream").Type;
            Item.shootSpeed = 8f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 5; i++)
            {
                Projectile.NewProjectile(position.X + speedX * 1f, position.Y + speedY * 1f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(Mod.Find<ModItem>("EvilChrysalis").Type, 1);
            modRecipe.AddIngredient(1611, 3);
            modRecipe.requiredTile[0] = 134;
            modRecipe.Register();
        }
    }
}
