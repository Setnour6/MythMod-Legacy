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
    public class FreezeFlameDeath : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰火寂灭");
            Tooltip.SetDefault("力量足以震动地壳");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 400;
            item.melee = true;
            item.width = 52;
            item.height = 62;
            item.useTime = 18;
            item.rare = 11;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 22;
            item.value = 1000000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("MoonPlus");
            item.shootSpeed = 12f;
        }
        private int a = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (a % 3 == 0)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DeathKnife"), (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            if (a % 3 == 1)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("MoonPlus"), (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            if (a % 3 == 2)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FreezeKnife"), (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            a += 1;
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1327, 1);
            modRecipe.AddIngredient(1306, 1);
            modRecipe.AddIngredient(null, "CrimsonMoon", 1);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
