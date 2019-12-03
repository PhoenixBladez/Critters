using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Critters.NPCs;

namespace Critters.Buffs
{
	public class Alchemical_Buff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Alchemical Toxin");
			Description.SetDefault("Attacks inflict a venomous toxin on foes\nCauses the player to slowly lose life sporadically, especially when injured");

			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.Alchemical = true;
			if (player.lifeRegen > 0)
				player.lifeRegen = 0;
			player.lifeRegen -= 4;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GNPC>().alchemical = true;
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 5);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
