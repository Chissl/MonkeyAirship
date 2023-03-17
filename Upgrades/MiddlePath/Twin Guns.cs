

namespace MonkeyAirship.Upgrades.MiddlePath
{
    public class TwinGuns : ModUpgrade<MonkeyAirship>
    {

        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 920;

        public override string Description => "Adds a second machine gun!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
            var machinegun2 = attackairunitmodel.Duplicate();
            machinegun2.targetProvider = new TargetCloseAirUnitModel("targetclose", false, false);
            machinegun2.AddBehavior(new TargetCloseAirUnitModel("targetclose", false, false));
            if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
            {
                machinegun2.weapons[0].projectile.GetDamageModel().damage = +2;
                machinegun2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            }
            if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
            {
                machinegun2.weapons[0].projectile.pierce += 2;
            }
            machinegun2.weapons[0].ejectY = -10;
            attackairunitmodel.weapons[0].ejectY = 10;
            towerModel.AddBehavior(machinegun2);
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display020>();

        }
    }
}