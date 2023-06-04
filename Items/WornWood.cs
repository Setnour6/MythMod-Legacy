using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class WornWood : ModItem//�0�10��5�0�10�6�02�0�10�6�99�0�10�0�33�0�10�6�08�0�10�6�05�0�10�0�32�0�10�0�77�0�10�6�04�0�3��0�10�6�01�0�10�6�84�0�10��6�0�10�6�04
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("�0�10�6�09���0�1�0�10��6�0�3���0�10�6�00���0�5�0�10�6�99�0�10�6�09�0�10�6�92�0�10�6�75�0�10�0�38�0�10�0�72");
            base.DisplayName.AddTranslation(GameCulture.English, "�0�10�0�34����0�10�6�02�0�10�6�96");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.createTile = base.Mod.Find<ModTile>("�0�10�0�34����0�10�6�02�0�10�6�96").Type;
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            base.Item.useAnimation = 15;
			base.Item.useTime = 10;
            base.Item.autoReuse = true;
			base.Item.consumable = true;
            Item.width = 24;//�0�10�6�97���0�9
            Item.height =22;//�0�10�6�90�0�10��8
            Item.rare = 3;//�0�10�6�04�0�3��0�10��0�0�10�6�08
            Item.scale = 1f;//�0�10��7���0�3�0�10�0�34�0�10�6�73
            Item.value = 0;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
