using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SulphurStoneSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("硫石之刃");
        }
        private int num = 0;
        private bool k = true;
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 206;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 64;//宽
            Item.height = 80;//高
            Item.useTime = 20;//使用时挥动间隔时间
            Item.rare = 11;//品质
            Item.useAnimation = 20;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f ;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = true;//能否持续挥动
            Item.crit = 9;//暴击
            Item.value = 90000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
            Item.shoot = Mod.Find<ModProjectile>("SulfurBeam").Type;
            Item.shootSpeed = 16f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Basalt", 20);
            modRecipe.AddIngredient(null, "Sulfur", 64);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
