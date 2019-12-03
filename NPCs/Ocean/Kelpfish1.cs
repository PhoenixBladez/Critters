using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs.Ocean
{
	public class Kelpfish1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kelpfish");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 24;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("KelpfishItem");
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .35f;
			npc.aiStyle = 16;
			npc.noGravity = true;
			npc.npcSlots = 0;
			npc.dontCountMe = true;
			aiType = NPCID.Goldfish;
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Kelp1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Kelp2"), 1f);
			}
		}

		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
		}
	
	}
}
