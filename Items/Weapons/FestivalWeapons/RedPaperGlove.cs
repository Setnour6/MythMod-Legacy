using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class RedPaperGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 17;
            item.melee = true;
            item.width = 30;
            item.height = 36;
            item.useTime = 9;
            item.rare = 6;
            item.useAnimation = 9;
            item.useStyle = 1;
            item.knockBack = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 8;
            item.value = 99999;
            item.scale = 1f;
        }
    }
}
