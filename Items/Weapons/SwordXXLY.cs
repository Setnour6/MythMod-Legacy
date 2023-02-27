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
    public class SwordXXLY : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·鲜血獠牙");
            base.Tooltip.SetDefault("你的实力已经碾压了鲜血獠牙，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 32;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 48;//宽
            Item.height = 48;//高
            Item.useTime = 20;//使用时挥动间隔时间
            Item.rare = 2;//品质
            Item.useAnimation = 20;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = true;//能否持续挥动
            Item.crit = 9;//暴击
            Item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int type = 0;
            if(Main.rand.Next(10) == 5)
            {
                switch (Main.rand.Next(0, 5))
                {
                    case 1:
                        type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff1").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff2").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff3").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModProjectile>("CrimsonTuskStaff4").Type;
                        break;
                }
                Projectile.NewProjectile(player.Center.X + Main.rand.Next(Main.rand.Next(-350, 0), Main.rand.Next(0, 350)), player.Center.Y - 100f, 0, 2.5f, type, 15, 1, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
