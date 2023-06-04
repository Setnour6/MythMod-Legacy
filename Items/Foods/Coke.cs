using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Coke : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("可乐");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.damage = 60;
            base.Item.crit = 15;
            base.Item.width = 20;
            base.Item.height = 32;
            base.Item.useTime = 24;
            base.Item.useAnimation = 24;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 1, 0, 0);
            base.Item.shoot = base.Mod.Find<ModProjectile>("Coke").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 6;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 17f;
        }
	}
}
