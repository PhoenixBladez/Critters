using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs
{
	public class Crismite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crismite");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 24;
			npc.damage = 0;
			npc.dontCountMe = true;
			npc.defense = 9999;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath16;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("CrismiteItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 7;
			npc.npcSlots = 0;
			npc.noGravity = false;
			aiType = NPCID.Mouse;
			animationType = NPCID.Mouse;
			banner = npc.type;
			bannerItem = mod.ItemType("CrismiteBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crismite"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Crismite1"), 1f);
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
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/Crismite_Glow"));
        }
		private int Counter;
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
				Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .15f, .3f, .6f);
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(6) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrismiteCrystal"), 1);
			}
		}
	}
}
