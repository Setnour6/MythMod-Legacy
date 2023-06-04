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
    public class PineappleStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("菠萝喜糖法杖");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "菠萝喜糖法杖");
		}
        public override void SetDefaults()
		{
			base.Item.damage = 240;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 14;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 15;
			base.Item.useAnimation = 15;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 10000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("PineappleStaff").Type;
			base.Item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float shootSpeed = base.Item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 3, (float)position.Y + speedY * 3, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0, 0f);
            return false;
        }
    }
}
