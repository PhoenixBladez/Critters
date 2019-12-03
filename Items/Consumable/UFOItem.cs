using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class UFOItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost UFO");
			Tooltip.SetDefault("'The poor thing looks confused'");
		}


        public override void SetDefaults()
        {
            item.width = 36;
			item.height = 24;
            item.rare = 8;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 40, 0);
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("UFO"));
            return true;
        }

        }
}
