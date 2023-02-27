using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class BloodGoldBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodGoldBlade");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "暗金屠杀刃");
        }
        public override void SetDefaults()
        {
            Item.damage = 72;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 46;
            Item.useTime = 14;
            Item.rare = 6;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.UseSound = SoundID.Item1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("BloodGoldShader").Type;
            Item.shootSpeed = 8f;
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
            Vector2 pc = player.position + new Vector2(player.width, player.height) / 2;
            Projectile.NewProjectile(pc.X, pc.Y, 0, 0, Mod.Find<ModProjectile>("BloodGoldShader").Type, 0, 0, player.whoAmI);
            Projectile.NewProjectile(pc.X, pc.Y, 0, 0, Mod.Find<ModProjectile>("BloodGoldShader2").Type, 0, 0, player.whoAmI);
            Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 100f)).RotatedByRandom(MathHelper.TwoPi);
            Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, Mod.Find<ModProjectile>("BloodGold").Type, Item.damage * 2, Item.knockBack, Main.myPlayer, player.direction, 0f);
            return false;
        }
    }
}
