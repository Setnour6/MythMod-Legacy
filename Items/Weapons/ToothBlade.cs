using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;

namespace MythMod.Items.Weapons
{
    public class ToothBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "齿刃");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 8);
            recipe.AddIngredient(null, "BrokenTooth", 12);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {

            item.damage = 42;
            item.melee = true;
            item.width = 40;
            item.height = 48;
            item.useTime = 22;
            item.rare = 3;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 4;
            item.value = 3000;
            item.scale = 1f;
        }
        private bool k = false;
        private bool m = true;
        private int l = 0;
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 5, 0f, 0f, 0, default(Color), 0.4f);
            if(hitbox.Width == 80 && !k)
            {
                k = true;
            }
            if (hitbox.Width == 56)
            {
                l += 1;
            }
            else
            {
                l = 0;
            }
            if(l == 6)
            {
                m = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(k && m && Main.rand.Next(5) == 0)
            {
                int y = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, base.mod.ProjectileType("ToothBlade"), damage, knockback, player.whoAmI, 0f, 0f);
                Main.projectile[y].spriteDirection = player.direction;
                Main.projectile[y].rotation = Main.rand.NextFloat((float)MathHelper.Pi * -0.4f, (float)MathHelper.Pi * 0.5f);
                k = false;
                m = false;
            }
        }
    }
}
