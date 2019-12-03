using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Pet
{
	public class GreyMothJar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grey Moth Jar");
		}


		public override void SetDefaults()
		{
            item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 0, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("GreyMoth_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GreyMothItem", 1);
			recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
	public class LunaMothJar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luna Moth Jar");
		}


		public override void SetDefaults()
		{
            item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 0, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("LunaMoth_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"LunaMothItem", 1);
			recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class JewelMothJar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jewel Moth Jar");
		}


		public override void SetDefaults()
		{
            item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 0, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("JewelMoth_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"JewelMothItem", 1);
			recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class GoldMothJar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Moth Jar");
		}


		public override void SetDefaults()
		{
            item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(0, 10, 0, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("GoldMoth_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GoldMothItem", 1);
			recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}