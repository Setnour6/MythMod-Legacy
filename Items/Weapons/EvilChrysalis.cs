using System;
using Terraria;
using Terraria.DataStructures;
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
            // base.DisplayName.SetDefault("Death");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "邪茧法杖");
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0007B4A8 File Offset: 0x000796A8
		public override void SetDefaults()
		{
			base.Item.damage = 18;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 56;
			base.Item.height = 58;
			base.Item.useTime = 27;
			base.Item.useAnimation = 27;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 3000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
			base.Item.shoot = Mod.Find<ModProjectile>("CorruptMoth").Type;
            base.Item.shootSpeed = 4f;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "EvilScaleDust", 8); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenWingOfMoth", 12); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for(int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(position.X + speedX * 8f, position.Y + speedY * 8f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}
