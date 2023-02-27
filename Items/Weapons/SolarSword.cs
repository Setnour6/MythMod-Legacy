using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class SolarSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.SetDefault("铸日荣耀");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 120;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 32;
            item.rare = 10;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 8;
            item.value = 60000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("SolarSword");
            item.shootSpeed = 9f;

        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(189, 900, false);
            Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 0, default(Color), 1.5f);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 64, 0f, 0f, 0, default(Color), 1f);
            int num = Main.rand.Next(5);
            if (num == 0)
            {
                num = 6;
            }
            else if (num == 1)
            {
                num = 6;
            }
            else if (num == 2)
            {
                num = 6;
            }
            else if (num == 3)
            {
                num = 6;
            }
            else
            {
                num = 6;
            }
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1.5f);
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(3458, 18);
            modRecipe.AddIngredient(3467, 6);
            modRecipe.requiredTile[0] = 125;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
