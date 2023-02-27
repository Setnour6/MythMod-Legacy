using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class FlamS : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("火球符咒石");
            Tooltip.SetDefault("释放一个火球\n冷却10s\n无消耗");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.damage = 1420;
            Item.value = 50000;
            Item.rare = 3;
            base.Item.useStyle = 2;
            Item.consumable = false;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
            Item.noMelee = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.FireMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 16f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("FireBall").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
            }
            mplayer.MagicCool += 600;
            player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "FlamIII", 1);
            recipe.AddIngredient(null, "MagicStone", 1);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
    }
}