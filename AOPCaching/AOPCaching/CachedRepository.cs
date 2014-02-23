using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Caching;

namespace AOPCaching
{
    public class CachedRepository : IRepository
    {
        IList<string> IRepository.GetLanguages()
        {
            Debug.WriteLine("Enter IRepository.GetLanguages()...");

            ObjectCache cache = MemoryCache.Default;
            IList<string> item = cache.Get("GetLanguages") as IList<string>;

            if (item == null)
            {
                Debug.WriteLine("Cache key GetLanguages does not exists");

                IList<string> languages = Database.GetLanguages();
                cache.Set("GetLanguages", languages, new CacheItemPolicy());
                return languages;
            }

            Debug.WriteLine("Cache key GetLanguages exists");
            return item;
        }

        IList<Setting> IRepository.GetSettings()
        {
            Debug.WriteLine("Enter IRepository.GetSettings()...");

            ObjectCache cache = MemoryCache.Default;
            IList<Setting> item = cache.Get("GetSettings") as IList<Setting>;

            if (item == null)
            {
                Debug.WriteLine("Cache key GetSettings does not exists");

                IList<Setting> settings = Database.GetSettings();
                cache.Set("GetSettings", settings, new CacheItemPolicy());
                return settings;
            }

            Debug.WriteLine("Cache key GetSettings exists");
            return item;
        }
    }
}