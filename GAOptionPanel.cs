using UnityEngine;
using ColossalFramework;
using ColossalFramework.UI;
using static GameAnarchy.GAMod;
using EManagersLib;


namespace GameAnarchy {
    internal static class GAOptionPanel {
        internal const float TabFontScale = 0.87f;
        internal const float DefaultFontScale = 0.95f;
        internal const float SmallFontScale = 0.85f;
        private const float MIN_SCALE_FACTOR = 1.0f;
        private const float MAX_SCALE_FACTOR = 84f;
        private static readonly Color32 m_greyColor = new Color32(0xe6, 0xe6, 0xe6, 0xee);
        private static readonly Color32 m_greenColor = new Color32(0xcf, 0xf9, 0x8f, 0xff);
        private static readonly Color32 m_orangeColor = new Color32(0xfe, 0xd8, 0x8b, 0xff);
        private static readonly Color32 m_redColor = Color.red;
        public static UICheckBox m_achievementsCB;
        public static UICheckBox m_autoMoneyCB;
        public static UICheckBox m_skipIntroCB;

        public static UICheckBox m_unlockDeluxeLandmarksCB;
        public static UICheckBox m_unlockUniqueBuildingsCB;
        public static UICheckBox m_unlockWondersCB;
        public static UICheckBox m_unlockEuropeanLandmarksCB;
        public static UICheckBox m_unlockAfterDarkLandmarksCB;
        public static UICheckBox m_unlockSnaowfallLandmarksCB;
        public static UICheckBox m_unlockNaturalDisastersLandmarksCB;
        public static UICheckBox m_unlockMassTransitLandmarksCB;
        public static UICheckBox m_unlockGreenCitiesLandmarksCB;
        public static UICheckBox m_unlockConcertsLandmarksCB;
        public static UICheckBox m_unlockParklifeLandmarksCB;
        public static UICheckBox m_unlockIndustriesLandmarksCB;
        public static UICheckBox m_unlockCampusLandmarksCB;
        public static UICheckBox m_unlockSunsetHarborLandmarksCB;
        public static UICheckBox m_unlockAirportsLandmarksCB;

        public static UICheckBox m_removeNoisePollutionCB;
        public static UICheckBox m_removeGroundPollutionCB;
        public static UICheckBox m_removeWaterPollutionCB;

        private const float OFFSETX = 5f;

        internal static void SetupPanel(UIPanel root) {
            UITabstrip tabBar = root.AddUIComponent<UITabstrip>();
            UITabContainer tabContainer = root.AddUIComponent<UITabContainer>();
            tabBar.tabPages = tabContainer;
            tabContainer.size = new Vector2(root.width, 520f);

            UIPanel milestonesPanel = AddTab(tabBar, GALocale.GetLocale(@"MilestonesOptionTab"), 0, true);
            milestonesPanel.autoLayout = false;
            milestonesPanel.autoSize = false;
            ShowMilestonesOptions(milestonesPanel);

            UIPanel gameAnarchyPanel = AddTab(tabBar, GALocale.GetLocale(@"GameAnarchyTab"), 1, true);
            gameAnarchyPanel.autoLayout = false;
            gameAnarchyPanel.autoSize = false;
            ShowGameAnarchyOptions(gameAnarchyPanel);

            AddTab(tabBar, GALocale.GetLocale(@"KeyboardShortcutTab"), 2, true).gameObject.AddComponent<GAKeyBinding>();
        }

        private static void ShowMilestonesOptions(UIPanel panel) {
            UILabel ImportantLabel = AddDescription(panel, @"ImportantLabel", panel, MIN_SCALE_FACTOR, GALocale.GetLocale(@"Important"));
            ImportantLabel.relativePosition = new Vector3(OFFSETX, 15f);

            m_unlockDeluxeLandmarksCB =AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockDeluxeLandmarks"), EnabledUnlockDeluxeLandmarks);
            m_unlockDeluxeLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockDeluxeLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockDeluxeLandmarksCB.relativePosition = new Vector3(OFFSETX, ImportantLabel.relativePosition.y + 10f);

            m_unlockUniqueBuildingsCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockUniqueBuildings"), EnabledUnlockUniqueBuildings);
            m_unlockUniqueBuildingsCB.eventClicked += (c, p) => {
                EnabledUnlockUniqueBuildings = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockUniqueBuildingsCB.relativePosition = new Vector3(OFFSETX, m_unlockDeluxeLandmarksCB.relativePosition.y+25f );

            m_unlockWondersCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockWonders"), EnabledUnlockWonders);
            m_unlockWondersCB.eventClicked += (c, p) => {
                EnabledUnlockWonders = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockWondersCB.relativePosition = new Vector3(OFFSETX, m_unlockUniqueBuildingsCB.relativePosition.y + 25f);
            
            m_unlockEuropeanLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockEuropeanLandmarks"), EnabledUnlockEuropeanLandmarks);
            m_unlockEuropeanLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockEuropeanLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockEuropeanLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockWondersCB.relativePosition.y + 25f);

            m_unlockAfterDarkLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockAfterDarkLandmarks"), EnabledUnlockAfterDarkLandmarks);
            m_unlockAfterDarkLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockAfterDarkLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockAfterDarkLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockEuropeanLandmarksCB.relativePosition.y + 25f);

            m_unlockSnaowfallLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockSnaowfallLandmarks"), EnabledUnlockSnaowfallLandmarks);
            m_unlockSnaowfallLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockSnaowfallLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockSnaowfallLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockAfterDarkLandmarksCB.relativePosition.y + 25f);

            m_unlockNaturalDisastersLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockNaturalDisastersLandmarks"), EnabledUnlockNaturalDisastersLandmarks);
            m_unlockNaturalDisastersLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockNaturalDisastersLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockNaturalDisastersLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockSnaowfallLandmarksCB.relativePosition.y + 25f);

            m_unlockMassTransitLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockMassTransitLandmarks"), EnabledUnlockMassTransitLandmarks);
            m_unlockMassTransitLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockMassTransitLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockMassTransitLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockNaturalDisastersLandmarksCB.relativePosition.y + 25f);

            m_unlockGreenCitiesLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockGreenCitiesLandmarks"), EnabledUnlockGreenCitiesLandmarks);
            m_unlockGreenCitiesLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockGreenCitiesLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockGreenCitiesLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockMassTransitLandmarksCB.relativePosition.y + 25f);

            m_unlockConcertsLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockConcertsLandmarks"), EnabledUnlockConcertsLandmarks);
            m_unlockConcertsLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockConcertsLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockConcertsLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockGreenCitiesLandmarksCB.relativePosition.y + 25f);

            m_unlockParklifeLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockParklifeLandmarks"), EnabledUnlockParklifeLandmarks);
            m_unlockParklifeLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockParklifeLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockParklifeLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockConcertsLandmarksCB.relativePosition.y + 25f);

            m_unlockIndustriesLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockIndustriesLandmarks"), EnabledUnlockIndustriesLandmarks);
            m_unlockIndustriesLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockIndustriesLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockIndustriesLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockParklifeLandmarksCB.relativePosition.y + 25f);

            m_unlockCampusLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockCampusLandmarks"), EnabledUnlockCampusLandmarks);
            m_unlockCampusLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockCampusLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockCampusLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockIndustriesLandmarksCB.relativePosition.y + 25f);

            m_unlockSunsetHarborLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockSunsetHarborLandmarks"), EnabledUnlockSunsetHarborLandmarks);
            m_unlockSunsetHarborLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockSunsetHarborLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockSunsetHarborLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockCampusLandmarksCB.relativePosition.y + 25f);

            m_unlockAirportsLandmarksCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledUnlockAirportsLandmarks"), EnabledUnlockAirportsLandmarks);
            m_unlockAirportsLandmarksCB.eventClicked += (c, p) => {
                EnabledUnlockAirportsLandmarks = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_unlockAirportsLandmarksCB.relativePosition = new Vector3(OFFSETX, m_unlockSunsetHarborLandmarksCB.relativePosition.y + 25f);
        }

        private static void ShowGameAnarchyOptions(UIPanel panel) {
            m_achievementsCB =AddCheckBox(panel, GALocale.GetLocale(@"EnableAchievements"), EnabledAchievements);
            m_achievementsCB.eventClicked += (c, p) => { 
                EnabledAchievements = (c as UICheckBox).isChecked;
                SaveSettings();
             };
            m_achievementsCB.relativePosition = new Vector3(OFFSETX, 0f);

            m_autoMoneyCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledAutoMoney"), EnabledAutoMoney);
            m_autoMoneyCB.eventClicked += (c, p) => {
                EnabledAutoMoney = (c as UICheckBox).isChecked;
                SaveSettings();
             };
            m_autoMoneyCB.relativePosition = new Vector3(OFFSETX, m_achievementsCB.relativePosition.y + 25f);
            
            m_removeNoisePollutionCB = AddCheckBox(panel, GALocale.GetLocale(@"RemoveNoisePollution"), RemoveNoisePollution);
            m_removeNoisePollutionCB.eventClicked += (c, p) => {
                RemoveNoisePollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_removeNoisePollutionCB.relativePosition = new Vector3(OFFSETX, m_autoMoneyCB.relativePosition.y + 45f);

            m_removeGroundPollutionCB = AddCheckBox(panel, GALocale.GetLocale(@"RemoveGroundPollution"), RemoveGroundPollution);
            m_removeGroundPollutionCB.eventClicked += (c, p) => {
                RemoveGroundPollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_removeGroundPollutionCB.relativePosition = new Vector3(OFFSETX, m_removeNoisePollutionCB.relativePosition.y + 25f);

            m_removeWaterPollutionCB = AddCheckBox(panel, GALocale.GetLocale(@"RemoveWaterPollution"), RemoveWaterPollution);
            m_removeWaterPollutionCB.eventClicked += (c, p) => {
                RemoveWaterPollution = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_removeWaterPollutionCB.relativePosition = new Vector3(OFFSETX, m_removeGroundPollutionCB.relativePosition.y + 25f);

            m_skipIntroCB = AddCheckBox(panel, GALocale.GetLocale(@"EnabledSkipIntro"), EnabledSkipIntro);
            m_skipIntroCB.eventClicked += (c, p) => {
                EnabledSkipIntro = (c as UICheckBox).isChecked;
                SaveSettings();
            };
            m_skipIntroCB.relativePosition = new Vector3(OFFSETX, m_removeWaterPollutionCB.relativePosition.y + 45f);


            UILabel oilAndOreDepletionRate = panel.AddUIComponent<UILabel>();
            oilAndOreDepletionRate.wordWrap = false;
            oilAndOreDepletionRate.textScale = DefaultFontScale;
            oilAndOreDepletionRate.textColor = m_greyColor;
            oilAndOreDepletionRate.text = GALocale.GetLocale(@"OilAndOreCapacity");
            oilAndOreDepletionRate.relativePosition = new Vector3(OFFSETX, m_skipIntroCB.relativePosition.y + m_skipIntroCB.size.y+15f);

            UI.UIFancySlider oilCapacity = panel.AddUIComponent<UI.UIFancySlider>();
            oilCapacity.width = panel.width - 180f;
            oilCapacity.Initialize(GALocale.GetLocale(@"OilCapacity"), 0f, 100f, 1f, OilCapacity, (_, value) => {
                OilCapacity = value;
                SaveSettings();
            });
            oilCapacity.relativePosition = new Vector3(OFFSETX+15f, oilAndOreDepletionRate.relativePosition.y + oilAndOreDepletionRate.size.y+2f);

            UI.UIFancySlider oreCapacity = panel.AddUIComponent<UI.UIFancySlider>();
            oreCapacity.width = panel.width - 180f;
            oreCapacity.Initialize(GALocale.GetLocale(@"OreCapacity"), 0f, 100f, 1f, OreCapacity, (_, value) => {
                OreCapacity = value;
                SaveSettings();
            });
            oreCapacity.relativePosition = new Vector3(OFFSETX+15f, oilCapacity.relativePosition.y + oilCapacity.size.y + 5f);

            UILabel ImportantLabel = AddDescription(panel, @"ImportantLabel", panel, DefaultFontScale, " ");
            ImportantLabel.relativePosition = new Vector3(OFFSETX, oreCapacity.relativePosition.y + 45f);

            UILabel fastReturn = AddFunctionDescription(panel, GALocale.GetLocale(@"FastReturn"), true, ImportantLabel, DefaultFontScale);
            UILabel sortSettings = AddFunctionDescription(panel, GALocale.GetLocale(@"SortSettings"), true, fastReturn, DefaultFontScale);
            UILabel unlimitedUniqueBuildings = AddFunctionDescription(panel, GALocale.GetLocale(@"UnlimitedUniqueBuildings"), true, sortSettings, DefaultFontScale);

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
            if (alignTo is null) canvas.relativePosition = new Vector3(0f, 10f);
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

            tabButton.normalBgSprite = @"SubBarButtonBase";
            tabButton.disabledBgSprite = @"SubBarButtonBaseDisabled";
            tabButton.focusedBgSprite = @"SubBarButtonBaseFocused";
            tabButton.hoveredBgSprite = @"SubBarButtonBaseHovered";
            tabButton.pressedBgSprite = @"SubBarButtonBasePressed";
            tabButton.tooltip = tabName;
            using (UIFontRenderer fontRenderer = tabButton.font.ObtainRenderer()) {
                Vector2 strSize = fontRenderer.MeasureString(tabName);
                tabButton.width = EMath.Max(minWidth, strSize.x + 10f);
                tabButton.textPadding = new RectOffset(0, 0, 1, 0);
                tabButton.textScale = TabFontScale;
            }

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

        private static UICheckBox AddCheckBox(UIPanel panel, string name, bool defaultVal) {
            UICheckBox cb = (UICheckBox)panel.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsCheckBoxTemplate"));
            cb.autoSize = true;
            cb.isLocalized = true;
            cb.label.textScale = 0.95f;
            cb.label.padding = new RectOffset(0, 0, 3, 0);
            cb.label.textColor = m_greenColor;
            cb.text = name;
            cb.height += 20f;
            cb.isChecked = defaultVal;
            return cb;
        }

        private static UILabel AddFunctionDescription(UIPanel panel, string name, bool state, UIComponent alignTo, float fontScale) {
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
            if (alignTo is null) {
                nameLabel.relativePosition = new Vector3(OFFSETX, 0f);
            } else {
                nameLabel.relativePosition = new Vector3(OFFSETX, alignTo.relativePosition.y + alignTo.size.y + 5f);
            }
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

        private static UISlider AddSlider(UIPanel panel, float min, float max, float step, float defaultVal, PropertyChangedEventHandler<float> callback) {
            UISlider slider = panel.Find<UISlider>(@"Slider");
            slider.minValue = min;
            slider.maxValue = max;
            slider.stepSize = step;
            slider.value = defaultVal;
            slider.eventValueChanged += callback;
            return slider;
        }

        private static UIDropDown AddDropdown(UIPanel panel, UIComponent alignTo, string text, string[] options, int defaultSelection, PropertyChangedEventHandler<int> callback) {
            UIPanel uiPanel = panel.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsDropdownTemplate")) as UIPanel;
            UILabel label = uiPanel.Find<UILabel>(@"Label");
            if (text.IsNullOrWhiteSpace()) {
                label.Hide();
            } else {
                label.autoSize = true;
                label.textScale = 0.95f;
                label.textColor = m_orangeColor;
                label.text = text;
            }
            UIDropDown dropDown = uiPanel.Find<UIDropDown>(@"Dropdown");
            dropDown.width = 380;
            dropDown.items = options;
            dropDown.selectedIndex = defaultSelection;
            dropDown.eventSelectedIndexChanged += callback;
            uiPanel.relativePosition = new Vector3(alignTo.relativePosition.x, alignTo.relativePosition.y + alignTo.height);
            return dropDown;
        }


    }
}
