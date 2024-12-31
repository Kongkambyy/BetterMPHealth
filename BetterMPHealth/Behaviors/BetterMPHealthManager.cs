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

        private Agent _mainAgent;
        private Agent _mountAgent;
        private MissionWeapon? _shieldWeapon;

        public override void OnMissionScreenInitialize()
        {
            base.OnBehaviorInitialize();

            layer = new GauntletLayer(49, "GauntletLayer");
            dataSource = new BetterMPHealthVM();
            layer.LoadMovie("BetterMPHealth", dataSource);

            MissionScreen.AddLayer(layer);
        }


        public override void OnMissionScreenTick(float dt)
        {
            base.OnMissionScreenTick(dt);

            if (dataSource != null)
            {
                _mainAgent = Mission.Current.MainAgent;
                if (_mainAgent == null || !_mainAgent.IsActive())
                {
                    dataSource.PlayerHealth = "";
                    dataSource.MountHealth = "";
                    dataSource.ShieldHealth = "";
                    return;
                }

                _mountAgent = _mainAgent.MountAgent;
                _shieldWeapon = _mainAgent.WieldedOffhandWeapon;

                dataSource.PlayerHealth = GetHealthDisplay(_mainAgent, true);
                dataSource.MountHealth = GetMountHealthDisplay(_mountAgent);
                dataSource.ShieldHealth = PlayerShieldDisplay();
            }
        }
        
        private string GetHealthDisplay(Agent agent, bool percent)
        {
            if (agent != null)
            {
                if (percent)
                {
                    return Math.Floor(agent.Health / agent.HealthLimit * 100) + "";
                }

                return Math.Round(agent.Health) + "/" + Math.Round(agent.HealthLimit);
            }

            return "";
        }

        private string PlayerShieldDisplay()
        {
            if (Mission.Current.MainAgent.WieldedOffhandWeapon.IsShield())
            {
                float hitpoints = (float)Mission.Current.MainAgent.WieldedOffhandWeapon.HitPoints;
                float maxHitpoints = (float)Mission.Current.MainAgent.WieldedOffhandWeapon.ModifiedMaxHitPoints;

                return Math.Round(hitpoints) + "/" + Math.Round(maxHitpoints);
            }
            else
            {
                return "";
            }
        }
        

        private string GetMountHealthDisplay(Agent mountAgent)
        {
            if (mountAgent != null)
            {
                return Math.Round(mountAgent.Health) + "/" + Math.Round(mountAgent.HealthLimit);
            }

            return "";
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