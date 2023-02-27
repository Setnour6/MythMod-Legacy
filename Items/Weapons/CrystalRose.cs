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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "璀璨晶莲");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 600;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 64;
			base.Item.height = 64;
			base.Item.useTime = 15;
			base.Item.useAnimation = 15;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 120000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("CrystalMagic").Type;
			base.Item.shootSpeed = 19f;
		}
	}
}
