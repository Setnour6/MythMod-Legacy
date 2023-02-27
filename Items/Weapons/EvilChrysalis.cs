using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
	// Token: 0x02000363 RID: 867
    public class EvilChrysalis : ModItem
	{
		// Token: 0x060010A9 RID: 4265 RVA: 0x00007320 File Offset: 0x00005520
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Death");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "邪茧法杖");
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0007B4A8 File Offset: 0x000796A8
		public override void SetDefaults()
		{
			base.item.damage = 18;
			base.item.magic = true;
			base.item.mana = 12;
			base.item.width = 56;
			base.item.height = 58;
			base.item.useTime = 27;
			base.item.useAnimation = 27;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 1.5f;
			base.item.value = 3000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
			base.item.shoot = mod.ProjectileType("CorruptMoth");
            base.item.shootSpeed = 4f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EvilScaleDust", 8); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenWingOfMoth", 12); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1); //����һ������
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(position.X + speedX * 8f, position.Y + speedY * 8f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}
