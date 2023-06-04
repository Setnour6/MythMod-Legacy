using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//0‰00‡4¡Á¡Â0‡80‡5mod0‡10‹4¡Á0‰0
{
    public class BoneLiquid : ModItem//0…50‡20†90ˆ30‡80‡50ˆ20Š70‡4¡¤0‡10‹40…60‡4
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");//0†50ˆ00…60ˆ00‡80‡50ˆ20Š70‡4¡¤0†5¨¦0‡70‰5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 48;//0†7¨ª
            Item.height = 18;//0†00‰8
            Item.rare = 3;//0‡4¡¤0‰00‡8
            Item.scale = 1f;//0…7¨®0ˆ40„3
            Item.value = 50;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
