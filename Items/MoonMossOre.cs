using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//������mod����
{
    public class MoonMossOre : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("����̦޺��̫����");//�̳�����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.width = 40;//��
            item.height = 40;//��
            item.rare = 24;//Ʒ��
            item.scale = 1f;//��С
            item.value = 4500;
            item.maxStack = 999;
            item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(null, "MoonMossOre", 3); //��Ҫһ������
                    recipe.requiredTile[0] = 412;
                    recipe.SetResult(mod.ItemType("MoonMossBar"), 1); //����һ������
                    recipe.AddRecipe();
        }
    }
}
