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
            Item.DamageType = DamageClass.Ranged;
            Item.width = 42;
            Item.height = 76;
            Item.useTime = 4;
            Item.useAnimation = 4;
            Item.damage = 370;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 3000;
            Item.scale = 1f;
            Item.rare = 11;
            Item.useStyle = 5;
            Item.knockBack = 14;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 30f;
            Item.reuseDelay = 4;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        private int p = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
                    Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, Mod.Find<ModProjectile>("水晶锥").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
                }
            }
            return false;
        }
    }
}
  