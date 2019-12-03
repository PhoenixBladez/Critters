using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SpiritMod;
using SpiritMod.Items;
using SpiritMod.Items.Material;

namespace Critters.NPCs.Fish
{
	public class SpiritKoi : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Koi");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 26;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			var spirit = ModLoader.GetMod("SpiritMod");
			if(spirit != null)
			{
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)ModLoader.GetMod("SpiritMod").ItemType("SpiritKoi");
			}
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .35f;
			npc.dontCountMe = true;
			npc.aiStyle = 16;
			npc.noGravity = true;
			npc.npcSlots = 0;
			aiType = NPCID.Goldfish;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/SpiritKoi_Glow"));
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
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 30;
				npc.height = 30;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 187, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true;
					{
						Main.dust[num622].scale = 0.23f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		public override void AI()
		{
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .05f, .1f, .2f);
			npc.spriteDirection = -npc.direction;
		}
		public override void NPCLoot()
		{
			int Bark = Main.rand.Next(10) + 6;
			for (int J = 0; J <= Bark; J++)
			if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RawFish"), 1);
			}
		}
	public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			var spirit = ModLoader.GetMod("SpiritMod");
			if(spirit != null)
			{
			SpiritMod.MyPlayer spiritPlayer = spawnInfo.player.GetModPlayer<SpiritMod.MyPlayer>();
			
			return spiritPlayer.ZoneSpirit && spawnInfo.water ? 1.3f : 0f;
			}
			else
			return 0;
		}
	
	}
}
