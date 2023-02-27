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

            item.damage = 206;//伤害
            item.melee = true;//是否是近战
            item.width = 64;//宽
            item.height = 80;//高
            item.useTime = 20;//使用时挥动间隔时间
            item.rare = 11;//品质
            item.useAnimation = 20;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 90000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
            item.shoot = mod.ProjectileType("SulfurBeam");
            item.shootSpeed = 16f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 20);
            modRecipe.AddIngredient(null, "Sulfur", 64);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
