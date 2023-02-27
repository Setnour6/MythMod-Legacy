using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class PhalaenopsisStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蝴蝶兰魔杖");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "蝴蝶兰魔杖");
		}
        public override void SetDefaults()
		{
			base.item.damage = 400;
			base.item.magic = true;
			base.item.mana = 16;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 26;
			base.item.useAnimation = 20;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 12000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("Phalaenopsis");
			base.item.shootSpeed = 8f;
		}
	}
}
