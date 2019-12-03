using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace Critters.Items.Consumable
{
    public class SandOrb : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandy Orb");
			Tooltip.SetDefault("Summons the Desert Winds");
		}


        public override void SetDefaults()
        {
            item.width = 16;
			item.height = 16;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 4;
			item.value = Item.sellPrice(0, 0, 1, 0);
            item.useTime = item.useAnimation = 20;

            item.consumable = true;
            item.autoReuse = true;

        }
		public override bool CanUseItem(Player player)
        {
			if (Sandstorm.Happening)
			{
			return false;
			}
			return true;
		}
		bool sandText = false;
        public override bool UseItem(Player player)
        {
			if (!sandText)
			{
				Main.NewText("The Desert Winds are raging!", 204, 153, 51);
				sandText = true;
			}
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = 21600;
			Sandstorm.Severity  = 1f;
			CrittersWorld.sandStorm = true; 
			return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "SandGustItem", 1);
            recipe1.AddIngredient(null, "GustItem", 1);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(this, 1);
            recipe1.AddRecipe();
        }
	}
}
