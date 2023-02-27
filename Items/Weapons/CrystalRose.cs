using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MythMod.Items.Weapons
{
    public class CrystalRose : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("璀璨晶莲");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "璀璨晶莲");
        }
        public override void SetDefaults()
        {
            base.item.damage = 600;
			base.item.magic = true;
			base.item.mana = 12;
			base.item.width = 64;
			base.item.height = 64;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 120000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("CrystalMagic");
			base.item.shootSpeed = 19f;
		}
	}
}
