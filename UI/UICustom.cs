using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;
using GameAnarchy.UI;
using System;
using ICities;
using System.Collections.Generic;

namespace GameAnarchy.UI {
    public static class UICustom {

        public static UIButton AddButton(UIComponent root, float textScale, string text, float? width, float? height) {
            UIButton button = root.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsButtonTemplate")) as UIButton;
            button.normalBgSprite = "ButtonWhite";
            button.disabledBgSprite = "ButtonWhite";
            button.hoveredBgSprite = "ButtonWhite";
            button.pressedBgSprite = "ButtonWhite";
            button.textColor = Color.white;
            button.disabledTextColor = Color.black;
            button.hoveredTextColor = Color.white;
            button.pressedTextColor = Color.white;
            button.focusedTextColor = Color.white;
            button.color = UIColor.ButtonNormal;
            button.disabledColor = UIColor.ButtonDisabled;
            button.hoveredColor = UIColor.ButtonHovered;
            button.pressedColor = UIColor.ButtonPressed;
            button.focusedColor = UIColor.ButtonNormal;
            button.autoSize = false;
            button.textScale = textScale;
            button.text = text;
            button.wordWrap = true;
            if (width != null && height != null) {
                button.size = new Vector2((float)width, (float)height);
                button.textHorizontalAlignment = UIHorizontalAlignment.Center;
                button.textVerticalAlignment = UIVerticalAlignment.Middle;
            } else {
                using (UIFontRenderer fontRenderer = button.font.ObtainRenderer()) {
                    Vector2 strSize = fontRenderer.MeasureString(text);
                    button.width = strSize.x + 16f;
                    button.height = 32;
                    button.textHorizontalAlignment = UIHorizontalAlignment.Center;
                    button.textVerticalAlignment = UIVerticalAlignment.Middle;
                }
            }
            return button;
        }

        public static UICheckBox AddSettingCheckBox(UIPanel root, string text, bool defaultVal, float posX = 0, float posY = 0, float textScale = 1f) {
            UICheckBox cb = (UICheckBox)root.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsCheckBoxTemplate"));
            cb.size = new Vector2(40f, 20f);
            cb.text = text;
            cb.isChecked = defaultVal;
            cb.label.textScale = textScale;
            cb.label.padding = new RectOffset(30, 0, 3, 0);
            UISprite sprite = cb.AddUIComponent<UISprite>();
            sprite.atlas = CustomAtlas.CommonAtlas;
            sprite.spriteName = "SettingToggleButtonDisabled";
            sprite.size = new Vector2(40f, 20f);
            sprite.relativePosition = Vector2.zero;
            cb.checkedBoxObject = sprite.AddUIComponent<UISprite>();
            var enabledSprite = ((UISprite)cb.checkedBoxObject);
            enabledSprite.atlas = CustomAtlas.CommonAtlas;
            enabledSprite.spriteName = "SettingToggleButtonEnabled";
            cb.checkedBoxObject.size = new Vector2(40f, 20f);
            cb.checkedBoxObject.relativePosition = Vector2.zero;
            cb.relativePosition = new Vector2(posX, posY);
            return cb;
        }

        public static UICheckBox AddSettingToggleButton(UIPanel root, string text, bool defaultVal) {
            UIPanel panel = root.AddUIComponent<UIPanel>();
            panel.size = new Vector2(680f,20f);
            UICheckBox cb = (UICheckBox)panel.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsCheckBoxTemplate"));
            cb.size = new Vector2(40f, 20f);
            cb.text = text;
            cb.isChecked = defaultVal;
            cb.label.textScale = 1.1f;
            cb.label.padding = new RectOffset(22, 0, 3, 0);
            cb.label.height = 20f;
            cb.relativePosition = Vector2.zero;
            UISprite sprite = cb.AddUIComponent<UISprite>();
            sprite.atlas = CustomAtlas.CommonAtlas;
            sprite.spriteName = "SettingToggleButtonDisabled";
            sprite.size = new Vector2(40f, 20f);
            sprite.relativePosition = Vector2.zero;
            cb.checkedBoxObject = sprite.AddUIComponent<UISprite>();
            var enabledSprite = ((UISprite)cb.checkedBoxObject);
            enabledSprite.atlas = CustomAtlas.CommonAtlas;
            enabledSprite.spriteName = "SettingToggleButtonEnabled";
            cb.checkedBoxObject.size = new Vector2(40f, 20f);
            cb.checkedBoxObject.relativePosition = Vector2.zero;
            return cb;
        }


        public static UICheckBox AddSettingToggleButton(UIPanel root, string text, bool defaultVal, float posX = 0, float posY = 0, float textScale = 1.1f) {
            UICheckBox cb = (UICheckBox)root.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsCheckBoxTemplate"));
            cb.size = new Vector2(40f, 20f);
            cb.text = text;
            cb.isChecked = defaultVal;
            cb.label.textScale = textScale;
            cb.label.padding = new RectOffset(22, 0, 3, 0);
            UISprite sprite = cb.AddUIComponent<UISprite>();
            sprite.atlas = CustomAtlas.CommonAtlas;
            sprite.spriteName = "SettingToggleButtonDisabled";
            sprite.size = new Vector2(40f, 20f);
            sprite.relativePosition = Vector2.zero;
            cb.checkedBoxObject = sprite.AddUIComponent<UISprite>();
            var enabledSprite = ((UISprite)cb.checkedBoxObject);
            enabledSprite.atlas = CustomAtlas.CommonAtlas;
            enabledSprite.spriteName = "SettingToggleButtonEnabled";
            cb.checkedBoxObject.size = new Vector2(40f, 20f);
            cb.checkedBoxObject.relativePosition = Vector2.zero;
            cb.relativePosition = new Vector2(posX, posY);
            return cb;
        }

        public static UIButton AddSettingButton(UIComponent root, string text, float? width, float? height, float textScale = 0.9f) {
            UIButton button = root.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsButtonTemplate")) as UIButton;
            button.atlas = CustomAtlas.CommonAtlas;
            button.pressedFgSprite = "SettingButtonPressed";
            button.normalFgSprite = "SettingButtonNormal";
            button.hoveredFgSprite = "SettingButtonHovered";
            button.disabledTextColor = Color.white;
            button.focusedTextColor = Color.white;
            button.hoveredTextColor = Color.white;
            button.pressedTextColor = Color.white;
            button.autoSize = false;
            button.textScale = textScale;
            button.text = text;
            if (width != null && height != null) {
                button.size = new Vector2((float)width, (float)height);
                button.textHorizontalAlignment = UIHorizontalAlignment.Center;
                button.textVerticalAlignment = UIVerticalAlignment.Middle;
            } else {
                using (UIFontRenderer fontRenderer = button.font.ObtainRenderer()) {
                    Vector2 strSize = fontRenderer.MeasureString(text);
                    button.width = strSize.x + 16f;
                    button.height = 32;
                    button.textHorizontalAlignment = UIHorizontalAlignment.Center;
                    button.textVerticalAlignment = UIVerticalAlignment.Middle;
                }
            }

            return button;
        }





        public static UICheckBox AddCheckBox(UIPanel panel, string textLabel, bool defaultVal, Color32 textColor, float textScale = 0.95f, float height = 20f) {
            UICheckBox cb = (UICheckBox)panel.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsCheckBoxTemplate"));
            cb.autoSize = true;
            cb.isLocalized = true;
            cb.label.textScale = textScale;
            cb.label.padding = new RectOffset(0, 0, 3, 0);
            cb.label.textColor = textColor;
            cb.text = textLabel;
            cb.height += height;
            cb.isChecked = defaultVal;
            cb.width = cb.text.Length;
            return cb;
        }

        /// <summary>
        /// Button Template
        /// </summary>
        /// <returns></returns>
        public static UIButton AddButton(UIComponent uIRoot, string text, float? width, float? height, float textScale = 0.9f) {
            UIButton button = uIRoot.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsButtonTemplate")) as UIButton;
            button.autoSize = false;
            if (width != null && height != null) {
                button.size = new Vector2((float)width, (float)height);
                button.textHorizontalAlignment = UIHorizontalAlignment.Center;
                button.textVerticalAlignment = UIVerticalAlignment.Middle;
            }
            button.textScale = textScale;
            button.wordWrap = true;
            button.text = text;
            return button;
        }

       



        public static UIDropDown AddDropdown(UIPanel uIRoot, string textLabel, float width, float height, float textScale, string[] options, int defaultSelection, PropertyChangedEventHandler<int> callback, Vector2 position, RectOffset textFieldPadding = null, RectOffset itemPadding = null) {
            UIPanel uIPanel = uIRoot.AttachUIComponent(UITemplateManager.GetAsGameObject(@"OptionsDropdownTemplate")) as UIPanel;
            UILabel label = uIPanel.Find<UILabel>(@"Label");
            if (textLabel.IsNullOrWhiteSpace()) {
                label.Hide();
            } else {
                label.autoSize = true;
                label.textScale = 0.95f;
                label.text = textLabel;
            }
            UIDropDown dropDown = uIPanel.Find<UIDropDown>(@"Dropdown");
            dropDown.width = width;
            dropDown.height = height;
            dropDown.textScale = textScale;
            if (textFieldPadding != null) dropDown.textFieldPadding = textFieldPadding;
            if (itemPadding != null) dropDown.itemPadding = itemPadding;
            dropDown.items = options;
            dropDown.selectedIndex = defaultSelection;
            dropDown.listScrollbar = null;
            dropDown.listHeight = dropDown.itemHeight * options.Length + 8;
            dropDown.disabledColor = new Color32(80, 80, 80, 255);
            dropDown.disabledTextColor = new Color32(80, 80, 80, 255);
            uIPanel.relativePosition = position;
            dropDown.eventSelectedIndexChanged += callback;
            return dropDown;
        }





        public static UIScrollbar AddScrollbar(UIComponent parent, UIScrollablePanel scrollablePanel) {
            UIScrollbar scrollbar = parent.AddUIComponent<UIScrollbar>();
            scrollbar.size = new Vector2(10f, scrollablePanel.height - 8f);
            scrollbar.orientation = UIOrientation.Vertical;
            scrollbar.pivot = UIPivotPoint.TopLeft;
            scrollbar.minValue = 0;
            scrollbar.value = 0;
            scrollbar.incrementAmount = 50f;
            scrollbar.autoHide = true;
            scrollbar.relativePosition = new Vector2(scrollablePanel.relativePosition.x + scrollablePanel.width - 12f, scrollablePanel.relativePosition.y + 4f);
            UISlicedSprite trackSprite = scrollbar.AddUIComponent<UISlicedSprite>();
            trackSprite.relativePosition = Vector2.zero;
            trackSprite.autoSize = true;
            trackSprite.anchor = UIAnchorStyle.All;
            trackSprite.size = trackSprite.parent.size;
            trackSprite.fillDirection = UIFillDirection.Vertical;
            trackSprite.spriteName = "ScrollbarTrack";
            scrollbar.trackObject = trackSprite;
            UISlicedSprite thumbSprite = trackSprite.AddUIComponent<UISlicedSprite>();
            thumbSprite.relativePosition = Vector2.zero;
            thumbSprite.fillDirection = UIFillDirection.Vertical;
            thumbSprite.autoSize = true;
            thumbSprite.width = thumbSprite.parent.width;
            thumbSprite.spriteName = "ScrollbarThumb";
            scrollbar.thumbObject = thumbSprite;
            scrollablePanel.eventSizeChanged += (s, e) => {
                scrollbar.relativePosition = new Vector2(scrollablePanel.relativePosition.x + scrollablePanel.width - 12f, scrollablePanel.relativePosition.y + 4f);
                scrollbar.height = scrollablePanel.height - 8f;
            };
            scrollablePanel.verticalScrollbar = scrollbar;
            return scrollbar;
        }

        public static void AddSpacer(UIPanel uIPanel, float width = 10f, float height = 10f) {
            UILabel spacer = uIPanel.AddUIComponent<UILabel>();
            spacer.width = width;
            spacer.height = height;
            spacer.autoSize = false;
            spacer.autoHeight = false;
        }


    }
}
