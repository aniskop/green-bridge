---
# Feel free to add content and custom Front Matter to this file.
# To modify the layout, see https://jekyllrb.com/docs/themes/#overriding-theme-defaults

layout: page
homepage: true
title: "GreenBridge"
description: "PL/SQL Developer plug-ins development framework"
---
**GreenBridge** is the framework for developing PL/SQL Developer plug-ins in C#. The major goal of the framework is to help the developer get rid of routine tasks or make some tasks easier when creating the plug-in. The routine tasks are:
* Declaring delegates for PL/SQL Developer callback functions.
* Registering callbacks.
* Creating the plug-in menu and handling menu clicks.

## Framework structure

The framework provides 2 main classes:
1. `GreenBridge.Core.PlsqlDeveloperFacade` &ndash; a wrapper for PL/SQL Developer API. This class actually contains all the delegates for the PL/SQL Developer callbacks and the wrapper-methods. The methods of the class have the same name as PL/SQL Developer callback functions to keep straightforward mapping and make it easy to find the documentation on the right callback. Your plug-in has access to the _facade_ via `PlsqlDeveloper` property of the `PlsqlDeveloperPlugin` class.
2. `GreenBridge.Core.PlsqlDeveloperPlugin` &ndash; a class which reflects the structure of the PL/SQL Developer plug-in and provides an API for routine tasks. Your plug-in has to inherit this class.
