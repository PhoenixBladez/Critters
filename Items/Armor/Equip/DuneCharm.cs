using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Equip
{
    [AutoloadEquip(EquipType.Neck)]
    public class DuneCharm : ModItem
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Charm");
			Tooltip.SetDefault("1 Defense\nProvides immunity to the 'Mighty Wind' Debuff");
		}


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 18;
			item.defense = 3;
            item.accessory = true;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 2;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			 player.buffImmune[BuffID.WindPushed] = true;
		}
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CleftShell", 1);
			recipe.AddIngredient(ItemID.Chain, 6);
			recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
