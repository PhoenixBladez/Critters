using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Moths
{
    public class LunaMothItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luna Moth");
		}


        public override void SetDefaults()
        {
            item.width = 24;
			item.height = 22;
            item.rare = 2;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
			item.bait = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("LunaMoth"));
            return true;
        }

        }
}
