

namespace MonkeyAirship.Upgrades.TopPath
{
    public class Devastator : ModUpgrade<MonkeyAirship>
    {

        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 38500;

        public override string Description => "Improved bombs stun and weaken all bloons in radius, including Moab-class bloons!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 5)
            {
                var bombbehavior = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).Duplicate();
                var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
                var mortar500 = Game.instance.model.GetTowerFromId("MortarMonkey-500").Duplicate();
                var bomb = bombbehavior.weapons[0];
                bomb.projectile.AddBehavior(new DamageModel("dummy", 0, 0, false, false, false, BloonProperties.None, BloonProperties.None, false));
                bomb.projectile.GetDamageModel().CapDamage(0);
                bomb.projectile.GetBehavior<CreateEffectOnExhaustFractionModel>().effectModel.assetId = new Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference() { guidRef = "b1324f2f4c3809643b7ef1d8c112442a" };
                bomb.projectile.GetBehavior<CreateEffectOnExhaustFractionModel>().effectModel.scale = .6f;
                
                bomb.RemoveBehavior<CheckAirUnitOverTrackModel>();
                var emissionovertimemodel = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).weapons[0].emission.Duplicate();
                bomb.emission = new SingleEmmisionTowardsTargetModel("targetbloons", null, 0);
                bomb.rate = .85f;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    bomb.rate *= .66f;
                }
                bomb.projectile.GetBehavior<FallToGroundModel>().timeToTake = 2.1f;
                

                var explosion = mortar500.GetAttackModel().weapons[0].projectile.GetBehaviors<CreateProjectileOnExhaustFractionModel>()[0].projectile.Duplicate();
                explosion.radius *= .8f;
                explosion.pierce = 75;
                explosion.GetBehavior<DamageModel>().damage = 8;
                explosion.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
                explosion.AddBehavior(new DamageModifierForTagModel("Ceramic", "Ceramic", 1, 6, false, true));
                explosion.GetBehavior<DamageModel>().maxDamage = 999999;
                explosion.GetBehavior<DamageModel>().CapDamage(999999);

                var superbrittle = Game.instance.model.GetTowerFromId("IceMonkey-500").GetDescendant<AddBonusDamagePerHitToBloonModel>();
                superbrittle.perHitDamageAddition = 2;

                var moabstun = Game.instance.model.GetTowerFromId("BombShooter-500").GetDescendant<SlowModel>().Duplicate();
                moabstun.lifespan *= .15f;
                var stun = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModel>().Duplicate();
                var stuntag = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModifierForTagModel>().Duplicate();
                explosion.collisionPasses = new[] { -1, 0 };
                
                if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
               {
                    moabstun.lifespan *= 1.2f;
                    explosion.radius += 10;
               }
                
                explosion.AddBehavior(stun);
                explosion.AddBehavior(stuntag);
                explosion.AddBehavior(moabstun);
                explosion.AddBehavior(superbrittle);


                bomb.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = explosion;
                
                towerModel.AddBehavior(bombbehavior);
                towerModel.GetBehaviors<AttackAirUnitModel>()[0].weapons[0].projectile.display = CreatePrefabReference<DevastatorRocketDisplay>();
                towerModel.GetBehaviors<AttackAirUnitModel>()[0].weapons[0].projectile.pierce += 25;
                towerModel.GetBehaviors<AttackAirUnitModel>()[0].weapons[0].projectile.GetDamageModel().damage += 5;
                towerModel.GetBehaviors<AttackAirUnitModel>()[0].weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 4, false, true));
                towerModel.GetBehaviors<AttackAirUnitModel>()[0].weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 2, false, true));
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display500>();

            }
        }
    }
}