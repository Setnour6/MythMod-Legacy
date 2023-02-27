using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordTwins : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·双子魔眼");
            base.Tooltip.SetDefault("你的实力已经碾压了双子魔眼，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 42;//伤害
            item.melee = true;//是否是近战
            item.width = 48;//宽
            item.height = 48;//高
            item.useTime = 40;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 20;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
            item.shoot = mod.ProjectileType("TwinsBeam1");
            item.shootSpeed = 12f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/荣耀之剑TwinsGlow"), base.item.Center - Main.screenPosition, null, new Color(255,255,255,0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    type = base.mod.ProjectileType("TwinsBeam1");
                    break;
                case 2:
                    type = base.mod.ProjectileType("TwinsBeam2");
                    break;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    }
}
