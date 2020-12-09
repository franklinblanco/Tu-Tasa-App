using System;
using System.Collections.Generic;
using System.Text;

namespace TuTasa.Scripts
{
    class CacheManager
    {

        #region singleton pattern
        private static CacheManager instance = null;
        public static CacheManager Instance { get { if (instance == null) { instance = new CacheManager(); } return instance; } } //Singleton pattern
        #endregion

        Dictionary<string, CurrencyRate> currencies = new Dictionary<string, CurrencyRate>();

        public void GetCurrencies()
        {

        }
    }
}
