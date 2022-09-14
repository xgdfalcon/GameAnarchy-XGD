using ColossalFramework.UI;
using UnityEngine;

namespace GameAnarchy.UI {
    public class AutoFitChildrenVerticallyPanel : UIPanel {
        public AutoFitChildrenVerticallyPanel() {
            autoLayout = true;
            autoFitChildrenVertically = true;
        }
    }

    public class OptionPanelAdvancedAutoLayoutGroupPanel : AdvancedAutoLayoutGroupPanel {
        public OptionPanelAdvancedAutoLayoutGroupPanel() {
            width = 700f;
            PanelPadding = new RectOffset(10, 10, 10, 0);
        }
    }

    public class AdvancedAutoLayoutGroupPanel : UIPanel {
        public RectOffset PanelPadding {
            get => autoLayoutPadding;
            set => autoLayoutPadding = value;
        }
        public AdvancedAutoLayoutGroupPanel() {
            autoSize = false;
            autoLayout = true;
            autoLayoutDirection = LayoutDirection.Vertical;
            clipChildren = true;
            backgroundSprite = "TextFieldPanel";
            color = UIColor.GroupPanel;
        }
        protected override void OnComponentAdded(UIComponent child) {
            base.OnComponentAdded(child);
            FitChild();
            child.eventVisibilityChanged += OnChildVisibilityChanged;
            child.eventSizeChanged += OnChildSizeChanged;
        }

        private void OnChildVisibilityChanged(UIComponent component, bool value) => FitChild();
        private void OnChildSizeChanged(UIComponent component, Vector2 value) => FitChild();

        protected void FitChild() {
            float totalHeight = 0f;
            foreach (var component in components) {
                if (component.isVisibleSelf)
                    totalHeight = EMath.Max(component.relativePosition.y + component.size.y, totalHeight);
            }
            totalHeight += autoLayoutPadding.top;
            height = totalHeight;
        }

        public virtual void AddBottomMargin(float width = 10f, float height = 0.01f) {
            UICustom.AddSpacer(this, width, height);
        }

    }


}
