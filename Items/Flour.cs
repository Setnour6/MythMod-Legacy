using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//�0�0�0�4���0�8�0�5mod�0�1�0�4���0�0
{
    public class Flour : ModItem//�0�5�0�2�0�9�0�3�0�8�0�5�0�2�0�7�0�4���0�1�0�4�0�6�0�4
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�0�5�0�0�0�6�0�0�0�8�0�5�0�2�0�7�0�4���0�5���0�7�0�5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            Item.width = 56;//�0�7��
            Item.height = 38;//�0�0�0�8
            Item.rare = 2;//�0�4���0�0�0�8
            Item.scale = 1f;//�0�7���0�4�0�3
            Item.value = 100;
            Item.maxStack = 999;
        }
    }
}
