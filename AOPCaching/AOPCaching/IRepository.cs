using System.Collections.Generic;

namespace AOPCaching
{
    public interface IRepository
    {
        IList<string> GetLanguages();

        IList<Setting> GetSettings();
    }
}