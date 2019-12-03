using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Critters.Items
{
	public class GItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		public override bool CloneNewInstances => true;
		
		public override void SetDefaults(Item item)
		{
			if (item.type == 3290)
			{
				CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/Helfire");
			}
			if (item.type == 2303)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2304)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2305)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2308)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2309)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2310)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2318)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2302)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2299)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2306)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
			if (item.type == 2301)
			{
			 item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;
			}
		}
		public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
						if (item.type == 3290)
			{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/Helfire"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
			}
		}
		public override bool UseItem(Item item, Player player)
        {
			if (item.type == 2299)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("AtlanticCod"));
			 			return true;
			}
			if (item.type == 2302)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("NeonTetra"));
			 			return true;
			}
			if (item.type == 2303)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Cavefish"));
			 			return true;
			}
			if (item.type == 2304)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Damselfish"));
			 			return true;
			}
			if (item.type == 2305)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("CrismonTigerfish"));
			 			return true;
			}
			if (item.type == 2308)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("GoldenCarp"));
			 			return true;
			}
			if (item.type == 2309)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("SpecularFish"));
			 			return true;
			}
			if (item.type == 2310)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Prismite"));
			 			return true;
			}
			if (item.type == 2306)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("FrostMinnow"));
			 			return true;
			}
						if (item.type == 2301)
			{
			 NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("RedSnapper"));
			 			return true;
			}
			else
			{
			return false;
			}
		}
	}
}