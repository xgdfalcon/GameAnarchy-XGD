using System;
using ICities;
using ColossalFramework;
using HarmonyLib;
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
        private const string m_modDesc = @"Unlock Game Limitation";
        internal const string m_modVersion = @"0.0.1";
        internal const string m_AssemblyVersion = m_modVersion + @".*";
        private const string m_debugLogFile = @"01GameAnarchyDebug.log";
        internal const string KeybindingConfigFile = @"GameAnarchyKeyBindSetting";
        internal static bool IsInGame = false;

        private static bool enabledUnlockDeluxeLandmarks = false;
        private static bool enabledUnlockUniqueBuildings = false;
        private static bool enabledUnlockWonders = false;
        private static bool enabledUnlockEuropeanLandmarks = false;
        private static bool enabledUnlockAfterDarkLandmarks = false;
        private static bool enabledUnlockSnaowfallLandmarks = false;
        private static bool enabledUnlockNaturalDisastersLandmarks = false;
        private static bool enabledUnlockMassTransitLandmarks = false;
        private static bool enabledUnlockGreenCitiesLandmarks = false;
        private static bool enabledUnlockConcertsLandmarks = false;
        private static bool enabledUnlockParklifeLandmarks = false;
        private static bool enabledUnlockIndustriesLandmarks = false;
        private static bool enabledUnlockCampusLandmarks = false;
        private static bool enabledUnlockSunsetHarborLandmarks = false;
        private static bool enabledUnlockAirportsLandmarks = false;

        private static bool enabledAchievements = true;
        private static bool enabledAutoMoney = true;
        private static bool enabledSkipIntro = false;
        private static readonly int defaultMinAmount = 50000;
        private static readonly int defaultGetCash = 10000000;
        private static float oilCapacity = 100;
        private static float oreCapacity = 100;

        private static bool removeNoisePollution = false;
        private static bool removeGroundPollution = false;
        private static bool removeWaterPollution = false;

        private static bool addCashManually = true;

        public static bool AddCashManually {
            get {
                if(EnabledAutoMoney) return addCashManually;
                return false;
            }
        }

        public static bool EnabledUnlockDeluxeLandmarks {
            get => enabledUnlockDeluxeLandmarks;
            set => enabledUnlockDeluxeLandmarks = value;
        }
        public static bool EnabledUnlockUniqueBuildings { 
            get => enabledUnlockUniqueBuildings;
            set => enabledUnlockUniqueBuildings = value;
        }
        public static bool EnabledUnlockWonders {
            get => enabledUnlockWonders;
            set => enabledUnlockWonders = value;
        }
        public static bool EnabledUnlockEuropeanLandmarks {
            get => enabledUnlockEuropeanLandmarks;
            set => enabledUnlockEuropeanLandmarks = value;
        }
        public static bool EnabledUnlockAfterDarkLandmarks {
            get => enabledUnlockAfterDarkLandmarks;
            set => enabledUnlockAfterDarkLandmarks = value;
        }
        public static bool EnabledUnlockSnaowfallLandmarks {
            get => enabledUnlockSnaowfallLandmarks;
            set => enabledUnlockSnaowfallLandmarks = value;
        }
        public static bool EnabledUnlockNaturalDisastersLandmarks {
            get => enabledUnlockNaturalDisastersLandmarks;
            set => enabledUnlockNaturalDisastersLandmarks = value;
        }
        public static bool EnabledUnlockMassTransitLandmarks {
            get => enabledUnlockMassTransitLandmarks;
            set => enabledUnlockMassTransitLandmarks = value;
        }
        public static bool EnabledUnlockGreenCitiesLandmarks {
            get => enabledUnlockGreenCitiesLandmarks;
            set => enabledUnlockGreenCitiesLandmarks = value;
        }
        public static bool EnabledUnlockConcertsLandmarks {
            get => enabledUnlockConcertsLandmarks;
            set => enabledUnlockConcertsLandmarks = value;
        }
        public static bool EnabledUnlockParklifeLandmarks {
            get => enabledUnlockParklifeLandmarks;
            set => enabledUnlockParklifeLandmarks = value;
        }
        public static bool EnabledUnlockIndustriesLandmarks {
            get => enabledUnlockIndustriesLandmarks;
            set => enabledUnlockIndustriesLandmarks = value;
        }
        public static bool EnabledUnlockCampusLandmarks {
            get => enabledUnlockCampusLandmarks;
            set => enabledUnlockCampusLandmarks = value;
        }
        public static bool EnabledUnlockSunsetHarborLandmarks {
            get => enabledUnlockSunsetHarborLandmarks;
            set => enabledUnlockSunsetHarborLandmarks = value;
        }
        public static bool EnabledUnlockAirportsLandmarks {
            get => enabledUnlockAirportsLandmarks;
            set => enabledUnlockAirportsLandmarks = value;
        }

        


        public static bool EnabledAchievements {
            get => enabledAchievements;
            set => enabledAchievements = value;
        }
        public static bool EnabledAutoMoney {
            get => enabledAutoMoney;
            set => enabledAutoMoney = value;
        }
        public static bool EnabledSkipIntro {
            get => enabledSkipIntro;
            set => enabledSkipIntro = value;
        }

        public static float OilCapacity {
            get => oilCapacity;
            set {
                if (oilCapacity != value) {
                    oilCapacity = value;
                    ThreadPool.QueueUserWorkItem(SaveSettings);
                }
            }
        }

        public static float OreCapacity {
            get => oreCapacity;
            set {
                if (oreCapacity != value) {
                    oreCapacity = value;
                    ThreadPool.QueueUserWorkItem(SaveSettings);
                }
            }
        }

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
                    ThreadPool.QueueUserWorkItem(SaveSettings);
                }
            }
        }

        public static int DefaultMinAmount => defaultMinAmount;

        public static int DefaultGetCash => defaultGetCash;
            
        public static Rect ButtonRect { get; set; } = new Rect(0, 0, 120, 30);

        private GameObject achievementsObject;


        #region UserMod
        public string Name => m_modName + ' ' + m_modVersion;
        public string Description => m_modDesc;
        public void OnEnabled() {
            try {
                CreateDebugFile();
            } catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            try {
                if (GameSettings.FindSettingsFileByName(KeybindingConfigFile) is null) {
                    GameSettings.AddSettingsFile(new SettingsFile[] {
                        new SettingsFile() { fileName = KeybindingConfigFile }
                    });
                }
            } catch (Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            GALocale.Init();
            for (int loadTries = 0; loadTries < 5; loadTries++) {
                if (LoadSettings()) break; 
            }
            HarmonyHelper.DoOnHarmonyReady(GAPatcher.EnablePatches);
            GameObject returnToDesktop = new GameObject("ReturnToDesktop");
            UnityEngine.Object.DontDestroyOnLoad(returnToDesktop);
            CompatibilityCheck.CheckIncompatibleMods();

        }
        public void OnDisabled() {
            SaveSettings();
            if (HarmonyHelper.IsHarmonyInstalled) GAPatcher.DisablePatches();
        }
        public void OnSettingsUI(UIHelperBase helper) {
            GALocale.OnLocaleChanged();
            LocaleManager.eventLocaleChanged += GALocale.OnLocaleChanged;
            GAOptionPanel.SetupPanel((helper.AddGroup(m_modName + @" -- Version " + m_modVersion) as UIHelper).self as UIPanel);
        }

        #endregion

        #region LoadingExtension
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
            } catch(Exception e) {
                UnityEngine.Debug.LogException(e);
            }
            #endregion
        }

        public void OnLevelUnloading() { 
            #region Achievements
            if (achievementsObject != null) { 
                try {
                UnityEngine.Object.Destroy(achievementsObject);
            } catch(Exception e) {
                UnityEngine.Debug.LogException(e);
                }
            }
            
            #endregion
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
                enabledAutoMoney = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"AutoMoney"));
                enabledSkipIntro = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"SkipIntro"));

                enabledUnlockDeluxeLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockDeluxeLandmarks"));
                enabledUnlockUniqueBuildings = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockUniqueBuildings"));
                enabledUnlockWonders = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockWonders"));
                enabledUnlockEuropeanLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockEuropeanLandmarks"));
                enabledUnlockAfterDarkLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockAfterDarkLandmarks"));
                enabledUnlockSnaowfallLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockSnaowfallLandmarks"));
                enabledUnlockNaturalDisastersLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockNaturalDisastersLandmarks"));
                enabledUnlockMassTransitLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockMassTransitLandmarks"));
                enabledUnlockGreenCitiesLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockGreenCitiesLandmarks"));
                enabledUnlockConcertsLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockConcertsLandmarks"));
                enabledUnlockParklifeLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockParklifeLandmarks"));
                enabledUnlockIndustriesLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockIndustriesLandmarks"));
                enabledUnlockCampusLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockCampusLandmarks"));
                enabledUnlockSunsetHarborLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockSunsetHarborLandmarks"));
                enabledUnlockAirportsLandmarks = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"UnlockAirportsLandmarks"));

                removeNoisePollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveNoisePollution"));
                removeGroundPollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveGroundPollution"));
                removeWaterPollution = bool.Parse(xmlConfig.DocumentElement.GetAttribute(@"RemoveWaterPollution"));
                oilCapacity = float.Parse(xmlConfig.DocumentElement.GetAttribute(@"OilCapacity"), System.Globalization.NumberStyles.Float);
                oreCapacity = float.Parse(xmlConfig.DocumentElement.GetAttribute(@"OreCapacity"), System.Globalization.NumberStyles.Float);

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
                root.Attributes.Append(AddElement(xmlConfig, @"AutoMoney", enabledAutoMoney));
                root.Attributes.Append(AddElement(xmlConfig, @"SkipIntro", enabledSkipIntro));

                root.Attributes.Append(AddElement(xmlConfig, @"UnlockDeluxeLandmarks", enabledUnlockDeluxeLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockUniqueBuildings", enabledUnlockUniqueBuildings));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockWonders", enabledUnlockWonders));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockEuropeanLandmarks", enabledUnlockEuropeanLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockAfterDarkLandmarks", enabledUnlockAfterDarkLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockSnaowfallLandmarks", enabledUnlockSnaowfallLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockNaturalDisastersLandmarks", enabledUnlockNaturalDisastersLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockMassTransitLandmarks", enabledUnlockMassTransitLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockGreenCitiesLandmarks", enabledUnlockGreenCitiesLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockConcertsLandmarks", enabledUnlockConcertsLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockParklifeLandmarks", enabledUnlockParklifeLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockIndustriesLandmarks", enabledUnlockIndustriesLandmarks)); 
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockCampusLandmarks", enabledUnlockCampusLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockSunsetHarborLandmarks", enabledUnlockSunsetHarborLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"UnlockAirportsLandmarks", enabledUnlockAirportsLandmarks));
                root.Attributes.Append(AddElement(xmlConfig, @"SkipIntro", enabledSkipIntro));

                root.Attributes.Append(AddElement(xmlConfig, @"RemoveNoisePollution", removeNoisePollution));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveGroundPollution", removeGroundPollution));
                root.Attributes.Append(AddElement(xmlConfig, @"RemoveWaterPollution", removeWaterPollution));
                root.Attributes.Append(AddElement(xmlConfig, @"OilCapacity", oilCapacity));
                root.Attributes.Append(AddElement(xmlConfig, @"OreCapacity", oreCapacity));


                xmlConfig.AppendChild(root);
                xmlConfig.Save(SettingsFileName);
            } finally {
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
            } finally {
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
            } finally {
                Monitor.Exit(fileLock);
            }
        }
    }
}
