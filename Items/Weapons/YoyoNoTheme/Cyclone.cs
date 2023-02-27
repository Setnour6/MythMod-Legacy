using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class Cyclone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "热带气旋");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("Cyclone");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.noMelee = true;
            item.knockBack = 2.5f;
            item.damage = 368;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 14;
        }
    }
}
