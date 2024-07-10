

namespace MonkeyAirship.Upgrades.TopPath
{
    public class HeavyBomber : ModUpgrade<MonkeyAirship>
    {

        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 6200;

        public override string Description => "Upgraded bombs have deal more damage and weaken nearby bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 4)
            {
                var bombbehavior = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).Duplicate();
                var bomb = bombbehavior.weapons[0];
                bomb.projectile.AddBehavior(new DamageModel("dummy", 0, 0, false, false, false, BloonProperties.None, BloonProperties.None, false));
                bomb.projectile.GetDamageModel().CapDamage(0);
                bomb.RemoveBehavior<CheckAirUnitOverTrackModel>();
                bomb.emission = new SingleEmmisionTowardsTargetModel("targetbloons", null, 0);
                bomb.rate = .85f;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    bomb.rate *= .66f;
                }
                bomb.projectile.GetBehavior<FallToGroundModel>().timeToTake = 2.1f;
                var explosion = bomb.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;
                explosion.radius *= .7f;
                explosion.GetBehavior<DamageModel>().damage = 8;
                explosion.GetBehavior<DamageModel>().maxDamage = 999999;
                explosion.GetBehavior<DamageModel>().CapDamage(999999);
                
                var stun = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModel>().Duplicate();
                var stuntag = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModifierForTagModel>().Duplicate();
                explosion.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-400").GetDescendant<AddBonusDamagePerHitToBloonModel>());
                stun.lifespan = 1.5f;
                explosion.collisionPasses = new[] { -1, 0 };
                explosion.AddBehavior(stun);
                explosion.AddBehavior(stuntag);
                explosion.pierce = 50;


                if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
                {
                    explosion.pierce += 8;
                    explosion.radius += 5;
                }

                bomb.projectile.GetBehavior<DisplayModel>().positionOffset += new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0, 0, 0);
                towerModel.AddBehavior(bombbehavior);
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display400>();
                
            }
        }
    }
}