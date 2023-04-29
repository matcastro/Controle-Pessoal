using Personal.Control.Utils.Configs;

namespace Personal.Control.Utils.Helpers
{
    public static class ConfigurationHelper
    {
        public static Config Config { get; private set; } = new();
        public static void Initialize(Config options)
        {
            Config = options;
        }

    }
}
