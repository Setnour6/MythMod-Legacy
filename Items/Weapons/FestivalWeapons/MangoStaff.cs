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
    public class MangoStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("芒果喜糖法杖");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "芒果喜糖法杖");
		}
        public override void SetDefaults()
		{
			base.item.damage = 240;
			base.item.magic = true;
			base.item.mana = 14;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 10000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("MangoStaff");
			base.item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = base.item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 3, (float)position.Y + speedY * 3, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0, 0f);
            return false;
        }
    }
}
