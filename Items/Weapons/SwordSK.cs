using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordSK : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·骷髅王");
            base.Tooltip.SetDefault("你的实力已经碾压了骷髅王，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 19;//伤害
            item.melee = true;//是否是近战
            item.width = 50;//宽
            item.height = 50;//高
            item.useTime = 60;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 20;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
            item.shoot = 270;
            item.shootSpeed = 6f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2(player.position.X + X, player.position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                if (Main.rand.Next(25) == 0)
                {
                    Projectile.NewProjectile((float)player.position.X + X, (float)player.position.Y - 1000f + Y, v2.X, v2.Y, mod.ProjectileType("HugeCurseSkull"), (int)damage * 10, 10, player.whoAmI, 0f, 0f);
                }
        }
    }
}
