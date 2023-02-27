using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Weapon2
{
    public class ExtremePointMigration : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("函数与导数");
            DisplayName.AddTranslation(GameCulture.Chinese, "函数与导数");
            Tooltip.AddTranslation(GameCulture.Chinese, "导数之终极Boss,变幻莫测,无可定夺");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 220;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 21;
            item.rare = 9;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
            item.value = 800;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("ExtremePointMigration");
            item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
        }
    }
}
