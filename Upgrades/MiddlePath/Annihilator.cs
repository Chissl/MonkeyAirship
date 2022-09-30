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

namespace MonkeyAirship.Upgrades.MiddlePath
{
    public class Annihilator : ModUpgrade<MonkeyAirship>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 175000;
        
        public override string Description => "This behemoth of flying metal exterminates all bloons with its powerful lasers";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var strongairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[2];
            var firstairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[0];
            var lastairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[3];
            var closeairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[1];
            var centerlaserairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[4];
            //var carrier = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-400").GetAttackModel(1).weapons[0].Duplicate();

            var balloflight = Game.instance.model.GetTowerFromId("BallOfLightTower").Duplicate();

            balloflight.GetDescendant<LineProjectileEmissionModel>().dontUseTowerPosition = true;
            
            balloflight.GetAttackModel().weapons[0].AddBehavior(new FireFromAirUnitModel("fire"));
            var balloflightweapon = balloflight.GetAttackModel().weapons[0];

            balloflightweapon.projectile.GetDamageModel().damage = 12;
            balloflightweapon.projectile.CapPierce(999999);
            balloflightweapon.projectile.maxPierce = 999999;
            balloflightweapon.projectile.GetDamageModel().maxDamage = 999999;
            balloflightweapon.projectile.GetDamageModel().CapDamage(999999);

            /*var drone = Game.instance.model.GetTowerFromId("Drone").Duplicate();
            drone.targetTypes = towerModel.targetTypes;
            var pursuit = drone.GetDescendant<PursuitSettingCustomModel>();
            pursuit.mustBeInRangeOfParent = false;
            pursuit.pursuitDistance = 200;
            pursuit.initialTargetType = "Strong";
            pursuit.useParentForClose = false;
            var dronelaser = balloflightweapon.Duplicate();
            dronelaser.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Assets.Scripts.Utils.PrefabReference() { guidRef = "04ddde17722d5f640b0668c85eeea4ca" };
            drone.GetAttackModel().AddWeapon(dronelaser);

            var droneattackmodel = drone.GetDescendant<AttackAirUnitModel>();
            droneattackmodel.AddBehavior(new TargetStrongAirUnitModel("", false, true));
            droneattackmodel.targetProvider = new TargetStrongAirUnitModel("", false, true);
            droneattackmodel.range = 999999;

            var helimovement = drone.GetDescendant<HeliMovementModel>();
            helimovement.maxSpeed = 20;
            helimovement.rotationSpeed = .08f;
            
            var etienneability = Game.instance.model.GetTowerFromId("Etienne 3").GetDescendant<AbilityModel>();
            etienneability.GetDescendant<DroneSupportModel>().droneModel = drone;*/
            
            
            var laserstrike = Game.instance.model.GetTowerFromId("DartlingGunner-050").GetDescendant<ActivateAttackModel>().Duplicate();
            var laserstrikeattack = balloflight.Duplicate();
            var weaklaser = laserstrikeattack.Duplicate();
            var displaylaser = laserstrikeattack.Duplicate();
            displaylaser.GetDescendant<LineProjectileEmissionModel>().useTargetAsEndPoint = false;
            weaklaser.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Assets.Scripts.Utils.PrefabReference() { guidRef = "d48587764ad63c84ea37e82f58bd05ad" };
            
            laserstrike.attacks[0].targetProvider = new TargetStrongAirUnitModel("", false, false);
            laserstrike.attacks[0].AddBehavior(new TargetStrongAirUnitModel("", false, false));

            laserstrikeattack.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 120;
            laserstrikeattack.GetDescendant<LineProjectileEmissionModel>().displayPath.assetPath = new Assets.Scripts.Utils.PrefabReference() { guidRef = "b9f3014db2da83f48b34e662e9a79910" };
            
            laserstrike.attacks[0].weapons[0] = laserstrikeattack.GetAttackModel().weapons[0].Duplicate();
            laserstrike.attacks[0].fireWithoutTarget = false;
            laserstrike.lifespan *= .8f;
            laserstrike.attacks[0].AddWeapon(weaklaser.GetAttackModel().weapons[0].Duplicate());
            laserstrike.attacks[0].weapons[1].ejectY = 25;
            laserstrike.attacks[0].AddWeapon(displaylaser.GetAttackModel().weapons[0].Duplicate());
            laserstrike.attacks[0].weapons[2].ejectY = -25;
            laserstrike.attacks[0].AddWeapon(displaylaser.GetAttackModel().weapons[0].Duplicate());


            towerModel.GetDescendant<AbilityModel>().AddBehavior(laserstrike);



            foreach (var attackairunitmodel in towerModel.GetBehaviors<AttackAirUnitModel>())
            {
                attackairunitmodel.range += 50;
                attackairunitmodel.weapons[0].projectile.display = new Assets.Scripts.Utils.PrefabReference() { guidRef = "6c11e1432d6321c44b216600b2cdbac6" };
                attackairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramic", "Ceramic", 1, 3, false, true));
                attackairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("fortified", "Fortified", 1, 3, false, true));
                attackairunitmodel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("moabs", "Moabs", 1, 2, false, true));
                attackairunitmodel.weapons[0].projectile.pierce += 5;
                attackairunitmodel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 2;
                attackairunitmodel.weapons[0].rate *= .8f;
                //attackairunitmodel.weapons[0].projectile.scale *= 1.5f;
            }
            centerlaserairunitmodel.range = 999999;
            centerlaserairunitmodel.weapons[0] = balloflightweapon.Duplicate();
            firstairunitmodel.weapons[0].ejectY = 5;
            firstairunitmodel.weapons[0].ejectX = -10;
            closeairunitmodel.weapons[0].ejectY = -5;
            firstairunitmodel.weapons[0].ejectX = -10;
            strongairunitmodel.weapons[0].ejectY = 10;
            strongairunitmodel.weapons[0].ejectX = -10;
            lastairunitmodel.weapons[0].ejectY = -10;
            lastairunitmodel.weapons[0].ejectX = -10;
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.weapons[1].ejectX = -10;
            firstairunitmodel.weapons[1].ejectY = -15;
            firstairunitmodel.weapons[1].ejectZ = -5;
            strongairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            firstairunitmodel.weapons[2].ejectX = 10;
            strongairunitmodel.AddWeapon(firstairunitmodel.weapons[2].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.weapons[3].ejectX = 10;
            strongairunitmodel.AddWeapon(strongairunitmodel.weapons[0].Duplicate());
            strongairunitmodel.weapons[3].ejectX = 10;
            closeairunitmodel.AddWeapon(closeairunitmodel.weapons[0].Duplicate());
            closeairunitmodel.weapons[1].ejectX = 10;
            lastairunitmodel.AddWeapon(lastairunitmodel.weapons[0].Duplicate());
            lastairunitmodel.weapons[1].ejectX = 10;
            closeairunitmodel.AddWeapon(firstairunitmodel.weapons[1].Duplicate());
            closeairunitmodel.AddWeapon(firstairunitmodel.weapons[2].Duplicate());
            firstairunitmodel.AddWeapon(firstairunitmodel.weapons[0].Duplicate());
            firstairunitmodel.weapons[4].ejectX = 0;
            firstairunitmodel.weapons[4].ejectY = 25;
            strongairunitmodel.AddWeapon(firstairunitmodel.weapons[4].Duplicate());
            closeairunitmodel.AddWeapon(firstairunitmodel.weapons[4].Duplicate());
            var frontlaserairunitmodel = centerlaserairunitmodel.Duplicate();
            frontlaserairunitmodel.weapons[0].ejectY = 28;
            frontlaserairunitmodel.AddBehavior(new TargetFirstAirUnitModel("targetfirst", false, false));
            frontlaserairunitmodel.targetProvider = new TargetFirstAirUnitModel("targetfirst", false, false);
            towerModel.AddBehavior(frontlaserairunitmodel);
            towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Display050>();




        }
    }
}