using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x02000363 RID: 867
    public class TuskStaff : ModItem
	{
		// Token: 0x060010A9 RID: 4265 RVA: 0x00007320 File Offset: 0x00005520
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Death");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血腥獠牙杖");
			base.Tooltip.SetDefault("让地面长出獠牙");
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "BoneLiquid", 8); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenTooth", 12); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        // Token: 0x060010AA RID: 4266 RVA: 0x0007B4A8 File Offset: 0x000796A8
        public override void SetDefaults()
		{
			base.Item.damage = 31;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 7;
			base.Item.width = 56;
			base.Item.height = 58;
			base.Item.useTime = 60;
			base.Item.useAnimation = 60;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = 3000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
			base.Item.shoot = Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
			base.Item.shootSpeed = 1f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff1").Type;
				break;
			case 2:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff2").Type;
				break;
            case 3:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff3").Type;
                break;
            case 4:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
                break;
			}
			Projectile.NewProjectile(position.X - 100f + Main.rand.Next(-50,50), position.Y - 100f, 0, 2.5f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff1").Type;
				break;
			case 2:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff2").Type;
				break;
            case 3:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff3").Type;
                break;
            case 4:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
                break;
			}
			Projectile.NewProjectile(position.X + 100f + Main.rand.Next(-50,50), position.Y - 100f, 0, 2.5f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff1").Type;
				break;
			case 2:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff2").Type;
				break;
            case 3:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff3").Type;
                break;
            case 4:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
                break;
			}
			Projectile.NewProjectile(position.X - 200f + Main.rand.Next(-50,50), position.Y - 100f, 0, 1.0f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff1").Type;
				break;
			case 2:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff2").Type;
				break;
            case 3:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff3").Type;
                break;
            case 4:
                type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
                break;
			}
			Projectile.NewProjectile(position.X + 200f + Main.rand.Next(-50,50), position.Y - 100f, 0, 1.0f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
		// Token: 0x060010AB RID: 4267 RVA: 0x0007B59C File Offset: 0x0007979C
	}
}
