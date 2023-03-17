namespace MonkeyAirship.Upgrades.BottomPath
{
    public class Ravager : ModUpgrade<MonkeyAirship>
    {

        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 42000;

        public override string Description => "Powerful fighters deal massive damage and can stun Moab-class bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 5)
            {
                var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
                var firefromairunitmodel = attackairunitmodel.GetDescendant<FireFromAirUnitModel>();
                var carrier = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-400").GetAttackModel(1).weapons[0].Duplicate();
                var plane = Game.instance.model.GetTowerFromId("BuccaneerGreaterPlane").Duplicate();
                var strafe = plane.GetAttackModel(0).weapons[0];
                var strafeprojectile = strafe.projectile;
                var missile = plane.GetAttackModel(2).weapons[0];
                var missileprojectile = missile.projectile;

                plane.GetBehavior<AirUnitModel>().display = CreatePrefabReference<MoabRavagerPlaneBaseDisplay>();
                plane.GetBehavior<TowerExpireOnParentUpgradedModel>().parentTowerUpgradeTier = 5;
                plane.GetAttackModel(1).RemoveWeapon(plane.GetAttackModel(1).weapons[0]);

                strafe.rate = .15f;
                strafe.projectile.GetBehavior<DamageModel>().damage = 8;
                strafe.projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 6, false, true));
                strafe.projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortifieds", 1, 6, false, true));
                strafeprojectile.pierce += 15;
                strafeprojectile.display = CreatePrefabReference<ApacheLaserPulse>();
                missile.rate = 2f;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    missile.rate *= .8f;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
                {
                    strafe.projectile.GetDamageModel().damage += 4;
                    strafeprojectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                }

                plane.baseId = "Plane";
                carrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "Plane";
                carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 4;

                if (towerModel.appliedUpgrades.Contains(UpgradeID<MobileReconnaissance>()))
                {
                    plane.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                    var firefromlightplane = plane.GetDescendant<FireFromAirUnitModel>();
                    /*var decamo = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 3).GetAttackModel(1).Duplicate();
                    decamo.weapons[0].AddBehavior(new FireFromAirUnitModel(""));
                    decamo.weapons[0].rate = .3f;
                    decamo.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "" };
                    decamo.weapons[0].projectile.radius = 35;
                    plane.GetAttackModel(0).AddBehavior(decamo);*/
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    strafe.rate *= .66f;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<TwinGuns>()))
                {
                    carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 5;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<ImprovedEngines>()))
                {
                    plane.GetDescendant<FighterMovementModel>().maxSpeed *= 1.2f;
                    plane.GetDescendant<FighterMovementModel>().loopTimeBeforeNext *= .75f;
                }
                carrier.projectile.GetBehavior<CreateTowerModel>().tower = plane;
                carrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;
                carrier.projectile.AddBehavior(firefromairunitmodel);

                var moabplane = plane.Duplicate();
                var moabmissile = moabplane.GetAttackModel(2).weapons[0];
                var moabmissileprojectile = moabmissile.projectile;
                var moabstrafe = moabplane.GetAttackModel(0);
                var moabstrafeprojectile = moabstrafe.weapons[0].projectile;
                var stun = Game.instance.model.GetTowerFromId("BombShooter-500").GetDescendant<SlowModel>().Duplicate();
                stun.dontRefreshDuration = true;
                stun.lifespan = .8f;

                moabplane.baseId = "MoabPlane";
                moabplane.GetDescendant<FighterMovementModel>().maxSpeed -= 10;
                moabplane.GetDescendant<FighterMovementModel>().loopChancePerSecondPassed *= 1.1f;
                
                moabstrafe.targetProvider = new TargetStrongAirUnitModel("targetstrong", false, true);
                moabstrafe.AddBehavior(new FighterPilotPatternStrongModel("targetstrong", false, 25, true));
                moabstrafe.weapons[0].rate = 2;
                moabstrafeprojectile.AddBehavior(new DamageModifierForTagModel("Moabs", "Moabs", 1, 15, false, true));

                moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(stun);
                moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.collisionPasses = new[] { -1, 0 };
                moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 30;
                moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 3;


                moabplane.GetBehavior<AirUnitModel>().display = CreatePrefabReference<MoabPlaneDisplay>();
                var moabcarrier = carrier.Duplicate();
                moabcarrier.projectile.GetBehavior<CreateTowerModel>().tower = moabplane;
                moabcarrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;
                moabcarrier.projectile.AddBehavior(firefromairunitmodel);
                moabcarrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "MoabPlane";
                moabcarrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 4;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<TwinGuns>()))
                {
                    moabcarrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 5;
                }


                attackairunitmodel.range += 40;
                foreach (var attackairunitmodel2 in towerModel.GetBehaviors<AttackAirUnitModel>())
                {
                    attackairunitmodel2.weapons[0].rate *= .2f;
                    attackairunitmodel2.weapons[0].projectile.GetDamageModel().damage += 9;
                    attackairunitmodel2.weapons[0].projectile.pierce += 12;
                    attackairunitmodel2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("moab", "Moabs", 1, 5, false, true));
                    attackairunitmodel2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 5, false, true));
                    attackairunitmodel2.weapons[0].projectile.display = CreatePrefabReference<RedTracerDisplay>();
                    attackairunitmodel2.weapons[0].projectile.scale *= .75f;
                }

                attackairunitmodel.AddWeapon(carrier);
                attackairunitmodel.AddWeapon(moabcarrier);
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display005>();
                
            }
        }
    }
}