using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Critters.Items.Consumable
{
    public class CrismiteItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crismite");
			Tooltip.SetDefault("'Its crystals pulse with luminous energy'");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/CrismiteItem");
		}


        public override void SetDefaults()
        {
            item.width = 40;
			item.height = 20;
            item.rare = 4;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.value = Item.sellPrice(0, 0, 20, 0);
            item.useTime = item.useAnimation = 20;
			item.bait = 35;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/CrismiteItem"),
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
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Crismite"));
            return true;
        }

        }
}
