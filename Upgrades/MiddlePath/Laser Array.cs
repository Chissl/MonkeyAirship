using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.Towers.Projectiles;
using MonkeyAirship.Displays;
using Assets.Scripts.Models.Towers.Behaviors;
using MonkeyAirship.Upgrades.TopPath;
using MonkeyAirship.Upgrades.MiddlePath;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Simulation.Towers.Emissions.Behaviors;
using Assets.Scripts.Simulation.Towers.Emissions;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using MonkeyAirship.Upgrades.BottomPath;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using BTD_Mod_Helper.Api;

namespace MonkeyAirship.Upgrades.MiddlePath
{
    public class LaserArray : ModUpgrade<MonkeyAirship>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 28000;
        
        public override string Description => "Adds a powerful new beam attack that targets the strongest bloon on screen!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var strongairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[2];
            strongairunitmodel.RemoveWeapon(strongairunitmodel.weapons[0]);
            var firstairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[0];
            var lastairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>().Duplicate();
            var centerlaserairunitmodel = strongairunitmodel.Duplicate();
            var closeairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[1];
            towerModel.GetAttackModel(0).weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "6c11e1432d6321c44b216600b2cdbac6" };

            var balloflight = Game.instance.model.GetTowerFromId("BallOfLightTower").Duplicate();
            balloflight.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Assets.Scripts.Utils.PrefabReference() { guidRef = "d48587764ad63c84ea37e82f58bd05ad" };
            balloflight.GetDescendant<LineProjectileEmissionModel>().dontUseTowerPosition = true;
            //balloflight.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Assets.Scripts.Utils.PrefabReference() { guidRef = "d48587764ad63c84ea37e82f58bd05ad" };
            balloflight.GetAttackModel().weapons[0].AddBehavior(new FireFromAirUnitModel("fire"));
            var balloflightweapon = balloflight.GetAttackModel().weapons[0];

            balloflightweapon.projectile.GetDamageModel().damage = 1;
            balloflightweapon.projectile.AddBehavior(new DamageModifierForTagModel("moabs", "Moabs", 1, 1, false, true));
            balloflightweapon.projectile.pierce = 4;
            balloflightweapon.projectile.CapPierce(999999);
            balloflightweapon.projectile.maxPierce = 999999;
            balloflightweapon.projectile.GetDamageModel().maxDamage = 999999;
            balloflightweapon.projectile.GetDamageModel().CapDamage(999999);;
            var abilitymodel = Game.instance.model.GetTowerFromId("MortarMonkey-040").GetBehavior<AbilityModel>().Duplicate();
            var turbomodel = abilitymodel.GetBehavior<TurboModel>();
            turbomodel.multiplier = .4f;
            turbomodel.extraDamage = 1;
            abilitymodel.icon = GetSpriteReference(mod, "AbilityIcon");
            towerModel.GetAttackModel().AddBehavior(abilitymodel);


            centerlaserairunitmodel.AddWeapon(balloflight.GetAttackModel().weapons[0]);            
            firstairunitmodel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            firstairunitmodel.weapons[0].ejectY = 10;

            closeairunitmodel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            closeairunitmodel.targetProvider = new TargetCloseAirUnitModel("targetclose", false, false);
            closeairunitmodel.AddBehavior(new TargetCloseAirUnitModel("targetclose", false, false));
            closeairunitmodel.weapons[0].ejectY = 15;

            //firstairunitmodel.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "7952d3e088920174c8d2450218ab3f14" };

            lastairunitmodel.targetProvider = new TargetLastAirUnitModel("targetlast", false, false);
            lastairunitmodel.AddBehavior(new TargetLastAirUnitModel("targetlast", false, false));
            lastairunitmodel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            lastairunitmodel.weapons[0].ejectY = -15;
            //lastairunitmodel.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "7952d3e088920174c8d2450218ab3f14" };

            strongairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            strongairunitmodel.weapons[0].ejectY = -10;
            //strongairunitmodel.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "7952d3e088920174c8d2450218ab3f14" };

            towerModel.AddBehavior(lastairunitmodel);

            strongairunitmodel.range += 40;
            strongairunitmodel.weapons[0].projectile.ApplyDisplay<PinkLaserDisplay>();
            strongairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
            strongairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
            strongairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Moabs", 1, 2, false, true));
            strongairunitmodel.weapons[0].projectile.pierce += 6;
            strongairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 2;
            strongairunitmodel.weapons[0].rate *= .5f;
            if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
            {
                strongairunitmodel.weapons[0].projectile.pierce += 4;
            }
            if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
            {
                strongairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 1;
            }
            lastairunitmodel.range += 40;
            lastairunitmodel.weapons[0].projectile.ApplyDisplay<PinkLaserDisplay>();
            lastairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
            lastairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
            lastairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Moabs", 1, 2, false, true));
            lastairunitmodel.weapons[0].projectile.pierce += 6;
            lastairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 2;
            lastairunitmodel.weapons[0].rate *= .5f;
            if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
            {
                lastairunitmodel.weapons[0].projectile.pierce += 4;
            }
            if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
            {
                lastairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 1;
            }
            firstairunitmodel.range += 40;
            firstairunitmodel.weapons[0].projectile.ApplyDisplay<PinkLaserDisplay>();
            firstairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
            firstairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
            firstairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Moabs", 1, 2, false, true));
            firstairunitmodel.weapons[0].projectile.pierce += 6;
            firstairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 2;
            firstairunitmodel.weapons[0].rate *= .5f;
            if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
            {
                firstairunitmodel.weapons[0].projectile.pierce += 4;
            }
            if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
            {
                firstairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 1;
            }
            closeairunitmodel.range += 40;
            closeairunitmodel.weapons[0].projectile.ApplyDisplay<PinkLaserDisplay>();
            closeairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
            closeairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
            closeairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Moabs", 1, 2, false, true));
            closeairunitmodel.weapons[0].projectile.pierce += 6;
            closeairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 2;
            closeairunitmodel.weapons[0].rate *= .5f;
            if (towerModel.appliedUpgrades.Contains(UpgradeID<PowerfulDarts>()))
            {
                closeairunitmodel.weapons[0].projectile.pierce += 4;
            }
            if (towerModel.appliedUpgrades.Contains(UpgradeID<BloontoniumDarts>()))
            {
                closeairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 1;
            }
            towerModel.AddBehavior(centerlaserairunitmodel);
            centerlaserairunitmodel.range += 40;
            towerModel.GetBehavior<AirUnitModel>().behaviors[0].Cast<PathMovementModel>().speed += 8;
            towerModel.GetBehavior<AirUnitModel>().behaviors[0].Cast<PathMovementModel>().rotation += 30;
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display040>();
        }
    }
}
