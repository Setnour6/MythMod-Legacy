using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;

namespace MythMod.NPCs
{
    public class AIs : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public static int num71;
        public static int num72;
        public static Vector2 vector19;
        public static bool Eoc = true;
        public static bool Eoc2 = true;
        public static bool Eoc3 = true;
        public override void AI(NPC npc)
        {
            if (npc.type == 4 && MythWorld.Myth)
            {
                Player player = Main.player[npc.target];
                if (npc.life < 4000 && Eoc == true)
                {
                    npc.damage = 65;
                    Eoc = false;
                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("EOCPhantom"), 0, 0f, 0f, 0f, 0f, 255);
                }
                if (npc.life < 2000 && Eoc2 == true)
                {
                    Eoc2 = false;
                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("EOCPhantom"), 0, 0f, 0f, 0f, 0f, 255);
                }
                if (npc.life < 500 && Eoc3 == true)
                {
                    Eoc3 = false;
                    Vector2 vector = npc.Center + new Vector2(200f, (float)npc.height / 2f);
                    Vector2 vector3 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    Vector2 vector2 = npc.Center + new Vector2(-200f, (float)npc.height / 2f);
                    vector19 = new Vector2(0, 50);
                    num71 = NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("EOCPhantom"), 0, 0f, 0f, 0f, 0f, 255);
                    num72 = NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("EOCPhantom"), 0, 0f, 0f, 0f, 0f, 255);
                    if (MythWorld.MythIndex >= 3)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Vector2 v = new Vector2(0, 800).RotatedByRandom(Math.PI * 2);
                            NPC.NewNPC((int)vector3.X + (int)v.X, (int)vector3.Y + (int)v.Y, mod.NPCType("EOCPhantom"), 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                }
                if (NPC.CountNPCS(mod.NPCType("EOCPhantom")) > 0)
                {
                    npc.dontTakeDamage = true;
                }
                else
                {
                    npc.dontTakeDamage = false;
                }
                if (MythWorld.MythIndex >= 2 && npc.life < npc.lifeMax * 0.3f)
                {
                    if (npc.velocity.Length() > 3f && (int)Main.time % 25 == 0)
                    {
                        Vector2 C = player.Center;
                        Vector2 V = player.velocity.RotatedBy(Main.rand.NextFloat((float)Math.PI * 0.5f, (float)Math.PI * 1.5f)) / player.velocity.Length() * 350f;
                        num71 = NPC.NewNPC((int)(V + C).X, (int)(V + C).Y, mod.NPCType("EOCShadow"), 0, 0f, 0f, 0f, 0f, 255);
                    }
                }
            }
        }
    }
}