using System.Collections.Generic;
using System.Configuration;

namespace natgeo
{
    // This class gets persisted by dotnet between runs :)
    public class bikeSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        [DefaultSettingValue("")]
        public List<bicycle> bikes
        {
            get
            {
                return (List<bicycle>)this["bikes"];
            }
            set
            {
                this["bikes"] = (List<bicycle>)value;
            }
        }
    }
}