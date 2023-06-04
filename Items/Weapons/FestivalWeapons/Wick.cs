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
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯芯");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 400;
            base.Item.crit = 50;
            base.Item.width = 98;
			base.Item.height = 42;
			base.Item.useTime = 30;
			base.Item.useAnimation = 30;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 99999;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = false;
            base.Item.shoot = 14;
			base.Item.shootSpeed = 30f;
			base.Item.useAmmo = 97;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18.0f, 0.0f);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
