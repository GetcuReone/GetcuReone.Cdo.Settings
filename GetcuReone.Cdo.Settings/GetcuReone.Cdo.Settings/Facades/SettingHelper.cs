using GetcuReone.Cdi;
using GetcuReone.Cdi.Extensions;
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

        internal static void FillFullCodes(this List<SettingNamespace> childs, SettingNamespace parent)
        {
            foreach (var child in childs)
            {
                child.FullCode = parent != null
                    ? $"{parent.FullCode}.{child.Code}"
                    : child.Code;

                if (!child.Namespaces.IsNullOrEmpty())
                    FillFullCodes(child.Namespaces, child); ;

                if (!child.Settings.IsNullOrEmpty())
                {
                    foreach (var setting in child.Settings)
                    {
                        setting.FullCode = child.FullCode + "." + setting.Code;
                        if (string.IsNullOrEmpty(setting.Value))
                            setting.Value = setting.DefaultValue;
                    }
                }
            }
        }
    }
}
