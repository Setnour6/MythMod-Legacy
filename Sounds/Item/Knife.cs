using System;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Sounds.Item
{
	public class SwordCrash : ModSound
	{
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

