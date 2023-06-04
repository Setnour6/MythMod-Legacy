using Microsoft.Xna.Framework;

using Terraria.ModLoader;

using MythMod;

using Terraria;

using Terraria.Localization;


namespace MythMod.Backgrounds
{
    public class HookBackGround
    {
        static int aValue = 127;
        public static void Load()
        {
            /*On.Terraria.Main.DrawBG += Main_DrawBG;*/
            Terraria.On_Main.DrawBG += Main_DrawBG;
        }
        private static void Main_DrawBG(Terraria.On_Main.orig_DrawBG orig, Terraria.Main self)
        {
            orig.Invoke(self);
            Mod mod = ModLoader.GetMod("MythMod");
            if (Terraria.Main.LocalPlayer.active)
            {
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneOcean)
                {
                    /*Terraria.Main.spriteBatch.Draw(mod.GetTexture("Backgrounds/CoralFar"), new Rectangle(0, 0, Terraria.Main.screenWidth, Terraria.Main.screenHeight), new Color(255, 255, 255, aValue));
                    Terraria.Main.spriteBatch.Draw(mod.GetTexture("Backgrounds/CoralClose"), new Rectangle(0, 0, Terraria.Main.screenWidth, Terraria.Main.screenHeight), new Color(255, 255, 255, aValue));*/
                }
            }
        }
        public static void UnLoad()
        {
            Terraria.On_Main.DrawBG -= Main_DrawBG;
        }
    }
}
