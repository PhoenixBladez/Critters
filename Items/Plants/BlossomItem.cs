using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;


namespace Critters.Items.Plants
{
    public class BlossomItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zenblossom");
			Tooltip.SetDefault("Provides nearby players with the'Calm' buff, reducing enemy spawns");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/BlossomItem");
		}


        public override void SetDefaults()
        {
            item.width = 16;
			item.height = 24;
            item.rare = 2;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.useTime = 30;
            item.useAnimation = 30;
            item.autoReuse = false;
            item.consumable = true;
			item.createTile = mod.TileType("Blossom");
        }
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/BlossomItem"),
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
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BlossmoonItem", 1);
			recipe.AddIngredient(ItemID.Daybloom, 1);
            recipe.AddIngredient(ItemID.CalmingPotion, 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
    }
}
