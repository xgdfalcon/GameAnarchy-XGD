using System;
using ICities;
using ColossalFramework;
using CitiesHarmony.API;
using System.Threading;
using System.Xml;
using System.IO;
using UnityEngine;
using ColossalFramework.Globalization;
using ColossalFramework.UI;
using System.Diagnostics;
using ColossalFramework.Plugins;


namespace GameAnarchy {
    public class GAMod : ILoadingExtension, IUserMod {
        private const string m_modName = @"Game Anarchy";
        private const string m_modDesc = @"Extends game's functions";
        internal const string m_modVersion = @"0.7.5";
        internal const string m_AssemblyVersion = m_modVersion + @".*";
        private const string m_debugLogFile = @"01GameAnarchyDebug.log";
        internal const string KeybindingConfigFile = @"GameAnarchyKeyBindSetting";
        internal static bool IsInGame = false;
        public static string ModName => m_modName;
        public static string ModVersion => m_modVersion;

        private static bool enabledAchievements = true;
        private static bool enabledSkipIntro = false;
        public static bool EnabledAchievements {
            get => enabledAchievements;
            set => enabledAchievements = value;
        }
        public static bool EnabledSkipIntro {
            get => enabledSkipIntro;
            set => enabledSkipIntro = value;
        }
        private static bool enabledUnlimitedUniqueBuildings = true;
        public static bool EnabledUnlimitedUniqueBuildings {
            get => enabledUnlimitedUniqueBuildings;
            set => enabledUnlimitedUniqueBuildings = value;
        }

        #region UnlockAll
        private static bool isUnlockAll = true;
        private static int unlockMilestonesLevels = 13;
        public static bool IsUnlockAll {
            get => isUnlockAll;
            set => isUnlockAll = value;
        }
        public static int UnLockMilestonesLevels {
            get => unlockMilestonesLevels;
            set => unlockMilestonesLevels = value;
        }
        #endregion

        #region Resource
        private static bool enabledAutoMoney = true;
        internal static int defaultMinAmount = 50000;
        internal static int defaultGetCash = 5000000;


        private static bool unlimitedOil = true;
        private static bool unlimitedOre = true;

        public static bool UnlimitedOil {
            get => unlimitedOil;
            set => unlimitedOil = value;
        }
        internal static bool UnlimitedOre {
            get => unlimitedOre;
            set => unlimitedOre = value;
        }



        private static bool refund = false;
        private static bool addCashManually = true;
        public static bool EnabledAutoMoney {
            get => enabledAutoMoney;
            set => enabledAutoMoney = value;
        }
        public static bool AddCashManually {
            get {
                if (EnabledAutoMoney) return addCashManually;
                return false;
            }
        }
        public static int DefaultMinAmount {
            get => defaultMinAmount;
            set => defaultMinAmount = value;
        }
        public static int DefaultGetCash {
            get => defaultGetCash;
            set => defaultGetCash = value;
        }
        public static bool Refund {
            get => refund;
            set => refund = value;
        }
        
        #endregion

        #region CityService
        private static bool removeNoisePollution = false;
        private static bool removeGroundPollution = false;
        private static bool removeWaterPollution = false;
        private static bool removeDeath = false;
        private static bool removeGarbage = false;
        private static bool removeCrime = false;
        private static bool removeFire = false;
        private static bool maximizeAttractiveness = false;
        private static bool maximizeEntertainment = false;
        private static bool maximizeLandValue = false;
        private static bool maximizeEducationCoverage = false;
        public static bool RemoveNoisePollution {
            get => removeNoisePollution;
            set => removeNoisePollution = value;
        }
        public static bool RemoveGroundPollution {
            get => removeGroundPollution;
            set => removeGroundPollution = value;
        }
        public static bool RemoveWaterPollution {
            get => removeWaterPollution;
            set {
                if (removeWaterPollution != value) {
                    removeWaterPollution = value;
                }
            }
        }
        public static bool RemoveDeath {
            get => removeDeath;
            set => removeDeath = value;
        }
        public static bool RemoveGarbage {
            get => removeGarbage;
            set => removeGarbage = value;
        }
        public static bool RemoveCrime {
            get => removeCrime;
            set => removeCrime = value;
        }
        public static bool RemoveFire {
            get => removeFire;
            set => removeFire = value;
        }
        public static bool MaximizeAttractiveness {
            get => maximizeAttractiveness;
            set => maximizeAttractiveness = value;
        }
        public static bool MaximizeEntertainment {
            get => maximizeEntertainment;
            set => maximizeEntertainment = value;
        }
        public static bool MaximizeLandValue {
            get => maximizeLandValue;
            set => maximizeLandValue = value;
        }
        public static bool MaximizeEducationCoverage {
            get => maximizeEducationCoverage;
            set => maximizeEducationCoverage = value;
        }
        #endregion

        #region EconomicIncome
        internal static int residentialMultiplierFactor = 1;
        internal static int industrialMultiplierFactor = 1;
        internal static int commercialMultiplierFactor = 1;
        internal static int officeMultiplierFactor = 1;

        public static int ResidenticalMultiplierFactor {
            get => residentialMultiplierFactor;
            set => residentialMultiplierFactor = value;
        }
        public static int IndustrialMultiplierFactor {
            get => industrialMultiplierFactor;
            set => industrialMultiplierFactor = value;
        }
        public static int CommercialMultiplierFactor {
            get => commercialMultiplierFactor;
            set => commercialMultiplierFactor = value;
        }
        public static int OfficeMultiplierFactor {
            get => officeMultiplierFactor;
            set => officeMultiplierFactor = value;
        }
        #endregion

        internal static void Reset() {
            defaultMinAmount = 50000;
            defaultGetCash = 5000000;
            residentialMultiplierFactor = 1;
            industrialMultiplierFactor = 1;
            commercialMultiplierFactor = 1;
            officeMultiplierFactor = 1;
        }

        private GameObject achievementsObject;
        public static bool IsConflict = false;

        #region UserMod
        public string Name => m_modName + ' ' + m_modVersion;
        public string Description => m_modDesc;
        public void OnEnabled() {
            try {
                CreateDebugFile();
            }
            catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            
            GALocale.Init();
            for (int loadTries = 0; loadTries < 5; loadTries++) {
                if (LoadSettings()) break;
            }
            HarmonyHelper.DoOnHarmonyReady(GAPatcher.EnablePatches);
            GameObject returnToDesktop = new GameObject("ReturnToDesktop");
            UnityEngine.Object.DontDestroyOnLoad(returnToDesktop);
            
             
        }
        public void OnDisabled() {
            SaveSettings();
            if (HarmonyHelper.IsHarmonyInstalled) GAPatcher.DisablePatches();
        }
        public void OnSettingsUI(UIHelperBase helper) {
            try {
                if (GameSettings.FindSettingsFileByName(KeybindingConfigFile) is null) {
                    GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = KeybindingConfigFile }
                    });
                }
            }
            catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            GALocale.OnLocaleChanged();
            LocaleManager.eventLocaleChanged += GALocale.OnLocaleChanged;
            GAOptionPanel.SetupPanel((helper.AddGroup(m_modName + @" -- Version " + m_modVersion) as UIHelper).self as UIPanel);
            if (GACompatibilityCheck.CheckIncompatibleMods()) {
                IsConflict = true;
            }
            if (IsConflict) {
                MessageBox.Show<CompatibilityMessageBox>();
            }
        }

        #endregion

        #region LoadingExtension

        //private GameObject clockObject;
        public void OnCreated(ILoading loading) {
            OutputPluginsList();

        }

        public void OnReleased() {
        }
        public void OnLevelLoaded(LoadMode mode) {
            #region Achievements
            try {
                achievementsObject = new GameObject(@"AchievementManager");
                achievementsObject.AddComponent<Patches.AchievementManager>();
            }
            catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }

            #endregion
            //clockObject = new GameObject("GameInClock");
            //clockObject.AddComponent<Patches.GameInClockPatch>().parent = this;

        }

        public void OnLevelUnloading() {
            #region Achievements
            if (achievementsObject != null) {
                try {
                    UnityEngine.Object.Destroy(achievementsObject);
                }
                catch (Exception e) {
                    UnityEngine.Debug.LogException(e);
                }
            }

            #endregion
            //if (clockObject != null) { 
            //    UnityEngine.Object.Destroy(clockObject);
            //    clockObject = null;
            //}

        }
        #endregion

        private const string SettingsFileName = @"GameAnarchyConfig.xml";
        internal static bool LoadSettings() {
            try {
                if (!File.Exists(SettingsFileName)) {
                    SaveSettings();
                }
                XmlDocument xmlConfig = new XmlDocument {
                    XmlResolver = null
                };
                xmlConfig.Load(SettingsFileName);
                enabledAchievements = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"Achievement"));
                isUnlockAll = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"IsUnlockAll"));
                enabledUnlimitedUniqueBuildings = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"EnabledUnlimitedUniqueBuildings"));
                unlockMilestonesLevels = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockMilestonesLevels"), System.Globalization.NumberStyles.Float);
                enabledSkipIntro = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"SkipIntro"));
                removeNoisePollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveNoisePollution"));
                removeGroundPollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveGroundPollution"));
                removeWaterPollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveWaterPollution"));
                removeDeath = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveDeath"));
                removeCrime = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveCrime"));
                removeGarbage = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveGarbage"));
                removeFire = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveFire"));
                maximizeAttractiveness = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"MaximizeAttractiveness"));
                maximizeEntertainment = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"MaximizeEntertainment"));
                maximizeLandValue = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"MaximizeLandValue"));
                maximizeEducationCoverage = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"MaximizeEducationCoverage"));
                unlimitedOil = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlimitedOil"));
                unlimitedOre = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlimitedOre"));
                enabledAutoMoney = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"AutoMoney"));
                refund = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"Refund"));
                defaultMinAmount = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"DefaultMinAmount"), System.Globalization.NumberStyles.Float);
                defaultGetCash = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"DefaultGetCash"), System.Globalization.NumberStyles.Float);
                residentialMultiplierFactor = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"ResidentialMultiplierFactor"), System.Globalization.NumberStyles.Float);
                industrialMultiplierFactor = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"IndustrialMultiplierFactor"), System.Globalization.NumberStyles.Float);
                commercialMultiplierFactor = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"CommercialMultiplierFactor"), System.Globalization.NumberStyles.Float);
                officeMultiplierFactor = int.Parse(xmlConfig.DocumentElement.GetAttribute(@"OfficeMultiplierFactor"), System.Globalization.NumberStyles.Float);

            }
            catch (Exception e) {
                UnityEngine.Debug.LogException(e);
                SaveSettings();
                return false;
            }
            return true;
        }

        private static readonly object settingsLock = new object();
        internal static void SaveSettings(object _ = null) {
            Monitor.Enter(settingsLock);
            try {
                XmlDocument xmlConfig = new XmlDocument {
                    XmlResolver = null
                };
                XmlElement root = xmlConfig.CreateElement(@"GameAnarchyConfig");
                root.Attributes.Append(AddElement(xmlConfig, @"Achievement", enabledAchievements));
                root.Attributes.Append(AddElement(xmlConfig, @"IsUnlockAll", isUnlockAll));
                root.Attributes.Append(AddElement(xmlConfig, @"EnabledUnlimitedUniqueBuildings", enabledUnlimitedUniqueBuildings));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockMilestonesLevels", unlockMilestonesLevels));
                root.Attributes.Append(AddElement(xmlConfig, @"SkipIntro", enabledSkipIntro));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveNoisePollution", removeNoisePollution));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveGroundPollution", removeGroundPollution));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveWaterPollution", removeWaterPollution));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveDeath", removeDeath));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveGarbage", removeGarbage));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveCrime", removeCrime));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveFire", removeFire));
                root.Attributes.Append(AddElement(xmlConfig, @"MaximizeAttractiveness", maximizeAttractiveness));
                root.Attributes.Append(AddElement(xmlConfig, @"MaximizeEntertainment", maximizeEntertainment));
                root.Attributes.Append(AddElement(xmlConfig, @"MaximizeLandValue", maximizeLandValue));
                root.Attributes.Append(AddElement(xmlConfig, @"MaximizeEducationCoverage", maximizeEducationCoverage));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlimitedOil", unlimitedOil));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlimitedOre", unlimitedOre));
                root.Attributes.Append(AddElement(xmlConfig, @"AutoMoney", enabledAutoMoney));
                root.Attributes.Append(AddElement(xmlConfig, @"Refund", refund));
                root.Attributes.Append(AddElement(xmlConfig, @"DefaultMinAmount", defaultMinAmount));
                root.Attributes.Append(AddElement(xmlConfig, @"DefaultGetCash", defaultGetCash));
                root.Attributes.Append(AddElement(xmlConfig, @"ResidentialMultiplierFactor", residentialMultiplierFactor));
                root.Attributes.Append(AddElement(xmlConfig, @"IndustrialMultiplierFactor", industrialMultiplierFactor));
                root.Attributes.Append(AddElement(xmlConfig, @"CommercialMultiplierFactor", commercialMultiplierFactor));
                root.Attributes.Append(AddElement(xmlConfig, @"OfficeMultiplierFactor", officeMultiplierFactor));
                xmlConfig.AppendChild(root);
                xmlConfig.Save(SettingsFileName);
            }
            finally {
                Monitor.Exit(settingsLock);
            }
        }

        internal static XmlAttribute AddElement<T>(XmlDocument doc, string name, T t) {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = t.ToString();
            return attr;
        }

        private static readonly Stopwatch profiler = new Stopwatch();
        private static readonly object fileLock = new object();
        private void CreateDebugFile() {
            profiler.Start();
            string path = Path.Combine(Application.dataPath, m_debugLogFile);
            using (FileStream debugFile = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            using (StreamWriter sw = new StreamWriter(debugFile)) {
                sw.WriteLine(@"--- " + m_modName + ' ' + m_modVersion + @" Debug File ---");
                sw.WriteLine(Environment.OSVersion);
                sw.WriteLine(@"C# CLR Version " + Environment.Version);
                sw.WriteLine(@"Unity Version " + Application.unityVersion);
                sw.WriteLine(@"-------------------------------------");
            }
        }

        private void OutputPluginsList() {
            Monitor.Enter(fileLock);
            try {
                using (FileStream debugFile = new FileStream(Path.Combine(Application.dataPath, m_debugLogFile), FileMode.Append, FileAccess.Write, FileShare.None))
                using (StreamWriter sw = new StreamWriter(debugFile)) {
                    sw.WriteLine(@"Mods Installed are:");
                    foreach (PluginManager.PluginInfo info in Singleton<PluginManager>.instance.GetPluginsInfo()) {
                        if (!(info is null) && info.userModInstance is IUserMod modInstance)
                            sw.WriteLine(@"=> " + info.name + '-' + modInstance.Name + ' ' + (info.isEnabled ? @"** Enabled **" : @"** Disabled **"));
                    }
                    sw.WriteLine(@"-------------------------------------");
                }
            }
            finally {
                Monitor.Exit(fileLock);
            }
        }

        internal static void GALog(string msg) {
            var ticks = profiler.ElapsedTicks;
            Monitor.Enter(fileLock);
            try {
                using (FileStream debugFile = new FileStream(Path.Combine(Application.dataPath, m_debugLogFile), FileMode.Append))
                using (StreamWriter sw = new StreamWriter(debugFile)) {
                    sw.WriteLine($"{(ticks / Stopwatch.Frequency):n0}:{(ticks % Stopwatch.Frequency):D7}-{new StackFrame(1, true).GetMethod().Name} ==> {msg}");
                }
            }
            finally {
                Monitor.Exit(fileLock);
            }
        }
    }
}
