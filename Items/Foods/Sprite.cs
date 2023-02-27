using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Sprite : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("雪碧");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.thrown = true;
            base.item.damage = 60;
            base.item.crit = 15;
            base.item.width = 20;
            base.item.height = 32;
            base.item.useTime = 24;
            base.item.useAnimation = 24;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 1, 0, 0);
            base.item.shoot = base.mod.ProjectileType("Sprite");
            base.item.noUseGraphic = true;
            base.item.rare = 6;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 17f;
        }
	}
}
