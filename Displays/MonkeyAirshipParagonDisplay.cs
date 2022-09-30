using System.Collections.Generic;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace MonkeyAirship.Displays
{
    public class MonkeyAirshipParagonDisplay : ModTowerDisplay<MonkeyAirship>
    {
        /// <summary>
        /// All classes that derive from ModContent MUST have a zero argument constructor to work
        /// </summary>
        public MonkeyAirshipParagonDisplay()
        {
        }

        public MonkeyAirshipParagonDisplay(int i)
        {
            ParagonDisplayIndex = i;
        }

        public override float Scale => .75f + ParagonDisplayIndex * .025f;

        public override string BaseDisplay => "f0c7075edbd50f748a8c903c4065b9fc";

        public override int ParagonDisplayIndex { get; }

        public override string Name => nameof(MonkeyAirshipParagonDisplay) + ParagonDisplayIndex;

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);


        /// <summary>
        /// Create a display for each possible ParagonDisplayIndex
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new MonkeyAirshipParagonDisplay(i);
            }
        }

        /// <summary>
        /// Could use the ParagonDisplayIndex property to use different effects based on the paragon strength
        /// <see cref="ModTowerDisplay.ParagonDisplayIndex" />
        /// </summary>
        /// <param name="node"></param>
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
#if DEBUG
            node.PrintInfo();
            node.SaveMeshTexture();
#endif

            SetMeshTexture(node, nameof(BaseTowerModel));
            SetMeshOutlineColor(node, new Color(48f / 255f, 0, 121 / 255f));
        }
    }
}