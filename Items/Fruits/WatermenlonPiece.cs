using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
	// Token: 0x0200015B RID: 347
    public class WatermenlonPiece : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("西瓜片");
            // base.Tooltip.SetDefault("野生水果\n可以用来吃");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 22;
			base.Item.height = 26;
			base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000043CB File Offset: 0x000025CB
        public override void AddRecipes()
		{
			Recipe modRecipe = /* base */Recipe.Create(this.Type, 20);
            modRecipe.AddIngredient(null, "Watermenlon", 1);
			modRecipe.AddTile(18);
			modRecipe.Register();
		}
	}
}
