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
            // Tooltip.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "齿刃");
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "BoneLiquid", 8);
            recipe.AddIngredient(null, "BrokenTooth", 12);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override void SetDefaults()
        {

            Item.damage = 42;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 48;
            Item.useTime = 22;
            Item.rare = 3;
            Item.useAnimation = 22;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.crit = 4;
            Item.value = 3000;
            Item.scale = 1f;
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
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(k && m && Main.rand.Next(5) == 0)
            {
                int y = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("ToothBlade").Type, damage, knockback, player.whoAmI, 0f, 0f);
                Main.projectile[y].spriteDirection = player.direction;
                Main.projectile[y].rotation = Main.rand.NextFloat((float)MathHelper.Pi * -0.4f, (float)MathHelper.Pi * 0.5f);
                k = false;
                m = false;
            }
        }
    }
}
