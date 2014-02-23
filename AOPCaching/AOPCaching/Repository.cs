using System.Collections.Generic;
using System.Diagnostics;

namespace AOPCaching
{
    public class Repository : IRepository
    {
        IList<string> IRepository.GetLanguages()
        {
            Debug.WriteLine("Enter IRepository.GetLanguages()...");
            return Database.GetLanguages();
        }

        IList<Setting> IRepository.GetSettings()
        {
            Debug.WriteLine("Enter IRepository.GetSettings()...");
            return Database.GetSettings();
        }
    }
}