using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MusketeerHat : ModItem
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musketeer's Hat");
		}


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;

            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.vanity = true;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrimsonFeather", 2);
			recipe.AddIngredient(ItemID.Silk, 6);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
