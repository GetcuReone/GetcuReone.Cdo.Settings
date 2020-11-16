using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.Cdo.Settings.Facades
{
    internal static class SettingHelper
    {
        internal static SettingType SingleType(this IEnumerable<SettingType> types, string settingTypeCode)
        {
            var type = types.SingleOrDefault(t => t.Code.EqualsOrdinalIgnoreCase(settingTypeCode));

            if (type == null)
                throw CdiHelper.CreateException(
                    SettingsErrorCode.SettingTypeNotFaound,
                    $"Not found type setting with '{type.Code}' code.");

            return type;
        }
    }
}
