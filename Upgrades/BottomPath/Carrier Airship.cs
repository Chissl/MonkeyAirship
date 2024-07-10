



namespace MonkeyAirship.Upgrades.BottomPath
{
    public class CarrierAirship : ModUpgrade<MonkeyAirship>
    {

        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 11500;

        public override string Description => "Now with new and improved fighters!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 4)
            {
                var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
                var firefromairunitmodel = attackairunitmodel.GetDescendant<FireFromAirUnitModel>();
                var carrier = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-400").GetAttackModel(1).weapons[0].Duplicate();
                var plane = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-500").GetDescendant<CreateTowerModel>().tower.Duplicate();
                var strafe = plane.GetAttackModel(0).weapons[0];
                var strafeprojectile = strafe.projectile;
                var missile = plane.GetAttackModel(2).weapons[0];
                var missileprojectile = plane.GetAttackModel(2).weapons[0];

                plane.GetBehavior<TowerExpireOnParentUpgradedModel>().parentTowerUpgradeTier = 4;
                plane.GetAttackModel(1).weapons[0].rate = 9999999;
                plane.GetAttackModel(1).weapons[0].startInCooldown = true;


                strafe.rate = .3f;
                strafe.projectile.GetBehavior<DamageModel>().damage = 1;
                strafeprojectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                strafeprojectile.pierce = 8;

                missile.rate = 3f;

                plane.baseId = "BuccaneerGreaterPlane";
                carrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "BuccaneerGreaterPlane";
                carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 3;

                if (towerModel.appliedUpgrades.Contains(UpgradeID<MobileReconnaissance>()))
                {
                    plane.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                    var firefromlightplane = plane.GetDescendant<FireFromAirUnitModel>();
                    var decamo = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 3).GetWeapons()[1].Duplicate();
                    decamo.behaviors = new Il2CppReferenceArray<WeaponBehaviorModel>(new WeaponBehaviorModel[] { firefromlightplane });
                    decamo.rate = .3f;
                    decamo.projectile.display = new Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference() { guidRef = "" };
                    decamo.projectile.radius = 20;
                    plane.GetAttackModel(0).AddWeapon(decamo);
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    strafe.rate *= .66f;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<TwinGuns>()))
                {
                    carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 4;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<ImprovedEngines>()))
                {
                    plane.GetDescendant<FighterMovementModel>().maxSpeed *= 1.2f;
                    plane.GetDescendant<FighterMovementModel>().loopTimeBeforeNext *= .75f;
                }
                carrier.projectile.GetBehavior<CreateTowerModel>().tower = plane;
                carrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;
                carrier.projectile.AddBehavior(firefromairunitmodel);
                foreach (var attackairunitmodel2 in towerModel.GetBehaviors<AttackAirUnitModel>())
                {
                    attackairunitmodel2.weapons[0].projectile.display = CreatePrefabReference<TracerDisplay>();
                }
                attackairunitmodel.AddWeapon(carrier);
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display004>();

            }
        }
    }
}