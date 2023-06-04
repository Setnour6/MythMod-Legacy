using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class AgCoinBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("银钱手雷");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.damage = 52;
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.crit = 6;
            base.Item.width = 20;
            base.Item.height = 38;
            base.Item.useTime = 48;
            base.Item.useAnimation = 48;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 0, 99, 99);
            base.Item.shoot = base.Mod.Find<ModProjectile>("AgBomb").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 4;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 9f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
