using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs.Evil
{
	public class Bloodlurker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodlurker");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 22;
			npc.height = 32;
			npc.damage = 0;
			npc.dontCountMe = true;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("BloodItem");
			npc.knockBackResist = .45f;
			npc.npcSlots = 0;
						banner = npc.type;
			bannerItem = mod.ItemType("BloodBanner");
			npc.noGravity = false;
			npc.noTileCollide = false;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 32;
				npc.height = 32;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 30; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 1.2f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodEye"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.spawnTileY < Main.rockLayer && spawnInfo.player.ZoneCrimson && !spawnInfo.playerSafe && !spawnInfo.invasion && !spawnInfo.sky && !Main.eclipse ? 0.0799999f : 0f;
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
			}
		}
		public override void AI()
		{
			{
											Player player = Main.player[npc.target];
					Player target = Main.player[npc.target];
				int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
			
				if (distance < 100)
				{
					player.AddBuff(BuffID.Weak, 120); 

				
				}
				if (distance < 100)
				{
					npc.aiStyle = 41;
								animationType = NPCID.BlueSlime;
								npc.spriteDirection = npc.direction;
					aiType = NPCID.Herpling;
				}
				else if (distance > 220)
				{
					npc.aiStyle = 1;
					aiType = NPCID.BlueSlime;
								animationType = NPCID.BlueSlime;
				}
			}
			
		}
	}
}
