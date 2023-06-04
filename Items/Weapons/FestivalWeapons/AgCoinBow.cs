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

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class AgCoinBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("银币弓");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 46;
            Item.height = 82;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.damage = 40;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 5;
            Item.value = 8000;
            Item.scale = 1f;
            Item.rare = 4;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 7.8f;
            Item.reuseDelay = 14;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY);
            int num = Main.rand.Next(3, 7);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            for(int i = 0; i < num; i++)
            {
                v = v.RotatedBy(Main.rand.Next(-2000, 2000) / 4000f) * Main.rand.Next(1000, 1600) / 2000f;
                Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, Mod.Find<ModProjectile>("AgCoin").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  