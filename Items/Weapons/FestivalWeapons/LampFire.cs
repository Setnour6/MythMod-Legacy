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
    public class LampFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            Tooltip.AddTranslation(GameCulture.Chinese, "每攻击3次就放出大灯火之箭");
            DisplayName.AddTranslation(GameCulture.Chinese, "灯火通明");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.ranged = true;
            item.width = 32;
            item.height = 56;
            item.useTime = 7;
            item.useAnimation = 7;
            item.damage = 260;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 10000;
            item.scale = 1f;
            item.rare = 8;
            item.useStyle = 5;
            item.knockBack = 1;
            item.shoot = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 10f;
            item.reuseDelay = 14;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        private int j = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            j += 1;
            if(j % 3 == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, mod.ProjectileType("LargeLanternArrow"), (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  