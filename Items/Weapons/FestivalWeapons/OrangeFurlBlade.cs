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
	public class OrangeFurlBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("金桔旋刃");
        }

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.shootSpeed = 17f;
			item.shoot = mod.ProjectileType("TangerineKnife");
			item.width = 68;
			item.height = 68;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
            item.damage = 358;
            item.autoReuse = true;
            item.melee = true;
            item.value = 100000;
            item.rare = 11;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("TangerineKnife");
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    }
}
