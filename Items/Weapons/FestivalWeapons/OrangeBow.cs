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
            item.ranged = true;
            item.width = 36;
            item.height = 96;
            item.useTime = 9;
            item.useAnimation = 9;
            item.damage = 260;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 30000;
            item.scale = 1f;
            item.rare = 11;
            item.useStyle = 5;
            item.knockBack = 1;
            item.shoot = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 7f;
            item.reuseDelay = 9;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
  