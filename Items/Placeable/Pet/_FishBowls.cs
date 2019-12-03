using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Pet
{
	public class LuvdiscBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ardorfish Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Luvdisc_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"LuvdiscItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
	public class KelpfishBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kelpfish Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Kelpfish_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"KelpfishItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
	public class LanternfishBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lanternfish Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Lanternfish_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"LanternfishItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class GulperBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gulper Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Gulper_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GulperItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class CoralfishBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coralfish Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Coralfish_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CoralfishItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class FloaterBowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminous Floater Bowl");
		}


		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 32;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Floater_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"FloaterItem", 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}