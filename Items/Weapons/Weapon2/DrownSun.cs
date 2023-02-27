using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Weapon2
{
    public class DrownSun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灭日");
            DisplayName.AddTranslation(GameCulture.Chinese, "灭日");
            Tooltip.AddTranslation(GameCulture.Chinese, "释放一道毁灭黑光\n制作尚未完成不要使用可能会闪退");
        }
        public override void SetDefaults()
        {
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
            item.noMelee = true;
            item.noUseGraphic = true;
        }
        private int o = 0;
        public override bool UseItem(Player player)
        {
            if (o == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("DrownSun"), (int)(item.damage * player.meleeDamage), item.knockBack, Main.myPlayer, 0f, 0f);
                o += 1;
            }
            if (!Main.mouseLeft)
            {
                o = 0;
            }
            return base.UseItem(player);
        }
    }
}
