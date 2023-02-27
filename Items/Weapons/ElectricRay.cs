using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;
namespace MythMod.Items.Weapons
{
    public class ElectricRay : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Electrical Fish");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "电鳐");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 140;
			base.item.magic = true;
			base.item.mana = 10;
			base.item.width = 58;
			base.item.height = 54;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 1.5f;
			base.item.value = 10000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("Thunderstaff");
			base.item.shootSpeed = 1f;
		}
	}
}
