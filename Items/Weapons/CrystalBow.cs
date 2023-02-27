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

namespace MythMod.Items.Weapons
{
    public class CrystalBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "水晶石弓");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 42;
            item.height = 76;
            item.useTime = 4;
            item.useAnimation = 4;
            item.damage = 370;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 3000;
            item.scale = 1f;
            item.rare = 11;
            item.useStyle = 5;
            item.knockBack = 14;
            item.shoot = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 30f;
            item.reuseDelay = 4;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        private int p = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            p += 1;
            Vector2 v = new Vector2(speedX, speedY) * 2.5f;
            int num = Main.rand.Next(2, 6);
            Projectile.NewProjectile(position.X, position.Y, speedX * 2f, speedY * 2f, type, (int)((double)damage * 2d), knockBack, player.whoAmI, 0f, 0f);
            if (p > 999999999)
            {
                p = 0;
            }
            if (p % 4 == 0)
            {
                for (int i = 0; i < num; i++)
                {
                    v = v.RotatedBy(Main.rand.Next(-2000, 2000) / 4000f) * Main.rand.Next(1000, 1600) / 2000f;
                    Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, mod.ProjectileType("水晶锥"), (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
                }
            }
            return false;
        }
    }
}
  