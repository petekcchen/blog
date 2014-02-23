using System.Collections.Generic;

namespace AOPCaching
{
    public class Database
    {
        public static IList<string> GetLanguages()
        {
            return new List<string> { "English", "Japanese", "Simplified Chinese", "Traditional Chinese" };
        }

        public static IList<Setting> GetSettings()
        {
            return new List<Setting> {
                new Setting() { Name = "Domain", Value = "dev.pete.tw" },
                new Setting() { Name = "Administrator", Value = "Pete" }
            };
        }
    }
}