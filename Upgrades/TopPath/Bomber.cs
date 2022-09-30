using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Unity;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using MonkeyAirship.Upgrades.MiddlePath;
using MonkeyAirship.Upgrades.BottomPath;
using MonkeyAirship.Displays;
using Assets.Scripts.Models.Towers.Behaviors;

namespace MonkeyAirship.Upgrades.TopPath
{
    public class Bomber : ModUpgrade<MonkeyAirship>
    {

        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 2100;

        public override string Description => "Drops bombs on nearby bloons that stuns them temporarily";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 3)
            {
                var bombbehavior = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).Duplicate();
                var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
                var bomb = bombbehavior.weapons[0];
                bomb.projectile.AddBehavior(new DamageModel("dummy", 0, 0, false, false, false, BloonProperties.None, BloonProperties.None));
                bomb.projectile.GetDamageModel().CapDamage(0);
                bomb.RemoveBehavior<CheckAirUnitOverTrackModel>();
                var emissionovertimemodel = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).weapons[0].emission.Duplicate();
                bomb.emission = new SingleEmmisionTowardsTargetModel("targetbloons", null, 0);
                bomb.rate = .85f;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    bomb.rate *= .66f;
                }
                bomb.projectile.GetBehavior<FallToGroundModel>().timeToTake = 2.1f;
                var explosion = bomb.projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;
                explosion.GetBehavior<DamageModel>().damage = 7;
                explosion.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
                explosion.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
                explosion.radius *= .7f;
                var stun = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModel>().Duplicate();
                var stuntag = Game.instance.model.GetTowerFromId("BombShooter-400").GetDescendant<SlowModifierForTagModel>().Duplicate();
                explosion.collisionPasses = new[] { -1, 0 };
                explosion.AddBehavior(stun);
                explosion.AddBehavior(stuntag);
                if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
                {
                    explosion.pierce += 8;
                    explosion.radius += 3;
                }

                bomb.projectile.GetBehavior<DisplayModel>().positionOffset += new Assets.Scripts.Simulation.SMath.Vector3(0, 0, 5);
                towerModel.AddBehavior(bombbehavior);
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display300>();
            }
        }
    }
}