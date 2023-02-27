using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class FlamI : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("一阶火球符咒");
            Tooltip.SetDefault("释放一个火球\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 420;
            item.value = 1000;
            item.rare = 0;
            base.item.useStyle = 1;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
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
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X, v2.Y, mod.ProjectileType("FireBall"), item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                mplayer.MagicCool += 600;
                item.stack--;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EmpMagic", 1);
            recipe.AddIngredient(8, 6);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}