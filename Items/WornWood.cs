using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class WornWood : ModItem//0…50‡20†90ˆ30‡80‡50ˆ20Š70‡4¡¤0‡10‹40…60‡4
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("0‡9¨¹0…6¡è0‡0¨²0†90‡90†20„50ˆ80Š2");
            base.DisplayName.AddTranslation(GameCulture.English, "0ˆ4¨¤0‡20†6");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.createTile = base.Mod.Find<ModTile>("0ˆ4¨¤0‡20†6").Type;
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            base.Item.useAnimation = 15;
			base.Item.useTime = 10;
            base.Item.autoReuse = true;
			base.Item.consumable = true;
            Item.width = 24;//0†7¨ª
            Item.height =22;//0†00‰8
            Item.rare = 3;//0‡4¡¤0‰00‡8
            Item.scale = 1f;//0…7¨®0ˆ40„3
            Item.value = 0;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
