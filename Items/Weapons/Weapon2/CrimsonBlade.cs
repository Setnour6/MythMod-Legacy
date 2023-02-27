using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class CrimsonBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CrimsonBlade");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "绯红之刃");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 72;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 66;
            Item.height = 66;
            Item.useTime = 15;
            Item.rare = 11;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.UseSound = SoundID.Item1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("RedCrack").Type;
            Item.shootSpeed = 8f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if(Main.rand.Next(5) == 1)
            {
                float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                Vector2 v = player.Center - new Vector2(hitbox.Center.X, hitbox.Center.Y);
                int num40 = Projectile.NewProjectile(hitbox.Center.X + v.X * 0.5f, hitbox.Center.Y + v.X * 0.5f, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("Lighting2").Type, Item.damage / 2, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 200;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(0,Main.rand.NextFloat(300,1500)).RotatedByRandom(MathHelper.TwoPi);
            Vector2 v2 = new Vector2(-v.X / 7500f, -v.Y / 7500f).RotatedBy(Main.rand.NextFloat(-0.15f,0.15f));
            Vector2 v3 = new Vector2(0, Main.rand.NextFloat(125, 150)).RotatedByRandom(MathHelper.TwoPi);
            Vector2 v4 = new Vector2(-v3.X / 250000f, -v3.Y / 250000f).RotatedBy(Main.rand.NextFloat(-0.15f, 0.15f));
            Projectile.NewProjectile(Main.screenPosition.X + Main.mouseX + v.X, Main.screenPosition.Y + Main.mouseY + v.Y, v2.X, v2.Y, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(391, 20);
            recipe.AddIngredient(3829, 1);
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
