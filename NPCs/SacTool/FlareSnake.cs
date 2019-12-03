/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SacredTools;

namespace Critters.NPCs.SacTool
{
	public class FlareSnake : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Serpent Hatchling");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 44;
			npc.dontCountMe = true;
			npc.height = 30;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath4;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("SnakeItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 7;
			npc.npcSlots = 0;
			aiType = NPCID.Scorpion;
			animationType = NPCID.Scorpion;
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
				if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug1"), 1f);
			}
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
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/Serpent_Glow"));
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			var tools = ModLoader.GetMod("SacredTools");
			if(tools != null)
			{
			SacredTools.ModdedPlayer toolsPlayer = spawnInfo.player.GetModPlayer<SacredTools.ModdedPlayer>(tools);
			
			return toolsPlayer.FlameCrimson ? 1.75f : 0f;
			}
			else
			return 0;
		}
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			var tools = ModLoader.GetMod("SacredTools");
			if(tools != null && Main.rand.Next(2) == 1 && npc.velocity.X != 0)
			{
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModLoader.GetMod("SacredTools").DustType("FlareBurn"));
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
			}
		}
	}
}*/
