using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血腥獠牙杖");
			base.Tooltip.SetDefault("让地面长出獠牙");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 8); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenTooth", 12); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1); //����һ������
            recipe.AddRecipe();
        }
        // Token: 0x060010AA RID: 4266 RVA: 0x0007B4A8 File Offset: 0x000796A8
        public override void SetDefaults()
		{
			base.item.damage = 31;
			base.item.magic = true;
			base.item.mana = 7;
			base.item.width = 56;
			base.item.height = 58;
			base.item.useTime = 60;
			base.item.useAnimation = 60;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = 3000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
			base.item.shoot = mod.ProjectileType("CrimsonTuskStaff4");
			base.item.shootSpeed = 1f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.mod.ProjectileType("CrimsonTuskStaff1");
				break;
			case 2:
                type = base.mod.ProjectileType("CrimsonTuskStaff2");
				break;
            case 3:
                type = base.mod.ProjectileType("CrimsonTuskStaff3");
                break;
            case 4:
                type = base.mod.ProjectileType("CrimsonTuskStaff4");
                break;
			}
			Projectile.NewProjectile(position.X - 100f + Main.rand.Next(-50,50), position.Y - 100f, 0, 2.5f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.mod.ProjectileType("CrimsonTuskStaff1");
				break;
			case 2:
                type = base.mod.ProjectileType("CrimsonTuskStaff2");
				break;
            case 3:
                type = base.mod.ProjectileType("CrimsonTuskStaff3");
                break;
            case 4:
                type = base.mod.ProjectileType("CrimsonTuskStaff4");
                break;
			}
			Projectile.NewProjectile(position.X + 100f + Main.rand.Next(-50,50), position.Y - 100f, 0, 2.5f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.mod.ProjectileType("CrimsonTuskStaff1");
				break;
			case 2:
                type = base.mod.ProjectileType("CrimsonTuskStaff2");
				break;
            case 3:
                type = base.mod.ProjectileType("CrimsonTuskStaff3");
                break;
            case 4:
                type = base.mod.ProjectileType("CrimsonTuskStaff4");
                break;
			}
			Projectile.NewProjectile(position.X - 200f + Main.rand.Next(-50,50), position.Y - 100f, 0, 1.0f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			switch (Main.rand.Next(0 , 5))
			{
			case 1:
                type = base.mod.ProjectileType("CrimsonTuskStaff1");
				break;
			case 2:
                type = base.mod.ProjectileType("CrimsonTuskStaff2");
				break;
            case 3:
                type = base.mod.ProjectileType("CrimsonTuskStaff3");
                break;
            case 4:
                type = base.mod.ProjectileType("CrimsonTuskStaff4");
                break;
			}
			Projectile.NewProjectile(position.X + 200f + Main.rand.Next(-50,50), position.Y - 100f, 0, 1.0f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
		// Token: 0x060010AB RID: 4267 RVA: 0x0007B59C File Offset: 0x0007979C
	}
}
