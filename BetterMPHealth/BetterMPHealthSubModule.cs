using TaleWorlds.MountAndBlade;

namespace BetterMPHealth {
    public class BetterMPHealthSubModule : MBSubModuleBase {
        public override void OnMissionBehaviorInitialize(Mission mission) {
            mission.AddMissionBehavior(new BetterMPHealthManager());
        }
    }
}