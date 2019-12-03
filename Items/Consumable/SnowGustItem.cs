using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class SnowGustItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Gust");
			Tooltip.SetDefault("'Cold and chilly'");
		}


        public override void SetDefaults()
        {
            item.width = 36;
			item.height = 24;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 3, 0);
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("SnowGust"));
            return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "SnowGustItem", 5);
			recipe1.AddIngredient(ItemID.Bottle, 1);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(ItemID.BlizzardinaBottle, 1);
            recipe1.AddRecipe();
        }
	}
}
