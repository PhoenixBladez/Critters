using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs.Ocean
{
	public class Glitterfish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coralfish");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 22;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("CoralfishItem");
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .35f;
			npc.aiStyle = 16;
			npc.noGravity = true;
				banner = npc.type;
			bannerItem = mod.ItemType("CoralfishBanner");
			npc.npcSlots = 0;
			aiType = NPCID.Goldfish;
		}
		bool txt = false;
		public override bool PreAI()
		{
		if(!txt)
		{
			for (int i = 0; i < 5; ++i)
			{
             Vector2 dir = Main.player[npc.target].Center - npc.Center;
             dir.Normalize();
             dir *= 1;
             int newNPC = NPC.NewNPC((int)npc.Center.X + (Main.rand.Next(-20, 20)), (int)npc.Center.Y + (Main.rand.Next(-20, 20)), mod.NPCType("Glitterfish1"), npc.whoAmI);
              Main.npc[newNPC].velocity = dir;
			}
			txt = true;
		}
			return true;
		}
		

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 0.34f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Glitter"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Glitter1"), 1f);
			}
		}

		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RawFish"), 1);
			}
		}
	}
}
