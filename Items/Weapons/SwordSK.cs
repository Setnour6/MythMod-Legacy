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
            // base.DisplayName.SetDefault("荣耀之剑·骷髅王");
            // base.Tooltip.SetDefault("你的实力已经碾压了骷髅王，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 19;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 50;//宽
            Item.height = 50;//高
            Item.useTime = 60;//使用时挥动间隔时间
            Item.rare = 2;//品质
            Item.useAnimation = 20;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = true;//能否持续挥动
            Item.crit = 9;//暴击
            Item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
            Item.shoot = 270;
            Item.shootSpeed = 6f;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2(player.position.X + X, player.position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                if (Main.rand.Next(25) == 0)
                {
                    Projectile.NewProjectile((float)player.position.X + X, (float)player.position.Y - 1000f + Y, v2.X, v2.Y, Mod.Find<ModProjectile>("HugeCurseSkull").Type, (int)damage * 10, 10, player.whoAmI, 0f, 0f);
                }
        }
    }
}
