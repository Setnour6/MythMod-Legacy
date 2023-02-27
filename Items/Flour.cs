using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//ÖÆ×÷ÊÇmodÃû×Ö
{
    public class Flour : ModItem//²ÄÁÏÊÇÎïÆ·Ãû³Æ
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//½Ì³ÌÊÇÎïÆ·½éÉÜ
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            Item.width = 56;//¿í
            Item.height = 38;//¸ß
            Item.rare = 2;//Æ·ÖÊ
            Item.scale = 1f;//´óÐ¡
            Item.value = 100;
            Item.maxStack = 999;
        }
    }
}
