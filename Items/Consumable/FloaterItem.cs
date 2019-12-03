using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Critters.Items.Consumable
{
    public class FloaterItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminous Floater");
			Tooltip.SetDefault("'A beacon at the beach'");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/FloaterItem");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 20;
            item.rare = 2;
            item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 3, 0);
            item.noUseGraphic = true;
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
				ModContent.GetTexture("Critters/Glowmask/FloaterItem"),
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
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Floater1"));
            return true;
        }

        }
}
