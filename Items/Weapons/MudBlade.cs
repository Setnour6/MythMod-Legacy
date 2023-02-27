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
            item.damage = 10;
            item.melee = true;
            item.width = 54;
            item.height = 76;
            item.useTime = 28;
            item.rare = 1;
            item.useAnimation = 28;
            item.useStyle = 1;
            item.knockBack = 2.2f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 2000;
            item.scale = 1f;

        }
    }
}
