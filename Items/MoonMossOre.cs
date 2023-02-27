using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//ÖÆ×÷ÊÇmodÃû×Ö
{
    public class MoonMossOre : ModItem//²ÄÁÏÊÇÎïÆ·Ãû³Æ
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("¾§ÕëÌ¦Þº£¿Ì«ÃÀÁË");//½Ì³ÌÊÇÎïÆ·½éÉÜ
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 40;//¿í
            Item.height = 40;//¸ß
            Item.rare = 24;//Æ·ÖÊ
            Item.scale = 1f;//´óÐ¡
            Item.value = 4500;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    Recipe recipe = Recipe.Create(Mod.Find<ModItem>("MoonMossBar").Type, 1);//ÖÆ×÷Ò»¸öÎäÆ÷
                    recipe.AddIngredient(null, "MoonMossOre", 3); //ÐèÒªÒ»¸ö²ÄÁÏ
                    recipe.requiredTile[0] = 412;
                    recipe.Register();
        }
    }
}
