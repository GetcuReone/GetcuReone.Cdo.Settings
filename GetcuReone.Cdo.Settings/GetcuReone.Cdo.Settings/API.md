<a name='assembly'></a>
# GetcuReone.Cdo.Settings

## Contents

- [ConfigKeys](#T-GetcuReone-Cdo-Settings-ConfigKeys 'GetcuReone.Cdo.Settings.ConfigKeys')
  - [SettingsFolder](#F-GetcuReone-Cdo-Settings-ConfigKeys-SettingsFolder 'GetcuReone.Cdo.Settings.ConfigKeys.SettingsFolder')
  - [SettingsTypesFile](#F-GetcuReone-Cdo-Settings-ConfigKeys-SettingsTypesFile 'GetcuReone.Cdo.Settings.ConfigKeys.SettingsTypesFile')
  - [TemplateSettingFile](#F-GetcuReone-Cdo-Settings-ConfigKeys-TemplateSettingFile 'GetcuReone.Cdo.Settings.ConfigKeys.TemplateSettingFile')
- [ISettings](#T-GetcuReone-Cdo-Settings-ISettings 'GetcuReone.Cdo.Settings.ISettings')
  - [GetBoolSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetBoolSetting-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetBoolSetting(System.String)')
  - [GetContext(loadNamespaces)](#M-GetcuReone-Cdo-Settings-ISettings-GetContext-System-Boolean- 'GetcuReone.Cdo.Settings.ISettings.GetContext(System.Boolean)')
  - [GetIntSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetIntSetting-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetIntSetting(System.String)')
  - [GetNamespace(namespaceCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetNamespace-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetNamespace(System.String)')
  - [GetNamespaces(namespaceCodes)](#M-GetcuReone-Cdo-Settings-ISettings-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.ISettings.GetNamespaces(System.Collections.Generic.IEnumerable{System.String})')
  - [GetPowerModeSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetPowerModeSetting-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetPowerModeSetting(System.String)')
  - [GetSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetSetting-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetSetting(System.String)')
  - [GetSettingType(settingTypeCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetSettingType-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetSettingType(System.String)')
  - [GetSettingTypes(settingTypeCodes)](#M-GetcuReone-Cdo-Settings-ISettings-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.ISettings.GetSettingTypes(System.Collections.Generic.IEnumerable{System.String})')
  - [GetSettingTypes()](#M-GetcuReone-Cdo-Settings-ISettings-GetSettingTypes 'GetcuReone.Cdo.Settings.ISettings.GetSettingTypes')
  - [GetSettings(settingFullCodes)](#M-GetcuReone-Cdo-Settings-ISettings-GetSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.ISettings.GetSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [GetStringSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-ISettings-GetStringSetting-System-String- 'GetcuReone.Cdo.Settings.ISettings.GetStringSetting(System.String)')
  - [SetDefaultSettings(settingFullCodes)](#M-GetcuReone-Cdo-Settings-ISettings-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.ISettings.SetDefaultSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [SetSetting\`\`1(settingFullCode,value)](#M-GetcuReone-Cdo-Settings-ISettings-SetSetting``1-System-String,``0- 'GetcuReone.Cdo.Settings.ISettings.SetSetting``1(System.String,``0)')
  - [SetSetting\`\`1(settingFullCode,value,cultureInfo)](#M-GetcuReone-Cdo-Settings-ISettings-SetSetting``1-System-String,``0,System-Globalization-CultureInfo- 'GetcuReone.Cdo.Settings.ISettings.SetSetting``1(System.String,``0,System.Globalization.CultureInfo)')
  - [SetSettings(request)](#M-GetcuReone-Cdo-Settings-ISettings-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}- 'GetcuReone.Cdo.Settings.ISettings.SetSettings(System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest})')
  - [ValidateSetting(setting,type)](#M-GetcuReone-Cdo-Settings-ISettings-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType- 'GetcuReone.Cdo.Settings.ISettings.ValidateSetting(GetcuReone.Cdm.Configuration.Settings.Setting,GetcuReone.Cdm.Configuration.Settings.SettingType)')
- [SetSettingsRequest](#T-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest')
  - [CheckSettingType](#P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-CheckSettingType 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest.CheckSettingType')
  - [FullCode](#P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-FullCode 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest.FullCode')
  - [NeedSetDefaultValue](#P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-NeedSetDefaultValue 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest.NeedSetDefaultValue')
  - [SettingType](#P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-SettingType 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest.SettingType')
  - [Value](#P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-Value 'GetcuReone.Cdo.Settings.Entities.SetSettingsRequest.Value')
- [SettingContextFacade](#T-GetcuReone-Cdo-Settings-Facades-SettingContextFacade 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade')
  - [FacadeName](#P-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-FacadeName 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade.FacadeName')
  - [GetDefaultSettingTypes()](#M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetDefaultSettingTypes 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade.GetDefaultSettingTypes')
  - [GetSettingContext(loadNamespace)](#M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetSettingContext-System-Boolean- 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade.GetSettingContext(System.Boolean)')
  - [GetSettingTypes()](#M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetSettingTypes 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade.GetSettingTypes')
  - [LoadSettingContext(blockFiles)](#M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-LoadSettingContext-System-Boolean- 'GetcuReone.Cdo.Settings.Facades.SettingContextFacade.LoadSettingContext(System.Boolean)')
- [SettingsAdapter](#T-GetcuReone-Cdo-Settings-SettingsAdapter 'GetcuReone.Cdo.Settings.SettingsAdapter')
  - [#ctor()](#M-GetcuReone-Cdo-Settings-SettingsAdapter-#ctor 'GetcuReone.Cdo.Settings.SettingsAdapter.#ctor')
  - [AdapterName](#P-GetcuReone-Cdo-Settings-SettingsAdapter-AdapterName 'GetcuReone.Cdo.Settings.SettingsAdapter.AdapterName')
  - [GetBoolSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetBoolSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetBoolSetting(System.String)')
  - [GetContext(loadNamespaces)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetContext-System-Boolean- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetContext(System.Boolean)')
  - [GetIntSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetIntSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetIntSetting(System.String)')
  - [GetNamespace(namespaceCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetNamespace-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetNamespace(System.String)')
  - [GetNamespaces(namespaceCodes)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetNamespaces(System.Collections.Generic.IEnumerable{System.String})')
  - [GetPowerModeSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetPowerModeSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetPowerModeSetting(System.String)')
  - [GetSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetSetting(System.String)')
  - [GetSettingType(settingTypeCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingType-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetSettingType(System.String)')
  - [GetSettingTypes(settingTypeCodes)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetSettingTypes(System.Collections.Generic.IEnumerable{System.String})')
  - [GetSettingTypes()](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingTypes 'GetcuReone.Cdo.Settings.SettingsAdapter.GetSettingTypes')
  - [GetSettings(settingFullCodes)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [GetStringSetting(settingFullCode)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-GetStringSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsAdapter.GetStringSetting(System.String)')
  - [SetDefaultSettings(settingFullCodes)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsAdapter.SetDefaultSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [SetSetting\`\`1(settingFullCode,value)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSetting``1-System-String,``0- 'GetcuReone.Cdo.Settings.SettingsAdapter.SetSetting``1(System.String,``0)')
  - [SetSetting\`\`1(settingFullCode,value,cultureInfo)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSetting``1-System-String,``0,System-Globalization-CultureInfo- 'GetcuReone.Cdo.Settings.SettingsAdapter.SetSetting``1(System.String,``0,System.Globalization.CultureInfo)')
  - [SetSettings(request)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}- 'GetcuReone.Cdo.Settings.SettingsAdapter.SetSettings(System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest})')
  - [ValidateSetting(setting,type)](#M-GetcuReone-Cdo-Settings-SettingsAdapter-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType- 'GetcuReone.Cdo.Settings.SettingsAdapter.ValidateSetting(GetcuReone.Cdm.Configuration.Settings.Setting,GetcuReone.Cdm.Configuration.Settings.SettingType)')
- [SettingsErrorCode](#T-GetcuReone-Cdo-Settings-SettingsErrorCode 'GetcuReone.Cdo.Settings.SettingsErrorCode')
  - [InvalidConfig](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidConfig 'GetcuReone.Cdo.Settings.SettingsErrorCode.InvalidConfig')
  - [InvalidSettingType](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidSettingType 'GetcuReone.Cdo.Settings.SettingsErrorCode.InvalidSettingType')
  - [InvalidSettingValue](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidSettingValue 'GetcuReone.Cdo.Settings.SettingsErrorCode.InvalidSettingValue')
  - [SettingNamespaceNotFound](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingNamespaceNotFound 'GetcuReone.Cdo.Settings.SettingsErrorCode.SettingNamespaceNotFound')
  - [SettingNotFound](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingNotFound 'GetcuReone.Cdo.Settings.SettingsErrorCode.SettingNotFound')
  - [SettingTypeNotFaound](#P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingTypeNotFaound 'GetcuReone.Cdo.Settings.SettingsErrorCode.SettingTypeNotFaound')
- [SettingsFacade](#T-GetcuReone-Cdo-Settings-Facades-SettingsFacade 'GetcuReone.Cdo.Settings.Facades.SettingsFacade')
  - [FacadeName](#P-GetcuReone-Cdo-Settings-Facades-SettingsFacade-FacadeName 'GetcuReone.Cdo.Settings.Facades.SettingsFacade.FacadeName')
  - [ValidateSetting(setting,settingType)](#M-GetcuReone-Cdo-Settings-Facades-SettingsFacade-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType- 'GetcuReone.Cdo.Settings.Facades.SettingsFacade.ValidateSetting(GetcuReone.Cdm.Configuration.Settings.Setting,GetcuReone.Cdm.Configuration.Settings.SettingType)')
- [SettingsService](#T-GetcuReone-Cdo-Settings-SettingsService 'GetcuReone.Cdo.Settings.SettingsService')
  - [FactoryName](#P-GetcuReone-Cdo-Settings-SettingsService-FactoryName 'GetcuReone.Cdo.Settings.SettingsService.FactoryName')
  - [GetBoolSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-GetBoolSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetBoolSetting(System.String)')
  - [GetContext()](#M-GetcuReone-Cdo-Settings-SettingsService-GetContext-System-Boolean- 'GetcuReone.Cdo.Settings.SettingsService.GetContext(System.Boolean)')
  - [GetIntSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-GetIntSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetIntSetting(System.String)')
  - [GetNamespace()](#M-GetcuReone-Cdo-Settings-SettingsService-GetNamespace-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetNamespace(System.String)')
  - [GetNamespaces()](#M-GetcuReone-Cdo-Settings-SettingsService-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsService.GetNamespaces(System.Collections.Generic.IEnumerable{System.String})')
  - [GetPowerModeSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-GetPowerModeSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetPowerModeSetting(System.String)')
  - [GetSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-GetSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetSetting(System.String)')
  - [GetSettingType()](#M-GetcuReone-Cdo-Settings-SettingsService-GetSettingType-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetSettingType(System.String)')
  - [GetSettingTypes()](#M-GetcuReone-Cdo-Settings-SettingsService-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsService.GetSettingTypes(System.Collections.Generic.IEnumerable{System.String})')
  - [GetSettingTypes()](#M-GetcuReone-Cdo-Settings-SettingsService-GetSettingTypes 'GetcuReone.Cdo.Settings.SettingsService.GetSettingTypes')
  - [GetSettings()](#M-GetcuReone-Cdo-Settings-SettingsService-GetSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsService.GetSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [GetStringSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-GetStringSetting-System-String- 'GetcuReone.Cdo.Settings.SettingsService.GetStringSetting(System.String)')
  - [SetDefaultSettings()](#M-GetcuReone-Cdo-Settings-SettingsService-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}- 'GetcuReone.Cdo.Settings.SettingsService.SetDefaultSettings(System.Collections.Generic.IEnumerable{System.String})')
  - [SetSetting\`\`1()](#M-GetcuReone-Cdo-Settings-SettingsService-SetSetting``1-System-String,``0- 'GetcuReone.Cdo.Settings.SettingsService.SetSetting``1(System.String,``0)')
  - [SetSetting\`\`1()](#M-GetcuReone-Cdo-Settings-SettingsService-SetSetting``1-System-String,``0,System-Globalization-CultureInfo- 'GetcuReone.Cdo.Settings.SettingsService.SetSetting``1(System.String,``0,System.Globalization.CultureInfo)')
  - [SetSettings()](#M-GetcuReone-Cdo-Settings-SettingsService-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}- 'GetcuReone.Cdo.Settings.SettingsService.SetSettings(System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest})')
  - [ValidateSetting()](#M-GetcuReone-Cdo-Settings-SettingsService-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType- 'GetcuReone.Cdo.Settings.SettingsService.ValidateSetting(GetcuReone.Cdm.Configuration.Settings.Setting,GetcuReone.Cdm.Configuration.Settings.SettingType)')

<a name='T-GetcuReone-Cdo-Settings-ConfigKeys'></a>
## ConfigKeys `type`

##### Namespace

GetcuReone.Cdo.Settings

##### Summary

Setting keys in the config file.

<a name='F-GetcuReone-Cdo-Settings-ConfigKeys-SettingsFolder'></a>
### SettingsFolder `constants`

##### Summary

Contains the path to the folder where the settings files are located.

<a name='F-GetcuReone-Cdo-Settings-ConfigKeys-SettingsTypesFile'></a>
### SettingsTypesFile `constants`

##### Summary

Indicates the location of the file in which the types of settings are located.

<a name='F-GetcuReone-Cdo-Settings-ConfigKeys-TemplateSettingFile'></a>
### TemplateSettingFile `constants`

##### Summary

Settings file name template.

<a name='T-GetcuReone-Cdo-Settings-ISettings'></a>
## ISettings `type`

##### Namespace

GetcuReone.Cdo.Settings

##### Summary

Interface for working with settings.

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetBoolSetting-System-String-'></a>
### GetBoolSetting(settingFullCode) `method`

##### Summary

Get setting with [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetContext-System-Boolean-'></a>
### GetContext(loadNamespaces) `method`

##### Summary

Get setting context.

##### Returns

Setting context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loadNamespaces | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetIntSetting-System-String-'></a>
### GetIntSetting(settingFullCode) `method`

##### Summary

Get setting with [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetNamespace-System-String-'></a>
### GetNamespace(namespaceCode) `method`

##### Summary

Get [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace') by code.

##### Returns

[SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespaceCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetNamespaces(namespaceCodes) `method`

##### Summary

Get array [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace') by `namespaceCodes`.

##### Returns

array [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespaceCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetPowerModeSetting-System-String-'></a>
### GetPowerModeSetting(settingFullCode) `method`

##### Summary

Get setting with [PowerMode](#T-GetcuReone-Cdm-Configuration-Settings-Enums-PowerMode 'GetcuReone.Cdm.Configuration.Settings.Enums.PowerMode') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetSetting-System-String-'></a>
### GetSetting(settingFullCode) `method`

##### Summary

Get setting by code.

##### Returns

Settings

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

##### Remarks

With dot separated namespace names in code.

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetSettingType-System-String-'></a>
### GetSettingType(settingTypeCode) `method`

##### Summary

Get setting type by code.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingTypeCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettingTypes(settingTypeCodes) `method`

##### Summary

Get setting types by codes.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingTypeCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | setting type codes. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetSettingTypes'></a>
### GetSettingTypes() `method`

##### Summary

Get all settig types.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettings(settingFullCodes) `method`

##### Summary

Get settings by codes.

##### Returns

Settings

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | Full customization codes. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-GetStringSetting-System-String-'></a>
### GetStringSetting(settingFullCode) `method`

##### Summary

Get setting with [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### SetDefaultSettings(settingFullCodes) `method`

##### Summary

Set default settings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-SetSetting``1-System-String,``0-'></a>
### SetSetting\`\`1(settingFullCode,value) `method`

##### Summary

Set setting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |
| value | [\`\`0](#T-``0 '``0') | New setting value. |

<a name='M-GetcuReone-Cdo-Settings-ISettings-SetSetting``1-System-String,``0,System-Globalization-CultureInfo-'></a>
### SetSetting\`\`1(settingFullCode,value,cultureInfo) `method`

##### Summary

Set setting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |
| value | [\`\`0](#T-``0 '``0') | New setting value. |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}-'></a>
### SetSettings(request) `method`

##### Summary

Set settings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest}') |  |

<a name='M-GetcuReone-Cdo-Settings-ISettings-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType-'></a>
### ValidateSetting(setting,type) `method`

##### Summary

Setting validation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| setting | [GetcuReone.Cdm.Configuration.Settings.Setting](#T-GetcuReone-Cdm-Configuration-Settings-Setting 'GetcuReone.Cdm.Configuration.Settings.Setting') | Setting. |
| type | [GetcuReone.Cdm.Configuration.Settings.SettingType](#T-GetcuReone-Cdm-Configuration-Settings-SettingType 'GetcuReone.Cdm.Configuration.Settings.SettingType') | Setting type. |

<a name='T-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest'></a>
## SetSettingsRequest `type`

##### Namespace

GetcuReone.Cdo.Settings.Entities

##### Summary

Request for [SetSettings](#M-GetcuReone-Cdo-Settings-ISettings-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}- 'GetcuReone.Cdo.Settings.ISettings.SetSettings(System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest})').

<a name='P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-CheckSettingType'></a>
### CheckSettingType `property`

##### Summary

True - check setting type

<a name='P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-FullCode'></a>
### FullCode `property`

##### Summary

Setting full code.

<a name='P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-NeedSetDefaultValue'></a>
### NeedSetDefaultValue `property`

##### Summary

True - set default value.

<a name='P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-SettingType'></a>
### SettingType `property`

##### Summary

Settings type.

<a name='P-GetcuReone-Cdo-Settings-Entities-SetSettingsRequest-Value'></a>
### Value `property`

##### Summary

Setting value.

<a name='T-GetcuReone-Cdo-Settings-Facades-SettingContextFacade'></a>
## SettingContextFacade `type`

##### Namespace

GetcuReone.Cdo.Settings.Facades

##### Summary

Facade for work with [SettingContext](#T-GetcuReone-Cdm-Configuration-Settings-SettingContext 'GetcuReone.Cdm.Configuration.Settings.SettingContext').

<a name='P-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-FacadeName'></a>
### FacadeName `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetDefaultSettingTypes'></a>
### GetDefaultSettingTypes() `method`

##### Summary

Get default setting types.

##### Returns

Setting types.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetSettingContext-System-Boolean-'></a>
### GetSettingContext(loadNamespace) `method`

##### Summary

Get setting context.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loadNamespace | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True - load include namespace. |

<a name='M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-GetSettingTypes'></a>
### GetSettingTypes() `method`

##### Summary

Get all types of settings.

##### Returns

Setting types.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-Facades-SettingContextFacade-LoadSettingContext-System-Boolean-'></a>
### LoadSettingContext(blockFiles) `method`

##### Summary

Loading settings.

##### Returns

Setting ontexts from files

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| blockFiles | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True - lock setting files. |

<a name='T-GetcuReone-Cdo-Settings-SettingsAdapter'></a>
## SettingsAdapter `type`

##### Namespace

GetcuReone.Cdo.Settings

##### Summary

Adapter for [ISettings](#T-GetcuReone-Cdo-Settings-ISettings 'GetcuReone.Cdo.Settings.ISettings').

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='P-GetcuReone-Cdo-Settings-SettingsAdapter-AdapterName'></a>
### AdapterName `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetBoolSetting-System-String-'></a>
### GetBoolSetting(settingFullCode) `method`

##### Summary

Get setting with [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetContext-System-Boolean-'></a>
### GetContext(loadNamespaces) `method`

##### Summary

Get setting context.

##### Returns

Setting context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loadNamespaces | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetIntSetting-System-String-'></a>
### GetIntSetting(settingFullCode) `method`

##### Summary

Get setting with [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetNamespace-System-String-'></a>
### GetNamespace(namespaceCode) `method`

##### Summary

Get [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace') by code.

##### Returns

[SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespaceCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetNamespaces(namespaceCodes) `method`

##### Summary

Get array [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace') by `namespaceCodes`.

##### Returns

array [SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespaceCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetPowerModeSetting-System-String-'></a>
### GetPowerModeSetting(settingFullCode) `method`

##### Summary

Get setting with [PowerMode](#T-GetcuReone-Cdm-Configuration-Settings-Enums-PowerMode 'GetcuReone.Cdm.Configuration.Settings.Enums.PowerMode') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSetting-System-String-'></a>
### GetSetting(settingFullCode) `method`

##### Summary

Get setting by code.

##### Returns

Settings

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

##### Remarks

With dot separated namespace names in code.

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingType-System-String-'></a>
### GetSettingType(settingTypeCode) `method`

##### Summary

Get setting type by code.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingTypeCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettingTypes(settingTypeCodes) `method`

##### Summary

Get setting types by codes.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingTypeCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | setting type codes. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettingTypes'></a>
### GetSettingTypes() `method`

##### Summary

Get all settig types.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettings(settingFullCodes) `method`

##### Summary

Get settings by codes.

##### Returns

Settings

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | Full customization codes. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-GetStringSetting-System-String-'></a>
### GetStringSetting(settingFullCode) `method`

##### Summary

Get setting with [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### SetDefaultSettings(settingFullCodes) `method`

##### Summary

Set default settings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCodes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSetting``1-System-String,``0-'></a>
### SetSetting\`\`1(settingFullCode,value) `method`

##### Summary

Set setting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |
| value | [\`\`0](#T-``0 '``0') | New setting value. |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSetting``1-System-String,``0,System-Globalization-CultureInfo-'></a>
### SetSetting\`\`1(settingFullCode,value,cultureInfo) `method`

##### Summary

Set setting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settingFullCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Full customization code. |
| value | [\`\`0](#T-``0 '``0') | New setting value. |
| cultureInfo | [System.Globalization.CultureInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Globalization.CultureInfo 'System.Globalization.CultureInfo') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}-'></a>
### SetSettings(request) `method`

##### Summary

Set settings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.Cdo.Settings.Entities.SetSettingsRequest}') |  |

<a name='M-GetcuReone-Cdo-Settings-SettingsAdapter-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType-'></a>
### ValidateSetting(setting,type) `method`

##### Summary

Setting validation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| setting | [GetcuReone.Cdm.Configuration.Settings.Setting](#T-GetcuReone-Cdm-Configuration-Settings-Setting 'GetcuReone.Cdm.Configuration.Settings.Setting') | Setting. |
| type | [GetcuReone.Cdm.Configuration.Settings.SettingType](#T-GetcuReone-Cdm-Configuration-Settings-SettingType 'GetcuReone.Cdm.Configuration.Settings.SettingType') | Setting type. |

<a name='T-GetcuReone-Cdo-Settings-SettingsErrorCode'></a>
## SettingsErrorCode `type`

##### Namespace

GetcuReone.Cdo.Settings

##### Summary

Error codes.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidConfig'></a>
### InvalidConfig `property`

##### Summary

Invalid config.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidSettingType'></a>
### InvalidSettingType `property`

##### Summary

Invalid setting type.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-InvalidSettingValue'></a>
### InvalidSettingValue `property`

##### Summary

Invalid setting value.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingNamespaceNotFound'></a>
### SettingNamespaceNotFound `property`

##### Summary

[SettingNamespace](#T-GetcuReone-Cdm-Configuration-Settings-SettingNamespace 'GetcuReone.Cdm.Configuration.Settings.SettingNamespace') not found.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingNotFound'></a>
### SettingNotFound `property`

##### Summary

[Setting](#T-GetcuReone-Cdm-Configuration-Settings-Setting 'GetcuReone.Cdm.Configuration.Settings.Setting') not found.

<a name='P-GetcuReone-Cdo-Settings-SettingsErrorCode-SettingTypeNotFaound'></a>
### SettingTypeNotFaound `property`

##### Summary

[SettingType](#T-GetcuReone-Cdm-Configuration-Settings-SettingType 'GetcuReone.Cdm.Configuration.Settings.SettingType') not found.

<a name='T-GetcuReone-Cdo-Settings-Facades-SettingsFacade'></a>
## SettingsFacade `type`

##### Namespace

GetcuReone.Cdo.Settings.Facades

##### Summary

Facade for settings.

<a name='P-GetcuReone-Cdo-Settings-Facades-SettingsFacade-FacadeName'></a>
### FacadeName `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-Cdo-Settings-Facades-SettingsFacade-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType-'></a>
### ValidateSetting(setting,settingType) `method`

##### Summary

Check if the setting matches the type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| setting | [GetcuReone.Cdm.Configuration.Settings.Setting](#T-GetcuReone-Cdm-Configuration-Settings-Setting 'GetcuReone.Cdm.Configuration.Settings.Setting') |  |
| settingType | [GetcuReone.Cdm.Configuration.Settings.SettingType](#T-GetcuReone-Cdm-Configuration-Settings-SettingType 'GetcuReone.Cdm.Configuration.Settings.SettingType') |  |

<a name='T-GetcuReone-Cdo-Settings-SettingsService'></a>
## SettingsService `type`

##### Namespace

GetcuReone.Cdo.Settings

##### Summary

Service for working with settings.

<a name='P-GetcuReone-Cdo-Settings-SettingsService-FactoryName'></a>
### FactoryName `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetBoolSetting-System-String-'></a>
### GetBoolSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetContext-System-Boolean-'></a>
### GetContext() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetIntSetting-System-String-'></a>
### GetIntSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetNamespace-System-String-'></a>
### GetNamespace() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetNamespaces-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetNamespaces() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetPowerModeSetting-System-String-'></a>
### GetPowerModeSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetSetting-System-String-'></a>
### GetSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetSettingType-System-String-'></a>
### GetSettingType() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetSettingTypes-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettingTypes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetSettingTypes'></a>
### GetSettingTypes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### GetSettings() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-GetStringSetting-System-String-'></a>
### GetStringSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-SetDefaultSettings-System-Collections-Generic-IEnumerable{System-String}-'></a>
### SetDefaultSettings() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-SetSetting``1-System-String,``0-'></a>
### SetSetting\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-SetSetting``1-System-String,``0,System-Globalization-CultureInfo-'></a>
### SetSetting\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-SetSettings-System-Collections-Generic-List{GetcuReone-Cdo-Settings-Entities-SetSettingsRequest}-'></a>
### SetSettings() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-Cdo-Settings-SettingsService-ValidateSetting-GetcuReone-Cdm-Configuration-Settings-Setting,GetcuReone-Cdm-Configuration-Settings-SettingType-'></a>
### ValidateSetting() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
