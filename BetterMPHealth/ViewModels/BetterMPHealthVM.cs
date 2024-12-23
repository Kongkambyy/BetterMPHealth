// HealthHUDVM.cs
using TaleWorlds.Library;

namespace BetterMPHealth {
    public class BetterMPHealthVM : ViewModel {
        private string _playerHealth = "";
        private string _mountHealth = "";
        private string _shieldHealth = "";

        [DataSourceProperty]
        public string PlayerHealth {
            get => _playerHealth;
            set {
                _playerHealth = value;
                OnPropertyChangedWithValue(value);
            }
        }

        [DataSourceProperty]
        public string MountHealth {
            get => _mountHealth;
            set {
                _mountHealth = value;
                OnPropertyChangedWithValue(value);
            }
        }

        [DataSourceProperty]
        public string ShieldHealth {
            get => _shieldHealth;
            set {
                _shieldHealth = value;
                OnPropertyChangedWithValue(value);
            }
        }
    }
}