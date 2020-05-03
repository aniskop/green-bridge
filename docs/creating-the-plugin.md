---
title: "Creating the plug-in"
layout: page
---

Usually a process of creating a PL/SQL Developer plug-in involves:
1. Registering the plug-in within PL/SQL Developer (store the plug-in ID, return plug-in name).
2. Creating menu items for the plug-in.
3. Registering the callbacks required by the plug-in to operate.
4. Declaring and exporting `public static` methods to interact with the PL/SQL Developer.

GreenBridge framework addresses these steps.

## Structure of the plug-in

The typical structure of the plug-in created with the GreenBridge framework:
* `YourPluginFacade` class &ndash; via this class PL/SQL Developer calls your plug-in. This is the `public` class which contains `public static` methods exported to the outer world. Also has a `static` attribute to store the instance of `YourPlugin`.
* `YourPlugin` class &ndash; the class helps in routine task like getting plug-in ID, name, creating menu, registering callbacks, handling menu clicks.

These are the main classes which should be present in your plug-in. Feel free to use more classes &ndash; there are no restrictions.

Another key player is `PlsqlDeveloperFacade` class (part of the GreenBridge framework, not your plug-in). Your plug-in calls PL/SQL Developer API via this class. Your plug-in gets access to the instance of the `PlsqlDeveloperFacade` via `PlsqlDeveloperPlugin` class, `PlsqlDeveloper` property.

The [ColorSplash plug-in](https://github.com/aniskop/color-splash-plugin) is the first one created using the GreenBridge framework. You can use it as a refrence example.

In the examples below `Me` is the reference to the `YourPlugin` object instance.

----
**IMPORTANT**  
`YourPluginFacade` class cannot inherit `PlsqlDeveloperPlugin` class because then `public static` methods are not exported. At least, hey are not exported by the UnmanagedExports.Repack tool.

----

## How to...

**Register the plug-in**  
`YourPluginFacade` calls `YourPlugin()` constructor, providing the plug-in ID and the name.
```csharp
[DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
public static string IdentifyPlugIn(int id)
{
    Me = new ColorSplashPlugin(id, "Color Splash (IDE color settings)");
    return Me.Name;
}
```

**Register the callbacks**  
First, `YourPlugin` must specify the required callbacks in the `RequiredCallbacks` property. Constructor is the right place to do so. All callbacks IDs are stored in the `GreenBridge.Core.Callback` class.
```csharp
RequiredCallbacks = new int[] { Callback.IDE_GET_GENERAL_PREF,
                                Callback.IDE_GET_PERSONAL_PREF_SETS,
                                Callback.IDE_GET_PREF_AS_STRING };
```

Then `YourPluginFacade` calls `YourPlugin.RegisterRequiredCallback` method, which will register all callbacks listed in the `RequiredCallbacks`.
```csharp
[DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
public static void RegisterCallback(int index, IntPtr func)
{
    Me.RegisterRequiredCallback(index, func);
}
```

**Create the menu**  
First, `YourPlugin` must define the structure of the menu and click handlers via `Menu` attribute. See [Working with menu]() for more details. Constructor of `YourPlugin` is the right place to create menu.
```csharp
Menu = new PlsqlDeveloperMenuBuilder().Group("Appearance").Item("Customize", Customize_Click).Build();
```

Then `YourPluginFacade` passes this structure to the PL/SQL Developer.
```csharp
[DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
public static string CreateMenuItem(int index)
{
    return Me.Menu.Entry(index).ToString();
}
```

**Handle the menu click**  
`YourPluginFacade` calls `Menu.HandleClick` method, which will call the handler, that was specified at the time of menu creation.
```csharp
[DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
public static void OnMenuClick(int index)
{
    Me.Menu.HandleClick(index);
}
```

## Learn by example

The plug-in:
```csharp
public class ColorSplashPlugin : PlsqlDeveloperPlugin
{
    public ColorSplashPlugin(int id, string name) : base(id, name)
    {
        // The callbacks required by the plug-in
        RequiredCallbacks = new int[] { Callback.IDE_GET_GENERAL_PREF,
                                        Callback.IDE_GET_PERSONAL_PREF_SETS,
                                        Callback.IDE_GET_PREF_AS_STRING };
        Menu = new PlsqlDeveloperMenuBuilder().Group("Appearance").Item("Customize", Customize_Click).Build();
    }
    private void Customize_Click(object sender, MenuEntryClickEventArgs e)
    {
        // Handles menu click.
        // More is covered in "Wirking with menu".
    }
}
```

The facade:
```csharp
public class ColorSplashPluginFacade
{
    private static ColorSplashPlugin Me;

    [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
    public static string IdentifyPlugIn(int id)
    {
        Me = new ColorSplashPlugin(id, "Color Splash (IDE color settings)");
        return Me.Name;
    }

    [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
    public static string CreateMenuItem(int index)
    {
        return Me.Menu.Entry(index).ToString();
    }
    
    [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
    public static void OnMenuClick(int index)
    {
        Me.Menu.HandleClick(index);
    }

    [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
    public static void RegisterCallback(int index, IntPtr func)
    {
        Me.RegisterRequiredCallback(index, func);
    }
}
```