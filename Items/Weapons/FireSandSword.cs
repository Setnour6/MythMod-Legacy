using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class FireSandSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("红尘沙卷");
        }
        public override void SetDefaults()
        {

            Item.damage = 482;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 6;
            Item.rare = 9;
            Item.useAnimation = 12;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 15;
            Item.value = 1200000;
            Item.scale = 1f;

        }
    }
}
