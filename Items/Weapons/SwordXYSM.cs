using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
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

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordXYSM : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("荣耀之剑·星渊水母");
            // base.Tooltip.SetDefault("你的实力已经碾压了星渊水母，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 100;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 54;//宽
            Item.height = 54;//高
            Item.useTime = 40;//使用时挥动间隔时间
            Item.rare = 2;//品质
            Item.useAnimation = 20;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f ;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = true;//能否持续挥动
            Item.crit = 9;//暴击
            Item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
            Item.shoot = base.Mod.Find<ModProjectile>("SwordXYSM").Type;
            Item.shootSpeed = 11f;
        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(27f, 27f);
			spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/荣耀之剑XYSMGlow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
    }
}
