using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//制作是mod名字
{
    public class Killer : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("诡弑");
            Tooltip.SetDefault("");//教程 是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 65;//伤害
            item.melee = true;//是否是近战
            item.width = 40;//宽
            item.height = 48;//高
            item.useTime = 22;//使用时挥动间隔时间
            item.rare = 4;//品质
            item.useAnimation = 22;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 2;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 4;//暴击
            item.value = 30000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int m = 0; m < 200; m++)
            {
                if ((Main.npc[m].Center - player.Center).Length() <= 500 && Main.npc[m].friendly == false && Main.npc[m].dontTakeDamage == false && Main.rand.Next(0,(int)((Main.npc[m].Center - player.Center).Length() / 2f + 1)) == 1 && Main.npc[m].active)
                {
                    int num = Projectile.NewProjectile(Main.npc[m].Center.X, Main.npc[m].Center.Y, 0, 0, 125, 75, 2, player.whoAmI, 0f, 0f);
                    Main.projectile[num].timeLeft = 4;
                }
            }
        }
    }
}
