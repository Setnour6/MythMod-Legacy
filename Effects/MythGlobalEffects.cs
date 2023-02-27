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
namespace MythMod.Effects
{
    public class MythGlobalEffects : ScreenShaderData
    {
        public MythGlobalEffects(string passName) : base(passName)
        {
        }
        public MythGlobalEffects(Ref<Effect> shader, string passName) : base(shader, passName)
        {
        }
        public override void Apply()
        {
            base.Apply();
        }

    }
}
