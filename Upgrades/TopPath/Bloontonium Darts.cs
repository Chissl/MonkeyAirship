

namespace MonkeyAirship.Upgrades.TopPath
{
    public class BloontoniumDarts : ModUpgrade<MonkeyAirship>
    {

        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 950;

        public override string Description => "Bloontonium-tipped darts increases damage against all bloon types";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectile = towerModel.GetBehavior<AttackAirUnitModel>().weapons[0].projectile;
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.GetDamageModel().damage += 2;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display002>();
        }
    }
}