using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using MythMod.NPCs.EvilBotle;
using Terraria.ModLoader;
using System.IO;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.EvilBotle
{
    public class EvilBotleFake : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("魔化力场");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔化力场");
        }
        private bool X = true;
        private int num10;
        private int ADDnum = 0;
        private float num13;
        private bool T = false;
        public override void SetDefaults()
        {
            npc.behindTiles = true;
            base.npc.damage = 0;
            base.npc.width = 120;
            base.npc.height = 160;
            base.npc.defense = 0;
            base.npc.lifeMax = 2000;
            base.npc.knockBackResist = 0f;
            base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
            base.npc.aiStyle = -1;
            this.aiType = -1;
            base.npc.lavaImmune = true;
            base.npc.noGravity = false;
            base.npc.noTileCollide = false;
            base.npc.HitSound = SoundID.NPCHit1;
            base.npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void AI()
        {
            npc.dontTakeDamage = false;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            EvilBotle.Addlig = 2;
            if (base.npc.life <= 0)
            {
            }
        }
    }
}
