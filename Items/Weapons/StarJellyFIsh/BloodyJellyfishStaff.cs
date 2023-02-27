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
			base.DisplayName.SetDefault("血红水螅杖");
			base.Tooltip.SetDefault("");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血红水螅杖");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "召唤水螅蚕食敌人\n下水增强");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 220;
            base.item.summon = true;
            base.item.mana = 40;
            base.item.width = 50;
            base.item.height = 50;
            base.item.useTime = 10;
            base.item.useAnimation = 10;
            item.crit = 14;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.scale = 1f;
            base.item.knockBack = 2.5f;
            base.item.value = 80000;
            base.item.rare = 11;
            base.item.UseSound = SoundID.Item109;
            base.item.shoot = base.mod.ProjectileType("嗜血水螅杖");
            base.item.shootSpeed = 8f;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.useTime = 4;
                base.item.useAnimation = 4;
            }
            else
            {
                base.item.useTime = 10;
                base.item.useAnimation = 10;
            }
            return base.CanUseItem(player);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
