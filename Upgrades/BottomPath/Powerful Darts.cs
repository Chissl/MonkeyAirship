

namespace MonkeyAirship.Upgrades.BottomPath
{
    public class PowerfulDarts : ModUpgrade<MonkeyAirship>
    {

        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 550;

        public override string Description => "Darts gain more popping power!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetBehavior<AttackAirUnitModel>().weapons[0].projectile.pierce += 2;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display001>();
        }
    }
}