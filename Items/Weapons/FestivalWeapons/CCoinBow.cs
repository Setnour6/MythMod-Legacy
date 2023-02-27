using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class CCoinBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.SetDefault("钻石币弓");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 46;
            item.height = 82;
            item.useTime = 9;
            item.useAnimation = 9;
            item.damage = 1500;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 5;
            item.value = 240000;
            item.scale = 1f;
            item.rare = 9;
            item.useStyle = 5;
            item.knockBack = 1;
            item.shoot = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 12.5f;
            item.reuseDelay = 14;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v = new Vector2(speedX, speedY);
            int num = Main.rand.Next(5, 10);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            for(int i = 0; i < num; i++)
            {
                v = v.RotatedBy(Main.rand.Next(-2000, 2000) / 4000f) * Main.rand.Next(1000, 1600) / 1500f;
                Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, mod.ProjectileType("DiamondCoin"), (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  