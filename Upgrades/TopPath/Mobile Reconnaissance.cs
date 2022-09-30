using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors;
using MonkeyAirship.Displays;

namespace MonkeyAirship.Upgrades.TopPath

{
    public class MobileReconnaissance : ModUpgrade<MonkeyAirship>
    {

        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 540;

        public override string Description => "Mobile Reconnaissance allows Monkey Airship to pop and reveal nearby Camo bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
            attackairunitmodel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            var firefromairunitmodel = attackairunitmodel.weapons[0].GetBehavior<FireFromAirUnitModel>();
            var decamo = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 3).GetAttackModel(1).Duplicate();
            decamo.weapons[0].behaviors = new Il2CppReferenceArray<WeaponBehaviorModel>(new WeaponBehaviorModel[] {firefromairunitmodel});
            decamo.weapons[0].rate = .6f;
            decamo.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "" };
            decamo.weapons[0].projectile.radius = 50;
            decamo.weapons[0].projectile.AddBehavior(new DamageModel("", 0, 0, false, false, false, BloonProperties.None, BloonProperties.None));
            attackairunitmodel.AddBehavior(decamo);
            attackairunitmodel.addsToSharedGrid = true;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display200>();
        }
    }
}