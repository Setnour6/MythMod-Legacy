using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.WorldBuilding;
namespace MythMod.Items//制作是mod名字
{
    public class DragonBreathOre : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("封印的远古脉搏，依稀可以感受到，大地呼吸的节奏");//教程是物品介绍
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 40;//宽
            base.Item.height = 40;//高
            base.Item.rare = 8;//品质
            base.Item.scale = 1f;//大小
            base.Item.createTile = base.Mod.Find<ModTile>("龙息矿").Type;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.width = 16;
            base.Item.height = 14;
            base.Item.maxStack = 999;
            base.Item.value = 10000;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("DragonBreathBar").Type, 1);//制作一个武器
            recipe.AddIngredient(null, "DragonBreathOre", 4); //需要一个材料
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}
