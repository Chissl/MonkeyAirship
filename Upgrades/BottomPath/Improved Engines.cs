namespace MonkeyAirship.Upgrades.BottomPath

{
    public class ImprovedEngines : ModUpgrade<MonkeyAirship>
    {

        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 540;

        public override string Description => "Improved Engines allows Monkey Airship to be more manueverable!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var airunitmodel = towerModel.GetBehavior<AirUnitModel>();
            airunitmodel.behaviors[0].Cast<PathMovementModel>().speed += 4;
            airunitmodel.behaviors[0].Cast<PathMovementModel>().rotation += 20;
            var attackairunitmodel = towerModel.GetBehavior<AttackAirUnitModel>();
            towerModel.targetTypes = Game.instance.model.GetTowerFromId("MonkeyAce-002").targetTypes;
            attackairunitmodel.AddBehavior(Game.instance.model.GetTowerFromId("MonkeyAce-002").GetBehavior<AttackAirUnitModel>().GetBehavior<CenterElipsePatternModel>());
            var docking = attackairunitmodel.GetBehavior<CenterElipsePatternModel>();
            docking.canSelectPoint = true;
            docking._name = "Docking";
            docking.widthRadius = 30;
            docking.heightRadius = 30;

            airunitmodel.display = CreatePrefabReference<Display100>();
            
        }
    }
}