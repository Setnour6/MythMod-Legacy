using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class MeteS : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("火陨符咒石");
            Tooltip.SetDefault("释放从天而降的火流星\n冷却10s\n无消耗");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.width = 26;//长度
            item.height = 40;//高度
            item.maxStack = 999;//最大叠加
            item.damage = 320;
            item.value = 125000;//价值
            item.rare = 3;//稀有度
            base.item.useStyle = 2;
            item.consumable = false;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            item.noMelee = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.MeteorMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for(int t = 0;t < 10;t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1000 + Main.rand.Next(-200,600), v2.X, v2.Y, mod.ProjectileType("FireBall"), item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    mplayer.MagicCool += 600;
                    player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
                }
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
            recipe.AddIngredient(null, "MeteIII", 1);
            recipe.AddIngredient(null, "MagicStone", 1);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}