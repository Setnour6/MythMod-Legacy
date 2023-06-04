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
namespace MythMod.Items.Weapons.StarJellyFIsh
{
    public class BloodyJellyfishStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("血红水螅杖");
			// base.Tooltip.SetDefault("");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血红水螅杖");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "召唤水螅蚕食敌人\n下水增强");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 220;
            base.Item.DamageType = DamageClass.Summon;
            base.Item.mana = 40;
            base.Item.width = 50;
            base.Item.height = 50;
            base.Item.useTime = 10;
            base.Item.useAnimation = 10;
            Item.crit = 14;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.scale = 1f;
            base.Item.knockBack = 2.5f;
            base.Item.value = 80000;
            base.Item.rare = 11;
            base.Item.UseSound = SoundID.Item109;
            base.Item.shoot = base.Mod.Find<ModProjectile>("嗜血水螅杖").Type;
            base.Item.shootSpeed = 8f;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.useTime = 4;
                base.Item.useAnimation = 4;
            }
            else
            {
                base.Item.useTime = 10;
                base.Item.useAnimation = 10;
            }
            return base.CanUseItem(player);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
