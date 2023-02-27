using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class CrimsonAxePlus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CrimsonAxePlus");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰寒血锋");
        }
        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 30;
            Item.rare = 4;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.UseSound = SoundID.Item1;
            Item.axe = 28;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("BloodAxe").Type;
            Item.shootSpeed = 13f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
    }
}
