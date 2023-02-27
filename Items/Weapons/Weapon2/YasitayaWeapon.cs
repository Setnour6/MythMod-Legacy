using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Weapon2
{
    public class YasitayaWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("赤血金鳞");
            DisplayName.AddTranslation(GameCulture.Chinese, "赤血金鳞");
            Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public override void SetDefaults()
        {
            item.damage = 230;
            item.melee = true;
            item.width = 110;
            item.height = 122;
            item.useTime = 21;
            item.rare = 8;
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
            item.shoot = mod.ProjectileType("GoldBlood");
            item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
        }
    }
}
