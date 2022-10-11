---
wip: 6204
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: High-DPI support for Bundles
draft: false
---

## User stories

* As a Setup developer I can create DPI aware bundles such that my UI can look crisp and clear on all devices.


## Proposal

Remove the static .exe manifest from the Burn stub.
Get the Burn backend to generate the .exe manifest and embed it into the Bundle.
Add new `DpiAwareness` attribute to the `BootstrapperApplication` element to allow the Bundle to declare its supported DPI awareness mode(s).

    <xs:attribute name="DpiAwareness" default="perMonitorV2">
        <xs:annotation>
            <xs:documentation>The DPI awareness of the BootstrapperApplication. The default is 'perMonitorV2'. Microsoft High DPI documentation is at https://docs.microsoft.com/en-us/windows/win32/hidpi/high-dpi-desktop-application-development-on-windows.</xs:documentation>
        </xs:annotation>
        <xs:simpleType>
            <xs:restriction base="xs:NMTOKEN">
                <xs:enumeration value="gdiScaled">
                    <xs:annotation>
                        <xs:documentation>Corresponds to the .exe manifest element 'gdiScaling' with content of 'true'. Windows does not support combining this with other DPI awareness modes.</xs:documentation>
                    </xs:annotation>
                </xs:enumeration>
                <xs:enumeration value="perMonitor">
                    <xs:annotation>
                        <xs:documentation>Corresponds to the .exe manifest element 'dpiAware' with content of 'true/pm'.</xs:documentation>
                    </xs:annotation>
                </xs:enumeration>
                <xs:enumeration value="perMonitorV2">
                    <xs:annotation>
                        <xs:documentation>Corresponds to the .exe manifest element 'dpiAwareness' with content of 'PerMonitorV2, PerMonitor' and the manifest element 'dpiAware' with content of 'true/pm'.</xs:documentation>
                    </xs:annotation>
                </xs:enumeration>
                <xs:enumeration value="system">
                    <xs:annotation>
                        <xs:documentation>Corresponds to the .exe manifest element 'dpiAware' with content of 'true'.</xs:documentation>
                    </xs:annotation>
                </xs:enumeration>
                <xs:enumeration value="unaware" />
            </xs:restriction>
        </xs:simpleType>
    </xs:attribute>


## Considerations

Declaring a single enum attribute for the DPI awareness mode prevents some possible configurations, such as declaring support for `PerMonitorV2` and `System` but not `PerMonitor`.
These configurations don't really make sense.

The other way of implementing dynamic DPI awareness modes is for the Burn engine to set the DPI awareness programmatically.
Although this is supported by Microsoft, they do not recommend it due to Windows requiring this be done before creating any windows. 


## See Also

* [WIXFEAT:6204](https://github.com/wixtoolset/issues/issues/6204)
