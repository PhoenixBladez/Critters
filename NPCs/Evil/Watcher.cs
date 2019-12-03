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
	public class Watcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightstealer");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 22;
			npc.height = 32;
			npc.damage = 0;
			npc.dontCountMe = true;
						banner = npc.type;
			bannerItem = mod.ItemType("WatcherBanner");
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("WatcherItem");
			npc.knockBackResist = .45f;
			npc.npcSlots = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
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
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 14, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WatcherEye"), 1f);
			
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
	public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}

		public override void AI()
		{
			{
							Player player = Main.player[npc.target];
											Player target = Main.player[npc.target];
				int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
			
				if (distance < 220)
				{
					player.AddBuff(BuffID.Darkness, 120); 

				
				}
				if (distance < 220)
				{
					Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .46f, .316f, .85f);
			
					npc.aiStyle = 5;
					aiType = NPCID.Moth;
				}
				else if (distance > 220)
				{
					npc.velocity.X *= .65f;
					npc.velocity.Y *= .65f;
				}
			}
			
		}
	}
}
