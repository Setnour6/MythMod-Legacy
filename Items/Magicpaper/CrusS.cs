using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class CrusS : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("咒火球符咒石");
            Tooltip.SetDefault("释放一发超级咒火球\n冷却10s\n无消耗");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 6900;
            item.value = 300000;
            item.rare = 5;
            base.item.useStyle = 1;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = false;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CurseMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                v2 = v2.RotatedBy(Main.rand.NextFloat(-0.007f, 0.007f)) * Main.rand.NextFloat(0.9f, 1.1f);
                int j = Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X, v2.Y, mod.ProjectileType("SuperCurseBall"), item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                Main.projectile[j].extraUpdates = 3;
                mplayer.MagicCool += 600;
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
            recipe.AddIngredient(null, "CrusIII", 1);
            recipe.AddIngredient(null, "MagicStone", 1);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}