using GetcuReone.Cdi;
using GetcuReone.Cdi.Extensions;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Errors;
using GetcuReone.ComboPatterns.Facade;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.Cdo.Settings.Facades
{
    internal sealed class SettingNamespaceFacade : FacadeBase
    {
        public List<SettingNamespace> GetSettingNamespaces(IEnumerable<string> namespaceCodes)
        {
            Dictionary<string, bool> codes = namespaceCodes
                .Distinct()
                .ToDictionary(code => code, code => false);

            var result = new SettingNamespace[codes.Count];
            foreach (var pair in GetFacade<SettingContextFacade>().LoadSettingContext())
            {
                int counter = -1;
                SettingContext context = pair.Value;

                foreach (string code in codes.Keys.ToList())
                {
                    counter++;
                    if (codes[code])
                        continue;

                    var nSpace = FindNamespace(context.Namespaces, code);

                    if (nSpace != null)
                    {
                        result[counter] = nSpace;
                        codes[code] = true;
                    }
                }

                if (codes.All(p => p.Value))
                    break;
            }

            var notFoundCodes = codes.Where(p => !p.Value).Select(p => p.Key).ToList();
            if (!notFoundCodes.IsNullOrEmpty())
                throw CdiHelper.CreateException(
                    notFoundCodes
                        .Select(code => new ErrorDetail
                        {
                            Code = SettingsErrorCode.SettingNamespaceNotFound,
                            Reason = $"Namespace '{code}' not found."
                        })
                        .ToList());

            return result.ToList();
        }

        public SettingNamespace FindNamespace(List<SettingNamespace> namespaces, string namespaceCode)
        {
            string[] codes = namespaceCode.Split('.');
            SettingNamespace result = null;
            List<SettingNamespace> searchSpaces = namespaces;

            foreach (string code in codes)
            {
                if (searchSpaces == null)
                    return null;

                result = searchSpaces.SingleOrDefault(nSpace => nSpace.Code.EqualsOrdinalIgnoreCase(code));

                if (result == null)
                    return null;

                searchSpaces = result.Namespaces;
            }

            return result;
        }
    }
}
