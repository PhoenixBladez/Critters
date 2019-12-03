using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Buffs
{
	public class Apparition_Buff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Apparation");
			Description.SetDefault("Become a shade\nIncreases movement speed drastically and makes you immune\nCannot use items or regenerate life");

			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			int dust = Dust.NewDust(player.position, player.width, player.height, 110);
            Main.dust[dust].scale = 1.5f;
			Main.dust[dust].noGravity = true;
			player.immune = true;
			player.lifeRegen = 0;
            player.moveSpeed += 0.32f;
            player.maxRunSpeed += 3f;
		}
	}
}
