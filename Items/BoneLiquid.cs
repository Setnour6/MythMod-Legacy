using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//�0�10��0�0�10�6�04�0�3�0�9�0�3�0�0�0�10�6�08�0�10�6�05mod�0�10�6�01�0�10�6�84�0�3�0�9�0�10��0
{
    public class BoneLiquid : ModItem//�0�10��5�0�10�6�02�0�10�6�99�0�10�0�33�0�10�6�08�0�10�6�05�0�10�0�32�0�10�0�77�0�10�6�04�0�3��0�10�6�01�0�10�6�84�0�10��6�0�10�6�04
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");//�0�10�6�95�0�10�0�30�0�10��6�0�10�0�30�0�10�6�08�0�10�6�05�0�10�0�32�0�10�0�77�0�10�6�04�0�3��0�10�6�95���0�7�0�10�6�07�0�10��5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 48;//�0�10�6�97���0�9
            Item.height = 18;//�0�10�6�90�0�10��8
            Item.rare = 3;//�0�10�6�04�0�3��0�10��0�0�10�6�08
            Item.scale = 1f;//�0�10��7���0�3�0�10�0�34�0�10�6�73
            Item.value = 50;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
