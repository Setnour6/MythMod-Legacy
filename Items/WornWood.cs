using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class WornWood : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("它长满了海藻");
            base.DisplayName.AddTranslation(GameCulture.English, "朽木");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.createTile = base.mod.TileType("朽木");
            base.item.useStyle = 1;
			base.item.useTurn = true;
            base.item.useAnimation = 15;
			base.item.useTime = 10;
            base.item.autoReuse = true;
			base.item.consumable = true;
            item.width = 24;//宽
            item.height =22;//高
            item.rare = 3;//品质
            item.scale = 1f;//大小
            item.value = 0;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
