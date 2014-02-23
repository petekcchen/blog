using Castle.DynamicProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace AOPCaching
{
    [TestClass]
    public class CastleDynamicProxyAOPTests
    {
        [TestMethod]
        public void Cache_Without_AOP()
        {
            IRepository repository = new CachedRepository();

            Debug.WriteLine("First run...");
            IList<string> languages = repository.GetLanguages();
            Assert.AreEqual<string>("English", languages[0]);
            Assert.AreEqual<string>("Japanese", languages[1]);
            Assert.AreEqual<string>("Simplified Chinese", languages[2]);
            Assert.AreEqual<string>("Traditional Chinese", languages[3]);

            Debug.WriteLine("Second run...");
            IList<string> cachedLanguages = repository.GetLanguages();
            Assert.AreEqual<string>("English", cachedLanguages[0]);
            Assert.AreEqual<string>("Japanese", cachedLanguages[1]);
            Assert.AreEqual<string>("Simplified Chinese", cachedLanguages[2]);
            Assert.AreEqual<string>("Traditional Chinese", cachedLanguages[3]);
        }

        [TestMethod]
        public void Cache_With_AOP()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            IRepository repository = new Repository();
            IRepository repositoryProxy = proxyGenerator.CreateInterfaceProxyWithTargetInterface<IRepository>(repository, new CacheInterceptor());

            Debug.WriteLine("First run...");
            IList<string> languages = repositoryProxy.GetLanguages();
            Assert.AreEqual<string>("English", languages[0]);
            Assert.AreEqual<string>("Japanese", languages[1]);
            Assert.AreEqual<string>("Simplified Chinese", languages[2]);
            Assert.AreEqual<string>("Traditional Chinese", languages[3]);

            Debug.WriteLine("Second run...");
            IList<string> cachedLanguages = repositoryProxy.GetLanguages();
            Assert.AreEqual<string>("English", cachedLanguages[0]);
            Assert.AreEqual<string>("Japanese", cachedLanguages[1]);
            Assert.AreEqual<string>("Simplified Chinese", cachedLanguages[2]);
            Assert.AreEqual<string>("Traditional Chinese", cachedLanguages[3]);

            Debug.WriteLine("First run...");
            IList<Setting> settings = repositoryProxy.GetSettings();
            Assert.AreEqual<string>("Domain", settings[0].Name);
            Assert.AreEqual<string>("dev.pete.tw", settings[0].Value);
            Assert.AreEqual<string>("Administrator", settings[1].Name);
            Assert.AreEqual<string>("Pete", settings[1].Value);

            Debug.WriteLine("Second run...");
            IList<Setting> cachedSettings = repositoryProxy.GetSettings();
            Assert.AreEqual<string>("Domain", cachedSettings[0].Name);
            Assert.AreEqual<string>("dev.pete.tw", cachedSettings[0].Value);
            Assert.AreEqual<string>("Administrator", cachedSettings[1].Name);
            Assert.AreEqual<string>("Pete", cachedSettings[1].Value);
        }
    }
}