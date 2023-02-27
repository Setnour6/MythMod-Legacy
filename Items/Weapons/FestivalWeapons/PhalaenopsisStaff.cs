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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "蝴蝶兰魔杖");
		}
        public override void SetDefaults()
		{
			base.Item.damage = 400;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 16;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 26;
			base.Item.useAnimation = 20;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 12000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("Phalaenopsis").Type;
			base.Item.shootSpeed = 8f;
		}
	}
}
