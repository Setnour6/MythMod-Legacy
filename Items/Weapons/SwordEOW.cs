using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordEOW : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·世界吞噬怪");
            base.Tooltip.SetDefault("你的实力已经碾压了世界吞噬怪，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.damage = 28;//伤害
            item.melee = true;//是否是近战
            item.width = 50;//宽
            item.height = 50;//高
            item.useTime = 52;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 26;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            item.shoot = 27;
            item.shootSpeed = 9f;
            item.scale = 1f;//大小
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num = Main.rand.Next(0, 100);
			{
                if(num > 80)
                {
                    type = base.mod.ProjectileType("CurseFlame");
                }
                else
                {
                    type = base.mod.ProjectileType("EvilSaliva");
                }
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
    }
}
