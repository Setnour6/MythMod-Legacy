using System;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Sounds.Item
{
	// Token: 0x020008C2 RID: 2242
	public class 雷击 : ModSound
	{
		// Token: 0x0600309A RID: 12442 RVA: 0x000113DC File Offset: 0x0000F5DC
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = base.sound.CreateInstance();
			soundInstance.Volume = volume * 1f;
			soundInstance.Pan = pan;
			Main.PlaySoundInstance(soundInstance);
			return soundInstance;
		}
	}
}

