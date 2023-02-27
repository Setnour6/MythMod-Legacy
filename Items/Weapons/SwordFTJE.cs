using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordFTJE : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·腐檀巨蛾");
            base.Tooltip.SetDefault("你的实力已经碾压了腐檀巨蛾，这把属于你的剑里面封印了它的灵魂");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 30;//伤害
            item.melee = true;//是否是近战
            item.width = 48;//宽
            item.height = 48;//高
            item.useTime = 20;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 20;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 10000;//价值，1表示一铜币，这里是100铂金币
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int type = 0;
            if (Main.rand.Next(10) == 5)
            {
                type = base.mod.ProjectileType("MagicLightBullet2");
                Projectile.NewProjectile(player.Center.X + Main.rand.Next(Main.rand.Next(-350, 0), Main.rand.Next(0, 350)), player.Center.Y - 1000f, Main.rand.Next(-200,200) / 100f, 2.5f, type, 15, 1, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
