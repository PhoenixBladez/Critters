using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Critters.Items.Consumable
{
    public class LanternfishItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lanternfish");
			Tooltip.SetDefault("'It glows a deep, deep, blue'");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/LanternfishItem");
		}


        public override void SetDefaults()
        {
            item.width = 30;
			item.height = 26;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 5, 0);
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

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
				ModContent.GetTexture("Critters/Glowmask/LanternfishItem"),
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
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Lanternfish"));
            return true;
        }

        }
}
