using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Weapon2
{
    public class GreatBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("新手太刀");
            DisplayName.AddTranslation(GameCulture.Chinese, "新手太刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 21;
            Item.rare = 3;
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
            Item.shoot = Mod.Find<ModProjectile>("GreatBlade").Type;
            Item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
        }
    }
}
