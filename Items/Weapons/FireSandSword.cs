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
            Tooltip.SetDefault("红尘沙卷");
        }
        public override void SetDefaults()
        {

            item.damage = 482;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 6;
            item.rare = 9;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 15;
            item.value = 1200000;
            item.scale = 1f;

        }
    }
}
