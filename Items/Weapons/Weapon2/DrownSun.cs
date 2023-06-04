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
            // DisplayName.SetDefault("灭日");
            DisplayName.AddTranslation(GameCulture.Chinese, "灭日");
            Tooltip.AddTranslation(GameCulture.Chinese, "释放一道毁灭黑光\n制作尚未完成不要使用可能会闪退");
        }
        public override void SetDefaults()
        {
            Item.damage = 220;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 21;
            Item.rare = 9;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 1.1f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 6;
            Item.value = 800;
            Item.scale = 1f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        private int o = 0;
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (o == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("DrownSun").Type, (int)(Item.damage * player.GetDamage(DamageClass.Melee)), Item.knockBack, Main.myPlayer, 0f, 0f);
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
