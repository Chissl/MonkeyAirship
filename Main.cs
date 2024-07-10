using MelonLoader;
using BTD_Mod_Helper;
using MonkeyAirship;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using System;

using ModHelperData = MonkeyAirship.ModHelperData;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

[assembly: MelonInfo(typeof(MonkeyAirship.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MonkeyAirship
{
    public class Main : BloonsTD6Mod
    {

        [HarmonyPatch(typeof(TowerManager), "UpgradeTower")]
        internal class Tower_Initialise
        {
            [HarmonyPrefix]
            internal static bool Prefix(int inputIndex,
      Tower tower,
      TowerModel def,
      int pathIndex,
      float upgradeCost,
      float costMultiplier,
      bool triggerOnUpgraded = true,
      bool triggerOnUpgrade = true,
      bool playUpgradeEffect = true,
      bool isParagon = false,
      bool leveledFromEndOfRoundXp = false)
            {
                if (def.name == "Eradicator")
                {
                    if (tower.towerModel.tiers[0] == 5)
                    {
                        tower.SetTargetType(def.targetTypes[0]);
                    }
                    else if (tower.towerModel.tiers[2] == 5)
                    {
                        tower.towerModel = Game.instance.model.GetTowerFromId("MonkeySub-050");
                    }
                }
                return true;
            }
        }

        public override void OnTowerUpgraded(Tower tower, string upgradeName, Il2CppAssets.Scripts.Models.Towers.TowerModel newBaseTowerModel)
        {
            base.OnTowerUpgraded(tower, upgradeName, newBaseTowerModel);

            if (tower.towerModel.name == "Eradicator")
            {
                var degree = tower.GetTowerBehavior<ParagonTower>().GetCurrentDegree(); ;
                foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                {
                    foreach (var weapon in attackmodel.weapons)
                    {
                        weapon.rate *= 1 - (degree) / 200;
                        weapon.projectile.pierce += degree * 2.5f;
                        weapon.projectile.GetDamageModel().damage += degree / 8;
                        weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 1.25f, 5, false, true));
                    }
                    attackmodel.weapons[9].projectile.GetDamageModel().damage += degree / 4;
                }
                tower.towerModel.GetBehaviors<AttackAirUnitModel>()[1].weapons[10].projectile.GetDamageModel().damage += degree * 2f;

                if (degree >= 20)
                {
                    foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                    {
                        foreach (var weapon in attackmodel.weapons)
                        {
                            weapon.projectile.GetDamageModel().damage += 5;
                            weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 1.5f, 5, false, true));
                        }
                        attackmodel.weapons[9].projectile.GetDamageModel().damage += 10;
                    }
                    tower.towerModel.GetBehaviors<AttackAirUnitModel>()[1].weapons[10].projectile.GetDamageModel().damage += 20;
                }

                if (degree >= 40)
                {
                    foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                    {
                        foreach (var weapon in attackmodel.weapons)
                        {
                            weapon.projectile.GetDamageModel().damage += 5;
                            weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 1.75f, 10, false, true));
                        }
                        attackmodel.weapons[9].projectile.GetDamageModel().damage += 10;
                    }
                    tower.towerModel.GetBehaviors<AttackAirUnitModel>()[1].weapons[10].projectile.GetDamageModel().damage += 20;
                }

                if (degree >= 60)
                {
                    foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                    {
                        foreach (var weapon in attackmodel.weapons)
                        {
                            weapon.projectile.GetDamageModel().damage += 5;
                            weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2f, 15, false, true));
                        }
                        attackmodel.weapons[9].projectile.GetDamageModel().damage += 10;
                    }
                    tower.towerModel.GetBehaviors<AttackAirUnitModel>()[1].weapons[10].projectile.GetDamageModel().damage += 20;
                }

                if (degree >= 80)
                {
                    foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                    {
                        foreach (var weapon in attackmodel.weapons)
                        {
                            weapon.projectile.GetDamageModel().damage += 5;
                            weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2.25f, 20, false, true));
                        }
                    }
                }
                if (degree == 100)
                {
                    foreach (var attackmodel in tower.towerModel.GetBehaviors<AttackAirUnitModel>())
                    {
                        foreach (var weapon in attackmodel.weapons)
                        {
                            weapon.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 2.5f, 30, false, true));
                        }
                        attackmodel.weapons[9].projectile.GetDamageModel().damage += 10;
                    }
                    tower.towerModel.GetBehaviors<AttackAirUnitModel>()[1].weapons[10].projectile.GetDamageModel().damage += 20;
                }
            }
        }
    }
}