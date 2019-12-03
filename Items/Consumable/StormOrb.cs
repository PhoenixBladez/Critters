using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class StormOrb : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormy Orb");
			Tooltip.SetDefault("'Let's have a rainy day'");
		}


        public override void SetDefaults()
        {
            item.width = 16;
			item.height = 16;
            item.rare = 1;
            item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 3, 0);
            item.noUseGraphic = true;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.consumable = true;
            item.autoReuse = true;

        }
		public override bool CanUseItem(Player player)
        {
			return !Main.raining;
			
		}
		bool rainText = false;
        public override bool UseItem(Player player)
        {
			if (!rainText)
			{
				Main.NewText("It's raining!", 85, 172, 247);
				rainText = true;
			}
			Main.rainTime = 86400;
			Main.maxRaining = 0.1f;
			Main.raining = true;
			Main.raining = true;
			CrittersWorld.Rain = true; 
			return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "SnowGustItem", 1);
            recipe1.AddIngredient(null, "StormGustItem", 1);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(this, 1);
            recipe1.AddRecipe();
        }
	}
}
