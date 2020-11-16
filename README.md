# GetcuReone.Cdo.Settings

Common domain operations for setting API.

[![NuGet version (GetcuReone.Cdo.Settings)](https://img.shields.io/nuget/v/GetcuReone.Cdo.Settings.svg?style=flat-square)](https://www.nuget.org/packages/GetcuReone.Cdo.Settings/)
[![Build status](https://dev.azure.com/GetcuReone-Studio/OpenSource-Projects/_apis/build/status/master-GetcuReone.Cdo.Settings?branchName=master)](https://dev.azure.com/GetcuReone-Studio/OpenSource-Projects/_build/latest?definitionId=39)

## Configuration

To use the library you need to add to the configuration file:

- **GetcuReone_Settings_SettingTypesFile**. Indicates the location of the file in which the types of settings are located.

- **GetcuReone_Settings_SettingsFolder**. Contains the path to the folder where the settings files are located.

- **GetcuReone_Settings_TemplateSettingFile**. Settings file name template.

## Type addition

In order to add your type you need to define it in the file with types.

The configuration type structure can be seen [here][setting_type].

An example can be seen [here][example_setting_type].

## PS:

Please note that the codes are not case sensitive.

- [NuGet Package](https://www.nuget.org/packages/GetcuReone.Cdo/)
- [License](LICENSE.txt)

[example_setting_type]: https://github.com/GetcuReone/GetcuReone.Cdo.Settings/blob/master/GetcuReone.Cdo.Settings/GetcuReone.Cdo.Settings/settings/gr_setting_types.xml "GetcuReone_SettingTypes.xml"
[setting_type]: https://github.com/GetcuReone/GetcuReone.Cdm/blob/master/GetcuReone.Cdm/GetcuReone.Cdm/Configuration/Settings/SettingType.cs "SettingType"
