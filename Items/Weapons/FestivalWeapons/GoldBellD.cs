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

namespace MythMod.Items.Weapons.FestivalWeapons//教程是你的mod文件夹的名字
{
    public class GoldBellD : ModItem//教程是你的文件的名字
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;//这是一个yoyo球
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;//这两个不用做变动
            base.DisplayName.SetDefault("金钟罩");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "释放一个免疫所有攻击的绝对安全区域,冷却时间60s");
        }

        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.useStyle = 4;//使用方式
            item.width = 42;//长
            item.height = 48;//高

            item.useAnimation = 14;//使用动画 调的越小发射频率越快
            item.useTime = 14;//使用时间 
            item.value = Item.sellPrice(0, 9, 99, 99);//价值
            item.rare = 6;//品质
        }
        public override bool UseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player pl = Main.player[Main.myPlayer];
            if(mplayer.Cooling == 0)
            {
                NPC.NewNPC((int)pl.Center.X, (int)pl.Center.Y, mod.NPCType("GoldBellShield"), 0, 0, 0, 0, 0, 255);
                mplayer.Cooling = 3600;
            }
            return mplayer.Cooling == 0;
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor,Color itemColor, Vector2 origin, float scale)
        {
            int cooldown = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>().Cooling;
            if (cooldown > 0)
            {
                Texture2D texture = Main.cdTexture;
                Vector2 slotSize = new Vector2(52f, 52f);
                position -= slotSize * Main.inventoryScale / 2f - frame.Size() * scale / 2f;
                Vector2 drawPos = position + slotSize * Main.inventoryScale / 2f/* - texture.Size() * Main.inventoryScale / 2f*/;
                float alpha = 0.1f + 0.9f * (cooldown / 3600f);
                Vector2 textureOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
                spriteBatch.Draw(texture, drawPos, null, drawColor * alpha, 0f, textureOrigin, Main.inventoryScale, SpriteEffects.None, 0f);
            }
        }
    }
}
