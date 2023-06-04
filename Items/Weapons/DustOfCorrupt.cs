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
    public class DustOfCorrupt : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("腐化粉尘");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "腐化粉尘");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 42;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 26;
			base.Item.useAnimation = 20;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 12000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("CorruptDust").Type;
			base.Item.shootSpeed = 9f;
		}
	}
}
