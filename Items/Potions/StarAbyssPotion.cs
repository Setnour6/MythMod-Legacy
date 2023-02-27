using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class StarAbyssPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星渊毒剂");
            Tooltip.SetDefault("血色毒素中流动着撕裂神经的能量\n近战携带恐怖的剧毒\n一瓶撒下自来水系统足以毁灭一座城");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 999;
            Item.value = 10000;
            Item.rare = 11;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.useStyle = 2;
            base.Item.UseSound = SoundID.Item3;
            base.Item.consumable = true;
            Item.buffType = Mod.Find<ModBuff>("StarSword").Type;
            Item.buffTime = 72000;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("StarSword").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("StarSword").Type, 72000, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("StarSword").Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("StarAbyssCell").Type, 3);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
    }
}