using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
	// Token: 0x020005C2 RID: 1474
    public class SulphurStaff : ModItem
	{
		// Token: 0x060019F2 RID: 6642 RVA: 0x00008ED2 File Offset: 0x000070D2
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("硫磺法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺法杖");
		}
		public override void SetDefaults()
		{
			base.item.damage = 234;
			base.item.magic = true;
			base.item.mana = 15;
			base.item.width = 58;
			base.item.height = 68;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 9, 0, 0);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("SulfurMeltingBall");
			base.item.shootSpeed = 6f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = base.item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 15, (float)position.Y + speedY * 15, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
		{
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 16);
            modRecipe.AddIngredient(null, "Sulfur", 64);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
	}
}
