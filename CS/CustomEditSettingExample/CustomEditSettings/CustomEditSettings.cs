using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Settings;
using System;
using System.Linq;
using System.Windows.Media;

namespace CustomEditSettingExample
{
    public class CustomEditSettings : TextEditSettings
    {
        private FontFamily _EditFont;
        public FontFamily EditFont {
            get { return _EditFont; }
            set {
                if (_EditFont != value) {
                    _EditFont = value;
                }
            }
        }

        static CustomEditSettings() {
            EditorSettingsProvider.Default.RegisterUserEditor2(typeof(TextEdit), 
                typeof(CustomEditSettings), 
                optimized => optimized ? new InplaceBaseEdit() : (IBaseEdit)new TextEdit(), 
                () => new CustomEditSettings());
        }

        public CustomEditSettings() { }

        protected override void AssignToEditCore(IBaseEdit edit) {
            base.AssignToEditCore(edit);
            var editor = edit as InplaceBaseEdit;
            if (editor != null) {
                editor.FontFamily = EditFont;
            }
        }
    }
}
