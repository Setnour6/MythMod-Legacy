using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class WornWood : ModItem//²ÄÁÏÊÇÎïÆ·Ãû³Æ
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ëü³¤ÂúÁËº£Ôå");
            base.DisplayName.AddTranslation(GameCulture.English, "ÐàÄ¾");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.createTile = base.Mod.Find<ModTile>("ÐàÄ¾").Type;
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            base.Item.useAnimation = 15;
			base.Item.useTime = 10;
            base.Item.autoReuse = true;
			base.Item.consumable = true;
            Item.width = 24;//¿í
            Item.height =22;//¸ß
            Item.rare = 3;//Æ·ÖÊ
            Item.scale = 1f;//´óÐ¡
            Item.value = 0;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
