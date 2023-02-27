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

namespace MythMod.Items.Weapons
{
    public class Elimination : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Elimination");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "代码杀射线");
            base.Tooltip.SetDefault("∞ 代码伤害\n开发者专用\n反反作弊武器");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.magic = true;
			base.item.mana = 10;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 50f;
			base.item.value = 1000000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("Elimination");
			base.item.shootSpeed = 50f;
		}
    }
}
