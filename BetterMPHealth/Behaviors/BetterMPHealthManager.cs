using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ScreenSystem;

namespace BetterMPHealth {
    public class BetterMPHealthManager : MissionView {
        private GauntletLayer? layer;
        private BetterMPHealthVM? dataSource;

        public override void OnMissionScreenInitialize() {
            base.OnMissionScreenInitialize();
            
            layer = new GauntletLayer(49, "GauntletLayer");
            dataSource = new BetterMPHealthVM();
            layer.LoadMovie("BetterMPHealth", dataSource);
            
            MissionScreen.AddLayer(layer);
        }

        public override void OnMissionScreenTick(float dt) {
            base.OnMissionScreenTick(dt);

            if (dataSource == null || Mission.MainAgent == null) 
                return;

            if (Mission.MainAgent.Health > 0) {
                dataSource.PlayerHealth = $"{(int)Mission.MainAgent.Health}/{(int)Mission.MainAgent.HealthLimit}";
                
                if (Mission.MainAgent.HasMount && Mission.MainAgent.MountAgent != null)
                    dataSource.MountHealth = $"{(int)Mission.MainAgent.MountAgent.Health}/{(int)Mission.MainAgent.MountAgent.HealthLimit}";
                else
                    dataSource.MountHealth = "";
                    
                if (Mission.MainAgent.WieldedOffhandWeapon.IsShield())
                    dataSource.ShieldHealth = $"{(int)Mission.MainAgent.WieldedOffhandWeapon.HitPoints}/{(int)Mission.MainAgent.WieldedOffhandWeapon.ModifiedMaxHitPoints}";
                else
                    dataSource.ShieldHealth = "";
            }
        }

        public override void OnMissionScreenFinalize() {
            MissionScreen.RemoveLayer(layer);
            layer = null;
            dataSource = null;
            
            base.OnMissionScreenFinalize();
        }
    }
}