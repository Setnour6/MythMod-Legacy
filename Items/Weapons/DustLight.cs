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
    public class DustLight : ModItem
    {
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EvilScaleDust", 15);
            recipe.AddIngredient(155, 1);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("击中敌人爆发出蓝色火焰");
            base.DisplayName.SetDefault("尘光");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 29;
            item.melee = true;
            item.width = 52;
            item.height = 62;
            item.useTime = 16;
            item.rare = 3;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 7;
            item.value = 10000;
            item.scale = 1f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 228; i++)
            {
                int num = Dust.NewDust(target.position, target.width, target.height, 41, target.velocity.X * 0f, target.velocity.Y * 0f, 150, default(Color), 1.2f);
                Main.dust[num].noGravity = true;
            }
            if (target.type == 488)
            {
                return;
            }
            float num1 = (float)damage * 0.04f;
            if ((int)num1 == 0)
            {
                return;
            }
            Projectile.NewProjectile(target.Center.X, target.Center.Y, 2f, 2f, base.mod.ProjectileType("烛光"), damage, knockback, player.whoAmI, 0f, 0f);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 41, 0f, 0f, 0,  default(Color), 0.6f);
        }
    }
}
