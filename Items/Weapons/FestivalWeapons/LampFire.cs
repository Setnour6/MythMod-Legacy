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
            Item.glowMask = GetGlowMask;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 56;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.damage = 260;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 10000;
            Item.scale = 1f;
            Item.rare = 8;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 10f;
            Item.reuseDelay = 14;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        private int j = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            j += 1;
            if(j % 3 == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, Mod.Find<ModProjectile>("LargeLanternArrow").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  