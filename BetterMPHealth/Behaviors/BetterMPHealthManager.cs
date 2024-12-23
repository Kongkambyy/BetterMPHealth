// HealthHUDManager.cs
using TaleWorlds.MountAndBlade;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.ScreenSystem;

namespace BetterMPHealth {
    public class BetterMPHealthManager : MissionBehavior {
        private GauntletLayer? layer;
        private BetterMPHealthVM? dataSource;
       
        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void AfterStart() {
            layer = new GauntletLayer(49);
            dataSource = new BetterMPHealthVM();
            layer.LoadMovie("BetterMPHealth", dataSource);
            ScreenManager.TopScreen.AddLayer(layer);
        }

        public override void OnMissionTick(float dt) {
            if (dataSource == null || Mission.MainAgent == null) return;

            dataSource.PlayerHealth = $"{(int)Mission.MainAgent.Health}/{(int)Mission.MainAgent.HealthLimit}";
           
            if (Mission.MainAgent.HasMount)
                dataSource.MountHealth = $"{(int)Mission.MainAgent.MountAgent.Health}/{(int)Mission.MainAgent.MountAgent.HealthLimit}";
               
            if (Mission.MainAgent.WieldedOffhandWeapon.IsShield())
                dataSource.ShieldHealth = $"{(int)Mission.MainAgent.WieldedOffhandWeapon.HitPoints}/{(int)Mission.MainAgent.WieldedOffhandWeapon.ModifiedMaxHitPoints}";
        }
    }
}