using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ScreenSystem;

namespace BetterMPHealth
{
    [DefaultView]
    public class BetterMPHealthManager : MissionView
    {
        private GauntletLayer? layer;
        private BetterMPHealthVM? dataSource;

        public override void OnMissionScreenInitialize()
        {
            base.OnMissionScreenInitialize();

            layer = new GauntletLayer(49, "GauntletLayer");
            dataSource = new BetterMPHealthVM();
            layer.LoadMovie("BetterMPHealth", dataSource);

            MissionScreen.AddLayer(layer);
        }

        public override void OnMissionScreenTick(float dt)
        {
            base.OnMissionScreenTick(dt);
            // Rest of the method implementation
        }

        public override void OnMissionScreenFinalize()
        {
            MissionScreen.RemoveLayer(layer);
            layer = null;
            dataSource = null;

            base.OnMissionScreenFinalize();
        }
    }
}