using System;
using ColossalFramework;
using ICities;

namespace GameAnarchy.Patches {
    public class AutoMoneyPatch : EconomyExtensionBase {
        public override long OnUpdateMoneyAmount(long internalMoneyAmount) {
            try {
                if (GAMod.EnabledAutoMoney && internalMoneyAmount >= GAMod.DefaultMinAmount * 100) return internalMoneyAmount;
                managers.threading.QueueMainThread(() => AddCash(true, GAMod.DefaultGetCash, () => managers.economy.internalMoneyAmount));
            } catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            return internalMoneyAmount;
        }

        public static void AddCash(bool addCash, int amount, Func<long> getCurrentMoney = null) {
            try {
                if (Singleton<EconomyManager>.exists) {
                    EconomyManager economyMgr = Singleton<EconomyManager>.instance;
                    getCurrentMoney = getCurrentMoney ?? (() => economyMgr.LastCashAmount);
                    if (addCash && getCurrentMoney() >= GAMod.DefaultMinAmount * 100) return;
                    economyMgr.AddResource(EconomyManager.Resource.LoanAmount, amount * 100, ItemClass.Service.None, ItemClass.SubService.None, ItemClass.Level.None);
                }
            }
            catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
        }

        
        public static void AddCashManually(bool isAdd) {
            if (isAdd) {
                if(Singleton<EconomyManager>.exists)
                    Singleton<EconomyManager>.instance.AddResource(EconomyManager.Resource.LoanAmount, GAMod.DefaultGetCash * 100, ItemClass.Service.None, ItemClass.SubService.None, ItemClass.Level.None);
                };
        }
            
    }


} 
    


