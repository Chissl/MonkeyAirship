using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using MonkeyAirship.Displays;
using Assets.Scripts.Models.Towers.Behaviors;

namespace MonkeyAirship.Upgrades.MiddlePath
{
    public class FasterFiring : ModUpgrade<MonkeyAirship>
    {

        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 680;

        public override string Description => "Machine Gun Fires Faster";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetBehavior<AttackAirUnitModel>().weapons[0].rate *= .66f;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display010>();
        }
    }
}