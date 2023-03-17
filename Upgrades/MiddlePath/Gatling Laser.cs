

namespace MonkeyAirship.Upgrades.MiddlePath
{
    public class GatlingLaser : ModUpgrade<MonkeyAirship>
    {

        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 3850;

        public override string Description => "Adds a another machine gun that fires lasers!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
            attackairunitmodel.range = 120;
            foreach (var attackairunitmodels in towerModel.GetBehaviors<AttackAirUnitModel>())
            {
                attackairunitmodels.weapons[0].projectile.pierce += 2;
            }
                var laser = attackairunitmodel.Duplicate();
            laser.weapons[0].projectile.ApplyDisplay<GreenLaserDisplay>();
            laser.targetProvider = new TargetStrongAirUnitModel("targetstrong", false, false);
            laser.AddBehavior(new TargetStrongAirUnitModel("targetstrong", false, false));
            var laserweapon = laser.weapons[0];
            laserweapon.rate = .9f;

            if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
            {
                laserweapon.rate *= .66f;
            }
            laserweapon.ejectY = 0;
            var laserprojectile = laser.weapons[0].projectile;
            laserprojectile.AddBehavior(new DamageModifierForTagModel("ceramicdamage", "Ceramic", 1, 2, false, true));
            laserprojectile.AddBehavior(new DamageModifierForTagModel("moabdamage", "Moabs", 1, 5, false, true));
            laserprojectile.pierce = 2;
            laserprojectile.scale = 1.3f;
            laserprojectile.GetBehavior<TravelStraitModel>().speed = 800;
            towerModel.AddBehavior(laser);
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display030>();
        }
    }
}