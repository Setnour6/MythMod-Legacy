using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class GoldPosition : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GoldPosition");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "金相");
            Tooltip.SetDefault("集普天下之金气,铸此神剑");
            Tooltip.AddTranslation(GameCulture.Chinese, "集普天下之金气,铸此神剑");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 200;
            item.melee = true;
            item.width = 66;
            item.height = 66;
            item.useTime = 60;
            item.rare = 11;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("GoldPosition");
            item.shootSpeed = 8f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 64, 0f, 0f, 0, default(Color), 1.8f);
            if(Main.rand.Next(15) == 1)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(hitbox.Center.X, hitbox.Center.Y, v.X, v.Y, mod.ProjectileType("GoldPosiDust"), 480, 0.5f, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(92, 143);
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage * 2d), knockBack * 10, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 3);
            recipe.AddIngredient(20, 3);
            recipe.AddIngredient(21, 3);
            recipe.AddIngredient(22, 3);
            recipe.AddIngredient(703, 3);
            recipe.AddIngredient(704, 3);
            recipe.AddIngredient(705, 3);
            recipe.AddIngredient(706, 3);
            recipe.AddIngredient(3467, 3);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 412;
            recipe.AddRecipe();
        }
    }
}
