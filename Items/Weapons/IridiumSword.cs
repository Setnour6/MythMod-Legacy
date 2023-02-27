using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//制作是mod名字
{
    public class IridiumSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("黑芒破空");//教程 是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 541;//伤害
            item.melee = true;//是否是近战
            item.width = 20;//宽
            item.height = 20;//高
            item.useTime = 24;//使用时挥动间隔时间
            item.rare = 9;//品质
            item.useAnimation = 24;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 12;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 25;//暴击
            item.shoot = mod.ProjectileType("铱金剑剑气");
            item.shootSpeed = 10f;
            item.value = 14000000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小

        }
    }
}
