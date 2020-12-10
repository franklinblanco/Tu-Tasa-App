﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TuTasa.Scripts
{
    class CacheManager
    {

        #region singleton pattern
        private static CacheManager instance = null;
        public static CacheManager Instance { get { if (instance == null) { instance = new CacheManager(); } return instance; } } //Singleton pattern
        #endregion

        Dictionary<string, Rate> currencies = new Dictionary<string, Rate>();

        public Rate[] GetCurrencies()
        {
            if (currencies.Count > 0) { return currencies.Values.ToArray(); }
            string wholeinfo = ConnectionManager.Instance.AskForHomePage();
            string[] rates = wholeinfo.Split('/');
            for (int x = 0; x < rates.Length; x++)
            {
                string[] rate = rates[x].Split('-');
                if (rate.Length < 4) { return null; }
                currencies.Add(rate[0], new Rate() { bankname = rate[0], currency = rate[1], buyrate = rate[2], sellrate = rate[3]});
            }
            return currencies.Values.ToArray();
        }
        public void SortBy(string what)
        {

        }
    }
}
