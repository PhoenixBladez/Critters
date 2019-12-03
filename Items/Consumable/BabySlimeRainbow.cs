using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Consumable
{
    public class BabySlimeRainbow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Rainbow Slime");
			Tooltip.SetDefault("'A lil' baby slime'");
		    Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}


        public override void SetDefaults()
        {
            item.width = 20;
			item.height = 12;
            item.rare = 1;
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("BabySlimeRainbow"));
            return true;
        }

        }
}
