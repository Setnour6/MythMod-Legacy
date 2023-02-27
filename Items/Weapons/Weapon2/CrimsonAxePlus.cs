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
            item.damage = 90;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 30;
            item.rare = 4;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.axe = 28;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("BloodAxe");
            item.shootSpeed = 13f;
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
