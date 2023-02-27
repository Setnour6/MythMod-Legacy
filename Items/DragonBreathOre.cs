using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
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
namespace MythMod.Items//制作是mod名字
{
    public class DragonBreathOre : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("封印的远古脉搏，依稀可以感受到，大地呼吸的节奏");//教程是物品介绍
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 40;//宽
            base.item.height = 40;//高
            base.item.rare = 8;//品质
            base.item.scale = 1f;//大小
            base.item.createTile = base.mod.TileType("龙息矿");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.width = 16;
            base.item.height = 14;
            base.item.maxStack = 999;
            base.item.value = 10000;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DragonBreathOre", 4); //需要一个材料
            recipe.requiredTile[0] = 412;
            recipe.SetResult(mod.ItemType("DragonBreathBar"), 1); //制作一个武器
            recipe.AddRecipe();
        }
    }
}
