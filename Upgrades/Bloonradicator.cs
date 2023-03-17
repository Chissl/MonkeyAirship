

namespace MonkeyAirship.Upgrades
{
    public class Bloonradicator : ModParagonUpgrade<MonkeyAirship>
    {
        public override int Cost => 875000;
        public override string Description => "That's no bloon...";
        public override string DisplayName => "Bloonradicator";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var firstairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
            var firstairweapon = firstairunitmodel.weapons[0];
            var firstprojectile = firstairweapon.projectile;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<ParagonDisplay>();
            firstairunitmodel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            firstairunitmodel.range = 999999;
            var airunitmodel = towerModel.GetBehavior<AirUnitModel>();
            airunitmodel.behaviors[0].Cast<PathMovementModel>().speed += 6;
            airunitmodel.behaviors[0].Cast<PathMovementModel>().rotation += 30;

            firstairweapon.rate = .3f;
            firstprojectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            firstprojectile.display = CreatePrefabReference<BlueLaserDisplay>();
            firstprojectile.GetDamageModel().damage = 12;
            firstprojectile.pierce = 50;
            firstprojectile.AddBehavior(new DamageModifierForTagModel("boss", "Boss", 1, 20, false, true));
            firstairunitmodel.weapons[0].ejectX = -15;

            var strongairunitmodel = firstairunitmodel.Duplicate();
            strongairunitmodel.targetProvider = new TargetStrongAirUnitModel("targetstrong", false, false);
            strongairunitmodel.AddBehavior(new TargetStrongAirUnitModel("targetstrong", false, false));
            var closeairunitmodel = firstairunitmodel.Duplicate();
            closeairunitmodel.targetProvider = new TargetCloseAirUnitModel("targetclose", false, false);
            closeairunitmodel.AddBehavior(new TargetCloseAirUnitModel("targetclose", false, false));
            var lastairunitmodel = firstairunitmodel.Duplicate();
            lastairunitmodel.targetProvider = new TargetLastAirUnitModel("targetlast", false, false);
            lastairunitmodel.AddBehavior(new TargetLastAirUnitModel("targetlast", false, false));
            var planelauncher = firstairunitmodel.Duplicate();
            planelauncher.fireWithoutTarget = true;
            planelauncher.RemoveWeapon(planelauncher.weapons[0]);

            var balloflight = Game.instance.model.GetTowerFromId("BallOfLightTower").Duplicate();

            balloflight.GetDescendant<LineProjectileEmissionModel>().dontUseTowerPosition = true;

            balloflight.GetAttackModel().weapons[0].AddBehavior(new FireFromAirUnitModel("fire"));
            var balloflightweapon = balloflight.GetAttackModel().weapons[0];
            balloflight.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Il2CppAssets.Scripts.Utils.PrefabReference() { guidRef = "d48587764ad63c84ea37e82f58bd05ad" };
            balloflightweapon.projectile.GetDamageModel().damage = 24;
            balloflightweapon.projectile.AddBehavior(new DamageModifierForTagModel("boss", "Boss", 1, 20, false, true));
            balloflightweapon.projectile.CapPierce(999999);
            balloflightweapon.projectile.maxPierce = 999999;
            balloflightweapon.projectile.GetDamageModel().maxDamage = 999999;
            balloflightweapon.projectile.GetDamageModel().CapDamage(999999);

            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.weapons[1].ejectX = -15;
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.AddWeapon(balloflightweapon.Duplicate());

            firstairunitmodel.weapons[0].ejectY = 5;
            firstairunitmodel.weapons[1].ejectY = 5;
            firstairunitmodel.weapons[2].ejectY = -5;
            firstairunitmodel.weapons[3].ejectY = -5;
            firstairunitmodel.weapons[4].ejectY = 17;
            firstairunitmodel.weapons[5].ejectY = 17;
            firstairunitmodel.weapons[6].ejectY = -17;
            firstairunitmodel.weapons[7].ejectY = -17;
            firstairunitmodel.weapons[8].ejectY = 29;
            firstairunitmodel.weapons[8].ejectX = 0;
            firstairunitmodel.weapons[9].ejectX = -10;
            firstairunitmodel.weapons[9].ejectY = -25;

            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.weapons[1].ejectX = -15;
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[1].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[1].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[1].Duplicate());
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.AddWeapon(balloflightweapon.Duplicate());
            strongairunitmodel.AddWeapon(balloflightweapon.Duplicate());

            strongairunitmodel.weapons[0].ejectY = 8;
            strongairunitmodel.weapons[1].ejectY = 8;
            strongairunitmodel.weapons[2].ejectY = -8;
            strongairunitmodel.weapons[3].ejectY = -8;
            strongairunitmodel.weapons[4].ejectY = 20;
            strongairunitmodel.weapons[5].ejectY = 20;
            strongairunitmodel.weapons[6].ejectY = -20;
            strongairunitmodel.weapons[7].ejectY = -20;
            strongairunitmodel.weapons[8].ejectY = 30;
            strongairunitmodel.weapons[8].ejectX = 0;
            strongairunitmodel.weapons[9].ejectX = 10;
            strongairunitmodel.weapons[9].ejectY = -25;
            strongairunitmodel.weapons[10].ejectY = 0;
            strongairunitmodel.weapons[10].ejectX = 0;
            strongairunitmodel.weapons[10].projectile.GetDamageModel().damage = 120;
            strongairunitmodel.weapons[10].projectile.AddBehavior(new DamageModifierForTagModel("boss", "Boss", 1, 100, false, true));
            strongairunitmodel.weapons[10].GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Il2CppAssets.Scripts.Utils.PrefabReference() { guidRef = "b9f3014db2da83f48b34e662e9a79910" };
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[10]);
            strongairunitmodel.weapons[11].GetDescendant<LineProjectileEmissionModel>().useTargetAsEndPoint = false;

            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.weapons[1].ejectX = -15;
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[1].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[1].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[1].Duplicate());
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.AddWeapon(balloflightweapon.Duplicate());

            closeairunitmodel.weapons[0].ejectY = 11;
            closeairunitmodel.weapons[1].ejectY = 11;
            closeairunitmodel.weapons[2].ejectY = -11;
            closeairunitmodel.weapons[3].ejectY = -11;
            closeairunitmodel.weapons[4].ejectY = 23;
            closeairunitmodel.weapons[5].ejectY = 23;
            closeairunitmodel.weapons[6].ejectY = -23;
            closeairunitmodel.weapons[7].ejectY = -23;
            closeairunitmodel.weapons[8].ejectY = -31;
            closeairunitmodel.weapons[4].ejectX = 10;
            closeairunitmodel.weapons[5].ejectX = -10;
            closeairunitmodel.weapons[6].ejectX = 10;
            closeairunitmodel.weapons[7].ejectX = -10;
            closeairunitmodel.weapons[8].ejectX = 0;
            closeairunitmodel.weapons[9].ejectX = -10;
            closeairunitmodel.weapons[9].ejectY = 25;


            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.weapons[1].ejectX = -15;
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[1].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[1].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[1].Duplicate());
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.AddWeapon(balloflightweapon.Duplicate());

            lastairunitmodel.weapons[0].ejectY = 14;
            lastairunitmodel.weapons[1].ejectY = 14;
            lastairunitmodel.weapons[2].ejectY = -14;
            lastairunitmodel.weapons[3].ejectY = -14;
            lastairunitmodel.weapons[4].ejectY =  26;
            lastairunitmodel.weapons[5].ejectY =  26;
            lastairunitmodel.weapons[6].ejectY = -26;
            lastairunitmodel.weapons[7].ejectY = -26;
            lastairunitmodel.weapons[8].ejectY = 32;
            lastairunitmodel.weapons[4].ejectX = 10;
            lastairunitmodel.weapons[5].ejectX = -10;
            lastairunitmodel.weapons[6].ejectX = 10;
            lastairunitmodel.weapons[7].ejectX = -10;
            lastairunitmodel.weapons[8].ejectX = 0;
            lastairunitmodel.weapons[9].ejectX = 10;
            lastairunitmodel.weapons[9].ejectY = 25;

            towerModel.AddBehavior(strongairunitmodel);
            towerModel.AddBehavior(closeairunitmodel);
            towerModel.AddBehavior(lastairunitmodel);

            var bombbehavior = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).Duplicate();
            var mortar500 = Game.instance.model.GetTowerFromId("MortarMonkey-500").Duplicate();
            var bomb = bombbehavior.weapons[0];
            bomb.projectile.GetBehavior<CreateEffectOnExhaustFractionModel>().effectModel.assetId = new Il2CppAssets.Scripts.Utils.PrefabReference() { guidRef = "b1324f2f4c3809643b7ef1d8c112442a" };
            bomb.projectile.GetBehavior<CreateEffectOnExhaustFractionModel>().effectModel.scale = .8f;

            bomb.RemoveBehavior<CheckAirUnitOverTrackModel>();
            var emissionovertimemodel = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).weapons[0].emission.Duplicate();
            bomb.emission = new SingleEmmisionTowardsTargetModel("targetbloons", null, 0);
            bomb.rate = .85f;
            bomb.projectile.GetBehavior<FallToGroundModel>().timeToTake = 2.1f;


            var explosion = mortar500.GetAttackModel().weapons[0].projectile.GetBehaviors<CreateProjectileOnExhaustFractionModel>()[0].projectile.Duplicate();
            explosion.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            explosion.radius *= 1.1f;
            explosion.pierce = 100;
            explosion.GetBehavior<DamageModel>().damage = 24;
            explosion.AddBehavior(new DamageModifierForTagModel("boss", "Boss", 1, 48, false, true));
            explosion.GetBehavior<DamageModel>().maxDamage = 999999;
            explosion.GetBehavior<DamageModel>().CapDamage(999999);

            var superbrittle = Game.instance.model.GetTowerFromId("IceMonkey-500").GetDescendant<AddBonusDamagePerHitToBloonModel>();
            superbrittle.perHitDamageAddition = 8;

            var moabstun = Game.instance.model.GetTowerFromId("BombShooter-500").GetDescendant<SlowModel>().Duplicate();
            moabstun.lifespan *= .3f;
            explosion.collisionPasses = new[] { -1, 0 };

            explosion.AddBehavior(moabstun);
            explosion.AddBehavior(superbrittle);


            bomb.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = explosion;

            towerModel.AddBehavior(bombbehavior);

            var carrier = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-400").GetAttackModel(1).weapons[0].Duplicate();
            var plane = Game.instance.model.GetTowerFromId("BuccaneerGreaterPlane").Duplicate();
            var strafe = plane.GetAttackModel(0).weapons[0];
            var strafeprojectile = strafe.projectile;
            var missile = plane.GetAttackModel(2).weapons[0];
            var missileprojectile = missile.projectile;

            plane.GetBehavior<AirUnitModel>().display = CreatePrefabReference<MoabRavagerPlaneBaseDisplay>();
            plane.RemoveBehavior<TowerExpireOnParentUpgradedModel>();
            plane.GetAttackModel(1).RemoveWeapon(plane.GetAttackModel(1).weapons[0]);

            strafe.rate = .1f;
            strafe.projectile.GetBehavior<DamageModel>().damage = 60;
            strafe.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 1, 100, false, true));
            strafeprojectile.pierce += 100;
            strafeprojectile.display = CreatePrefabReference<BlueApacheLaserPulse>();
            missile.rate = 1f;

            plane.baseId = "Plane";
            carrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "Plane";
            carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 5;

            carrier.projectile.GetBehavior<CreateTowerModel>().tower = plane;
            carrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;

            var moabplane = plane.Duplicate();
            var moabmissile = moabplane.GetAttackModel(2).weapons[0];
            var moabmissileprojectile = moabmissile.projectile;
            var moabstrafe = moabplane.GetAttackModel(0);
            var moabstrafeprojectile = moabstrafe.weapons[0].projectile;
            var stun = Game.instance.model.GetTowerFromId("BombShooter-500").GetDescendant<SlowModel>().Duplicate();
            stun.lifespan = 1.1f;

            moabplane.baseId = "MoabPlane";
            moabplane.GetDescendant<FighterMovementModel>().maxSpeed -= 10;
            moabplane.GetDescendant<FighterMovementModel>().loopChancePerSecondPassed *= 1.1f;


            moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(stun);
            moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.collisionPasses = new[] { -1, 0 };
            moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 1000;
            moabmissileprojectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 25;
            moabmissileprojectile.scale = .5f;
            moabmissile.rate = 1.5f;

            moabplane.GetBehavior<AirUnitModel>().display = CreatePrefabReference<ParagonPlaneDisplay>();
            moabplane.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            plane.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            var moabcarrier = carrier.Duplicate();
            moabcarrier.projectile.GetBehavior<CreateTowerModel>().tower = moabplane;
            moabcarrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;
            moabcarrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "MoabPlane";
            moabcarrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 5;

            //planelauncher.AddWeapon(carrier);
            planelauncher.AddWeapon(moabcarrier);
            moabcarrier.AddBehavior(new FireFromAirUnitModel(""));
            carrier.AddBehavior(new FireFromAirUnitModel(""));
            towerModel.AddBehavior(planelauncher);

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        }
    }
}