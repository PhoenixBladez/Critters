using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class SeaweedRoll : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seaweed Roll");
			Tooltip.SetDefault("Briefly allows the player to breathe underwater\nProvides the 'Well Fed' buff");
		}


        public override void SetDefaults()
        {
            item.width = 30;
			item.height = 30;
            item.rare = 2;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.useStyle = 1;
            item.useTime = item.useAnimation = 30;
			
			item.buffType = BuffID.WellFed;
			item.buffTime = 45000;
            item.noMelee = true;
            item.consumable = true;
			item.UseSound = SoundID.Item2;
            item.autoReuse = false;

        }
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Gills, 1800);
			return true;
		}
		public override void AddRecipes()
		{			
			ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "RawFish", 2);
			recipe2.AddIngredient(null, "Kelp", 3);
            recipe2.AddTile(TileID.CookingPots);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
		}
    }
}
