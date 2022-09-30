using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Unity;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using MonkeyAirship.Displays;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors;
using MonkeyAirship.Upgrades.TopPath;
using MonkeyAirship.Upgrades.MiddlePath;
using Assets.Scripts.Models.Towers.Filters;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Weapons;

namespace MonkeyAirship.Upgrades.BottomPath
{
    public class LightCarrier : ModUpgrade<MonkeyAirship>
    {

        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 2150;

        public override string Description => "Launches an escort of fighter planes!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            if (towerModel.tier == 3)
            {
                var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
                var firefromairunitmodel = attackairunitmodel.GetDescendant<FireFromAirUnitModel>();
                var carrier = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-400").GetAttackModel(1).weapons[0].Duplicate();
                var plane = Game.instance.model.GetTowerFromId("BuccaneerLesserPlane").Duplicate();
                var strafe = plane.GetAttackModel(0).weapons[0];
                var strafeprojectile = strafe.projectile;


                plane.GetBehavior<TowerExpireOnParentUpgradedModel>().parentTowerUpgradeTier = 3;
                plane.GetAttackModel(2).weapons[0].rate = 9999999;
                plane.GetAttackModel(2).weapons[0].startInCooldown = true;
                plane.GetAttackModel(1).weapons[0].rate = 9999999;
                plane.GetAttackModel(1).weapons[0].startInCooldown = true;
                strafe.rate = .4f;
                strafeprojectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                strafeprojectile.pierce = 5;


                if (towerModel.appliedUpgrades.Contains(UpgradeID<MobileReconnaissance>()))
                {
                    plane.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                    var firefromplane = plane.GetDescendant<FireFromAirUnitModel>();
                    var decamo = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 3).GetWeapons()[1].Duplicate();
                    decamo.behaviors = new Il2CppReferenceArray<WeaponBehaviorModel>(new WeaponBehaviorModel[] { firefromairunitmodel });
                    decamo.rate = .01f;
                    decamo.projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "" };
                    decamo.projectile.radius = 20;
                    plane.GetAttackModel(0).AddWeapon(decamo);
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<FasterFiring>()))
                {
                    strafe.rate *= .66f;
                }
                plane.baseId = "BuccaneerLesserPlane";
                carrier.GetBehavior<SubTowerFilterModel>().baseSubTowerId = "BuccaneerLesserPlane";
                carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 3;
                if (towerModel.appliedUpgrades.Contains(UpgradeID<TwinGuns>()))
                {
                    carrier.GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 4;
                }
                if (towerModel.appliedUpgrades.Contains(UpgradeID<ImprovedEngines>()))
                {
                    plane.GetDescendant<FighterMovementModel>().maxSpeed *= 1.2f;
                    plane.GetDescendant<FighterMovementModel>().loopTimeBeforeNext *= .75f;
                }
                carrier.projectile.GetBehavior<CreateTowerModel>().positionAtTarget = false;
                carrier.projectile.AddBehavior(firefromairunitmodel);
                carrier.projectile.GetBehavior<CreateTowerModel>().tower = plane;
                attackairunitmodel.AddWeapon(carrier);
                towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display003>();
            }
        }
    }
}