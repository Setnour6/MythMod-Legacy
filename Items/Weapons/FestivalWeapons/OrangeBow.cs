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
    public class OrangeBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.SetDefault("年桔木弓");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 36;
            Item.height = 96;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.damage = 260;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 30000;
            Item.scale = 1f;
            Item.rare = 11;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 7f;
            Item.reuseDelay = 9;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY);
            int num = Main.rand.Next(4, 8);
            for(int i = 0;i < num;i++)
            {
                Vector2 v0 = new Vector2(0,Main.rand.NextFloat(0f, 40f)).RotatedByRandom(Math.PI * 2d);
                v = v.RotatedBy(Main.rand.NextFloat(-0.3f, 0.3f));
                Projectile.NewProjectile(position.X + v0.X, position.Y + v0.Y, v.X, v.Y, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return true;
        }
    }
}
  