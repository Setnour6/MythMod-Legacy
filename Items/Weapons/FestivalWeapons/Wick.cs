using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class Wick : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯芯");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 400;
            base.item.crit = 50;
            base.item.width = 98;
			base.item.height = 42;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 99999;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = false;
            base.item.shoot = 14;
			base.item.shootSpeed = 30f;
			base.item.useAmmo = 97;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18.0f, 0.0f);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
