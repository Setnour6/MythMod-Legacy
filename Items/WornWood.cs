using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class WornWood : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("�������˺���");
            base.DisplayName.AddTranslation(GameCulture.English, "��ľ");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.createTile = base.mod.TileType("��ľ");
            base.item.useStyle = 1;
			base.item.useTurn = true;
            base.item.useAnimation = 15;
			base.item.useTime = 10;
            base.item.autoReuse = true;
			base.item.consumable = true;
            item.width = 24;//��
            item.height =22;//��
            item.rare = 3;//Ʒ��
            item.scale = 1f;//��С
            item.value = 0;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
