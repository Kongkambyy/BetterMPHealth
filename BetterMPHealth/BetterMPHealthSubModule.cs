using TaleWorlds.MountAndBlade;

namespace BetterMPHealth {
    public class BetterMPHealthSubModule : MBSubModuleBase {
        protected override void OnSubModuleLoad() {
            base.OnSubModuleLoad();
        }

        public override void OnMissionBehaviorInitialize(Mission mission) {
            base.OnMissionBehaviorInitialize(mission);
            mission.AddMissionBehavior(new BetterMPHealthManager());
        }
    }
}