using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using MonkeyAirship.Displays;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Models.GenericBehaviors;

namespace MonkeyAirship
{ 
    public class MonkeyAirship : ModTower
    {
        public override string TowerSet => TowerSetType.Military;
        public override string BaseTower => TowerType.MonkeyAce;
        public override int Cost => 910;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Slow-moving airship that pops bloons with its powerful machine gun";
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.footprint = Game.instance.model.GetTowerFromId("HeliPilot").footprint;
            var tower = towerModel.GetBehavior<AirUnitModel>();
            var attackairunitmodel = towerModel.GetBehaviors<AttackAirUnitModel>()[0];
            var weapons = attackairunitmodel.weapons[0];
            var projectile = weapons.projectile;
            towerModel.range = 0;
            tower.display = CreatePrefabReference<MonkeyAirshipBaseDisplay>(); 
            tower.behaviors[0].Cast<PathMovementModel>().speed = 10;
            tower.behaviors[0].Cast<PathMovementModel>().rotation = 30f;
            attackairunitmodel.fireWithoutTarget = false;
            attackairunitmodel.range = 80;             
            weapons.emission = Game.instance.model.GetTowerFromId("MonkeyAce-004").GetBehaviors<AttackAirUnitModel>()[1].weapons[0].emission; //sets targeting to 004 ace
            //weapons.ejectY = 10;
            weapons.Rate = .4f; //fire speed
            attackairunitmodel.AddBehavior(new EmissionWithOffsetsModel("offsetmodel", null, 1, false, null, 10));
            projectile.RemoveBehavior<TrackTargetModel>(); 
            projectile.GetDamageModel().damage = 1;
            projectile.pierce = 2;
            projectile.scale = .7f;
            projectile.GetBehavior<TravelStraitModel>().speed = 400; 
            


        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.MonkeyAce).towerIndex + 1;
        }
        public override bool IsValidCrosspath(int[] tiers) =>
           HasMod("UltimateCrosspathing") ? true : base.IsValidCrosspath(tiers);
    }
}
