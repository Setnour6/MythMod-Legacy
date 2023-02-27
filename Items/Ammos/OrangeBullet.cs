using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Ammos
{
    public class OrangeBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("桔子弹");
            base.Tooltip.SetDefault("由年桔制成,果汁会溅射");
		}
		public override void SetDefaults()
		{
			base.item.ranged = true;
			base.item.width = 12;
            base.item.damage = 42;
			base.item.height = 12;
			base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.knockBack = 1.5f;
			base.item.value = 30;
			base.item.rare = 2;
            base.item.shoot = mod.ProjectileType("TangerineBullet");
            base.item.shootSpeed = 0;
            base.item.ammo = AmmoID.Bullet;
		}
	}
}
