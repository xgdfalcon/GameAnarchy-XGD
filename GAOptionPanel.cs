using UnityEngine;
using ColossalFramework.UI;
using static GameAnarchy.GAMod;
using System.Threading;
using static GameAnarchy.UI.UICustom;
using GameAnarchy.UI;

namespace GameAnarchy {
    internal static class GAOptionPanel {
        internal const float TabFontScale = 1.1f;
        internal const float DefaultFontScale = 0.95f;
        internal const float SmallFontScale = 0.85f;
        private static readonly Color32 m_greyColor = new Color32(0xe6, 0xe6, 0xe6, 0xee);
        private static readonly Color32 m_greenColor = new Color32(0xcf, 0xf9, 0x8f, 0xff);
        private static readonly Color32 m_orangeColor = new Color32(0xfe, 0xd8, 0x8b, 0xff);
        private static readonly Color32 m_redColor = Color.red;
        private static UICheckBox m_achievementsCB;
        private static UICheckBox m_autoMoneyCB;
        private static UICheckBox m_refundCB;
        private static UICheckBox m_skipIntroCB;
        private static UICheckBox m_unlimitedUniqueBuildingsCB;
        private static UICheckBox m_unlockAllCB;
        private static UICheckBox m_removeNoisePollutionCB;
        private static UICheckBox m_removeGroundPollutionCB;
        private static UICheckBox m_removeWaterPollutionCB;
        private static UICheckBox m_removeDeathCB;
        private static UICheckBox m_removeGarbageCB;
        private static UICheckBox m_removeCrimeCB;
        private static UICheckBox m_removeFireCB;
        private static UICheckBox m_maximizeAttractivenessCB;
        private static UICheckBox m_maximizeEntertainmentCB;
        private static UICheckBox m_maximizeLandValueCB;
        private static UICheckBox m_maximizeEducationCoverageCB;
        private const float OFFSETX = 5f;

        internal static void SetupPanel(UIPanel root) {
            UITabstrip tabBar = root.AddUIComponent<UITabstrip>();
            UITabContainer tabContainer = root.AddUIComponent<UITabContainer>();
            tabBar.tabPages = tabContainer;
            tabContainer.size = new Vector2(root.width, 650f);

            UIPanel GeneralOptionsPanel = AddTab(tabBar, GALocale.GetLocale(@"GeneralOptionsTab"), 0, true);
            GeneralOptionsPanel.autoLayout = false;
            GeneralOptionsPanel.autoSize = false;
            ShowGeneralSettingsPanel(GeneralOptionsPanel);

            UIPanel ResourceOptionsPanel = AddTab(tabBar, GALocale.GetLocale(@"ResourceOptionsTab"), 1, true);
            ResourceOptionsPanel.autoLayout = false;
            ResourceOptionsPanel.autoSize = false;
            ShowResourceOptionsPanel(ResourceOptionsPanel);

            AddTab(tabBar, GALocale.GetLocale(@"KeyboardShortcutTab"), 2, true).gameObject.AddComponent<GAKeyBinding>();

            UIPanel supportPanel = AddTab(tabBar, GALocale.GetLocale(@"SupportOptionTab"), 3, true);
            supportPanel.autoLayout = false;
            supportPanel.autoSize = false;
            ShowSupportOptions(supportPanel);
        }

        private static string EnabledAchievementsLocale => GALocale.GetLocale(@"EnableAchievements");
        private static string EnabledUnlimitedUniqueBuildingsLocale => GALocale.GetLocale(@"EnabledUnlimitedUniqueBuildings");
        private static string EnabledUnlockAllLocale => GALocale.GetLocale(@"UnlockAll");
        private static string EnabledSkipIntroLocale => GALocale.GetLocale(@"EnabledSkipIntro");

        private static string RemoveNoisePollutionLocale => GALocale.GetLocale(@"RemoveNoisePollution");
        private static string RemoveGroundPollutionLocale => GALocale.GetLocale(@"RemoveGroundPollution");
        private static string RemoveWaterPollutionLocale => GALocale.GetLocale(@"RemoveWaterPollution");
        private static string RemoveDeathLocale => GALocale.GetLocale(@"RemoveDeath");
        private static string RemoveGarbageLocale => GALocale.GetLocale(@"RemoveGarbage");
        private static string RemoveCrimeLocale => GALocale.GetLocale(@"RemoveCrime");
        private static string RemoveFireLocale => GALocale.GetLocale(@"RemoveFire");
        private static string MaximizeAttractivenessLocale => GALocale.GetLocale(@"MaximizeAttractiveness");
        private static string MaximizeEntertainmentLocale => GALocale.GetLocale(@"MaximizeEntertainment");
        private static string MaximizeLandValueLocale => GALocale.GetLocale(@"MaximizeLandValue");
        private static string MaximizeEducationCoverageLocale => GALocale.GetLocale(@"MaximizeEducationCoverage");
        private static string EnabledAutoMoneyLocale => GALocale.GetLocale(@"EnabledAutoMoney");
        private static string ConstructionRefundLocale => GALocale.GetLocale(@"ConstructionRefund");



        private static void ShowGeneralSettingsPanel(UIPanel panel) {
            OptionPanelAdvancedAutoLayoutGroupPanel groupA = panel.AddUIComponent<OptionPanelAdvancedAutoLayoutGroupPanel>();
            groupA.relativePosition = new Vector2(0f, 15f);
            m_achievementsCB = AddSettingToggleButton(groupA, EnabledAchievementsLocale, EnabledAchievements);
            m_achievementsCB.eventClicked += (c, p) => {
                EnabledAchievements = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_unlimitedUniqueBuildingsCB = AddSettingToggleButton(groupA, EnabledUnlimitedUniqueBuildingsLocale, EnabledUnlimitedUniqueBuildings);
            m_unlimitedUniqueBuildingsCB.eventClicked += (c, p) => {
                EnabledUnlimitedUniqueBuildings = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_unlockAllCB = AddSettingToggleButton(groupA, EnabledUnlockAllLocale, IsUnlockAll);
            m_unlockAllCB.eventClicked += (c, p) => {
                IsUnlockAll = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_skipIntroCB = AddSettingToggleButton(groupA, EnabledSkipIntroLocale, EnabledSkipIntro);
            m_skipIntroCB.eventClicked += (c, p) => {
                EnabledSkipIntro = (c as UICheckBox).isChecked;
                SaveSettings();
            };


            //UnlockMilestones = AddDropdown(groupA, null, 200f, 28f, 0.95f, UnlockMilestonesDropDownLocale,
            //    UnLockMilestonesLevels - 1, (c, selectIndex) => {
            //        UnLockMilestonesLevels = selectIndex + 1;
            //        SaveSettings();
            //    }, new Vector2(55f, m_unlockAllCB.relativePosition.y + m_unlockAllCB.size.y + 1f), new RectOffset(8, 0, 6, 0), new RectOffset(4, 0, 4, 0));
            //UnlockMilestones.isVisible = IsUnlockAll;

            #region CityServices
            OptionPanelAdvancedAutoLayoutGroupPanel groupB = panel.AddUIComponent<OptionPanelAdvancedAutoLayoutGroupPanel>();
            groupB.relativePosition = new Vector2(0f, groupA.relativePosition.y + groupA.size.y + 10f);
            groupA.eventSizeChanged += (s, e) => {
                groupB.relativePosition = new Vector2(0f, groupA.relativePosition.y + groupA.size.y + 10f);
            };
            m_removeNoisePollutionCB = AddSettingToggleButton(groupB, RemoveNoisePollutionLocale, RemoveNoisePollution);
            m_removeNoisePollutionCB.tooltip = GALocale.GetLocale(@"RemoveNoisePollutionTip");
            m_removeNoisePollutionCB.eventClicked += (c, p) => {
                RemoveNoisePollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeGroundPollutionCB = AddSettingToggleButton(groupB, RemoveGroundPollutionLocale, RemoveGroundPollution);
            m_removeGroundPollutionCB.tooltip = GALocale.GetLocale(@"RemoveGroundPollutionTip");
            m_removeGroundPollutionCB.eventClicked += (c, p) => {
                RemoveGroundPollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeWaterPollutionCB = AddSettingToggleButton(groupB, RemoveWaterPollutionLocale, RemoveWaterPollution);
            m_removeWaterPollutionCB.tooltip = GALocale.GetLocale(@"RemoveWaterPollutionTip");
            m_removeWaterPollutionCB.eventClicked += (c, p) => {
                RemoveWaterPollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeDeathCB = AddSettingToggleButton(groupB, RemoveDeathLocale, RemoveDeath);
            m_removeDeathCB.tooltip = GALocale.GetLocale("RemoveDeathTip");
            m_removeDeathCB.eventClicked += (c, p) => {
                RemoveDeath = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeGarbageCB = AddSettingToggleButton(groupB, RemoveGarbageLocale, RemoveGarbage);
            m_removeGarbageCB.tooltip = GALocale.GetLocale("RemoveGarbageTip");
            m_removeGarbageCB.eventClicked += (c, p) => {
                RemoveGarbage = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeCrimeCB = AddSettingToggleButton(groupB, RemoveCrimeLocale, RemoveCrime);
            m_removeCrimeCB.tooltip = GALocale.GetLocale("RemoveCrimeTip");
            m_removeCrimeCB.eventClicked += (c, p) => {
                RemoveCrime = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_removeFireCB = AddSettingToggleButton(groupB, RemoveFireLocale, RemoveFire);
            m_removeFireCB.tooltip = GALocale.GetLocale("RemoveFireTip");
            m_removeFireCB.eventClicked += (c, p) => {
                RemoveFire = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_maximizeAttractivenessCB = AddSettingToggleButton(groupB, MaximizeAttractivenessLocale, MaximizeAttractiveness);
            m_maximizeAttractivenessCB.tooltip = GALocale.GetLocale(@"MaximizeAttractivenessTip");
            m_maximizeAttractivenessCB.eventClicked += (c, p) => {
                MaximizeAttractiveness = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_maximizeEntertainmentCB = AddSettingToggleButton(groupB, MaximizeEntertainmentLocale, MaximizeEntertainment);
            m_maximizeEntertainmentCB.tooltip = GALocale.GetLocale(@"MaximizeEntertainmentTip");
            m_maximizeEntertainmentCB.eventClicked += (c, p) => {
                MaximizeEntertainment = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_maximizeLandValueCB = AddSettingToggleButton(groupB, MaximizeLandValueLocale, MaximizeLandValue);
            m_maximizeLandValueCB.tooltip = GALocale.GetLocale(@"MaximizeLandValueTip");
            m_maximizeLandValueCB.eventClicked += (c, p) => {
                MaximizeLandValue = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_maximizeEducationCoverageCB = AddSettingToggleButton(groupB, MaximizeEducationCoverageLocale, MaximizeEducationCoverage);
            m_maximizeEducationCoverageCB.tooltip = GALocale.GetLocale(@"MaximizeEducationCoverageTip");
            m_maximizeEducationCoverageCB.eventClicked += (c, p) => {
                MaximizeEducationCoverage = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            #endregion

            OptionPanelAdvancedAutoLayoutGroupPanel groupC = panel.AddUIComponent<OptionPanelAdvancedAutoLayoutGroupPanel>();
            groupC.relativePosition = new Vector2(0f, groupB.relativePosition.y + groupB.size.y + 10f);
            groupB.eventSizeChanged += (c, p) => {
                groupC.relativePosition = new Vector2(0f, groupB.relativePosition.y + groupB.size.y + 10f);
            };
            UILabel fastReturn = AddFunctionDescription(groupC, GALocale.GetLocale(@"FastReturn"), true);
            UILabel sortSettings = AddFunctionDescription(groupC, GALocale.GetLocale(@"SortSettings"), true);


        }


        private static UICheckBox m_unlimitedOilCB;
        public static UICheckBox m_unlimitedOreCB;
        private static UIFancySlider cashThreshold;
        private static UIFancySlider addCashAmount;

        private static string UnlimitedOilLocale => GALocale.GetLocale(@"UnlimitedOil");
        private static string UnlimitedOreLocale => GALocale.GetLocale(@"UnlimitedOre");
        private static void ShowResourceOptionsPanel(UIPanel panel) {
            OptionPanelAdvancedAutoLayoutGroupPanel groupA = panel.AddUIComponent<OptionPanelAdvancedAutoLayoutGroupPanel>();
            groupA.relativePosition = new Vector2(0f, 15f);
            m_unlimitedOilCB = AddSettingToggleButton(groupA, UnlimitedOilLocale, UnlimitedOil);
            m_unlimitedOilCB.eventClicked += (c, p) => {
                UnlimitedOil = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_unlimitedOreCB = AddSettingToggleButton(groupA, UnlimitedOreLocale, UnlimitedOre);
            m_unlimitedOreCB.eventClicked += (c, p) => {
                UnlimitedOre = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_refundCB = AddSettingToggleButton(groupA, ConstructionRefundLocale, Refund);
            m_refundCB.eventClicked += (c, p) => {
                Refund = (c as UICheckBox).isChecked;
                SaveSettings();
            };

            m_autoMoneyCB = AddSettingToggleButton(groupA, EnabledAutoMoneyLocale, EnabledAutoMoney);
            m_autoMoneyCB.eventClicked += (c, p) => {
                EnabledAutoMoney = (c as UICheckBox).isChecked;
                SaveSettings();
                addCashAmount.isVisible = cashThreshold.isVisible = EnabledAutoMoney;
            };




            cashThreshold = groupA.AddUIComponent<UIFancySlider>();
            cashThreshold.width = groupA.width - 110;
            cashThreshold.Initialize(GALocale.GetLocale(@"AddCashThreshold"), 10000f, 100000f, 5000f, DefaultMinAmount, (_, value) => {
                DefaultMinAmount = (int)value;
                SaveSettings();
            });
            cashThreshold.isVisible = EnabledAutoMoney;

            addCashAmount = groupA.AddUIComponent<UIFancySlider>();
            addCashAmount.width = groupA.width - 110f;
            addCashAmount.Initialize(GALocale.GetLocale(@"AddCashAmount"), 500000f, 8000000f, 100000f, DefaultGetCash, (_, value) => {
                DefaultGetCash = (int)value;
                SaveSettings();
            });
            addCashAmount.isVisible = EnabledAutoMoney;

            UILabel EconomicIncome = groupA.AddUIComponent<UILabel>();
            EconomicIncome.wordWrap = false;
            EconomicIncome.textScale = 1.1f;
            EconomicIncome.textColor = m_greyColor;
            EconomicIncome.text = GALocale.GetLocale(@"EconomicIncome");
            EconomicIncome.relativePosition = new Vector3(0, 0f);

            UIFancySlider residentialFactor = groupA.AddUIComponent<UI.UIFancySlider>();
            residentialFactor.width = groupA.width - 110f;
            residentialFactor.Initialize(GALocale.GetLocale(@"ResidentialMultiplierFactor"), 1f, 100f, 1f, ResidenticalMultiplierFactor, (_, value) => {
                ResidenticalMultiplierFactor = (int)value;
                SaveSettings();
            });

            UI.UIFancySlider industrialFactor = groupA.AddUIComponent<UI.UIFancySlider>();
            industrialFactor.width = groupA.width - 110f;
            industrialFactor.Initialize(GALocale.GetLocale(@"IndustrialMultiplierFactor"), 1f, 100f, 1f, IndustrialMultiplierFactor, (_, value) => {
                IndustrialMultiplierFactor = (int)value;
                SaveSettings();
            });

            UI.UIFancySlider commercialFactor = groupA.AddUIComponent<UI.UIFancySlider>();
            commercialFactor.width = groupA.width - 110f;
            commercialFactor.Initialize(GALocale.GetLocale(@"CommercialMultiplierFactor"), 1f, 100f, 1f, CommercialMultiplierFactor, (_, value) => {
                CommercialMultiplierFactor = (int)value;
                SaveSettings();
            });

            UIFancySlider officeFactor = groupA.AddUIComponent<UI.UIFancySlider>();
            officeFactor.width = groupA.width - 110f;
            officeFactor.Initialize(GALocale.GetLocale(@"OfficeMultiplierFactor"), 1f, 100f, 1f, OfficeMultiplierFactor, (_, value) => {
                OfficeMultiplierFactor = (int)value;
                SaveSettings();
            });

            UIButton reset = AddButton(groupA, 0.9f, GALocale.GetLocale(@"Reset"), null, null);



            reset.eventClick += (_, p) => {
                Reset();
                cashThreshold.value = defaultMinAmount;
                addCashAmount.value = defaultGetCash;
                residentialFactor.value = residentialMultiplierFactor;
                industrialFactor.value = industrialMultiplierFactor;
                commercialFactor.value = commercialMultiplierFactor;
                officeFactor.value = officeMultiplierFactor;
                ThreadPool.QueueUserWorkItem(SaveSettings);
            };
        }

        private static void ShowSupportOptions(UIPanel root) {
            AdvancedAutoLayoutGroupPanel groupPanel = root.AddUIComponent<AdvancedAutoLayoutGroupPanel>();
            groupPanel.width = 700f;
            groupPanel.relativePosition = new Vector2(0f, 10f);
            groupPanel.PanelPadding = new RectOffset(10, 10, 10, 0);
            UIButton logButton = AddSettingButton(groupPanel, GALocale.GetLocale(@"ChangeLog"), 400f, 34f);
            logButton.eventClicked += (c, p) => MessageBox.Show<NewFunctionMessageBox>();
            UIButton compatibilityButton = AddSettingButton(groupPanel, GALocale.GetLocale(@"CompatibilityCheck"), 400f, 34f);
            compatibilityButton.eventClicked += (c, p) => MessageBox.Show<CompatibilityMessageBox>();
        }

        private static UICanvasSprite AddContainer(UIPanel root, UIComponent alignTo, float width, float height, string label) {
            Color grey = Color.grey;
            UICanvasSprite canvas = root.AddUIComponent<UICanvasSprite>();
            UILabel name = root.AddUIComponent<UILabel>();
            name.wordWrap = false;
            name.relativePosition = new Vector3(40f, 4f);
            name.text = label;
            canvas.size = new Vector2(width, height);
            canvas.desiredCanvasWidth = width;
            canvas.desiredCanvasHeight = height;
            if (alignTo is null) canvas.relativePosition = new Vector3(0f, 20f);
            else canvas.relativePosition = new Vector3(alignTo.relativePosition.x, alignTo.relativePosition.y + alignTo.size.y);
            canvas.MoveTo(2f, 2f);
            canvas.LineTo(canvas.size.x - 2f, 2f, grey);
            canvas.LineTo(canvas.size.x - 2f, canvas.size.y - 2f, grey);
            canvas.LineTo(35f + name.width + 5f, canvas.size.y - 2f, grey);
            canvas.MoveTo(35f, canvas.size.y - 2f);
            canvas.LineTo(2f, canvas.size.y - 2f, grey);
            canvas.LineTo(2f, 2f, grey);
            canvas.ApplyChanges();
            return canvas;
        }

        private static UIPanel AddTab(UITabstrip tabStrip, string tabName, int tabIndex, bool autoLayout) {
            const float minWidth = 175f;
            UIButton tabButton = tabStrip.AddTab(tabName);
            tabButton.atlas = UI.CustomAtlas.CommonAtlas;
            tabButton.normalBgSprite = @"TabButtonNormal";
            tabButton.focusedBgSprite = @"TabButtonPressed";
            tabButton.hoveredBgSprite = @"TabButtonHovered";

            tabButton.tooltip = tabName;
            using (UIFontRenderer fontRenderer = tabButton.font.ObtainRenderer()) {
                Vector2 strSize = fontRenderer.MeasureString(tabName);
                tabButton.width = EMath.Max(minWidth, strSize.x + 10f);
                tabButton.textPadding = new RectOffset(0, 0, 1, 0);
                tabButton.textScale = TabFontScale;

            }
            tabButton.height = 34f;
            tabStrip.selectedIndex = tabIndex;
            UIPanel rootPanel = tabStrip.tabContainer.components[tabIndex] as UIPanel;
            rootPanel.autoLayout = autoLayout;
            if (autoLayout) {
                rootPanel.autoLayoutDirection = LayoutDirection.Vertical;
                rootPanel.autoLayoutPadding.top = 0;
                rootPanel.autoLayoutPadding.bottom = 0;
                rootPanel.autoLayoutPadding.left = 5;
            }
            return rootPanel;
        }


        private static UILabel AddFunctionDescription(UIPanel root, string name, bool state, float fontScale = 1.1f) {
            UIPanel panel = root.AddUIComponent<UIPanel>();
            panel.autoLayout = true;
            panel.autoFitChildrenVertically = true;
            UILabel nameLabel = panel.AddUIComponent<UILabel>();
            UILabel stateLabel = panel.AddUIComponent<UILabel>();
            nameLabel.wordWrap = false;
            nameLabel.textScale = fontScale;
            nameLabel.textColor = m_greyColor;
            nameLabel.text = GALocale.GetLocale(@"builtinFunction") + @" [" + name + @"] ";
            stateLabel.wordWrap = false;
            stateLabel.textScale = fontScale;
            stateLabel.textColor = state ? m_greenColor : m_redColor;
            stateLabel.text = state ? GALocale.GetLocale(@"isEnabled") : GALocale.GetLocale(@"isDisabled");
            stateLabel.relativePosition = new Vector3(nameLabel.relativePosition.x + nameLabel.size.x, nameLabel.relativePosition.y);

            return nameLabel;
        }

        private static UILabel AddDescription(UIPanel panel, string name, UIComponent alignTo, float fontScale, string text) {
            UILabel desc = panel.AddUIComponent<UILabel>();
            desc.name = name;
            desc.width = panel.width - 80;
            desc.wordWrap = true;
            desc.autoHeight = true;
            desc.textScale = fontScale;
            desc.textColor = m_redColor;
            desc.text = text;
            desc.relativePosition = new Vector3(alignTo.relativePosition.x + 26f, alignTo.relativePosition.y + alignTo.height - 5f);
            return desc;
        }

    }
}
