using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class MudBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("松松垮垮的泥土剑");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 76;
            Item.useTime = 28;
            Item.rare = 1;
            Item.useAnimation = 28;
            Item.useStyle = 1;
            Item.knockBack = 2.2f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 2000;
            Item.scale = 1f;

        }
    }
}
