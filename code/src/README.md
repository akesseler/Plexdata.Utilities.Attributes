## Project Build

Best way to build the whole project is to use _Visual Studio 2019 Community_. Thereafter, 
download the complete sources, open the solution file `Plexdata.Utilities.Attributes.sln`, 
switch to release and rebuild all.

## Help Generation

The help file of type CHM is generated during release build process only. The `MSBuild.exe` 
utility is used for this purpose. The help project file `Plexdata.Utilities.Attributes.help.shfbproj` 
has been made using [Sandcastle Help File Builder](http://ewsoftware.github.io/SHFB). The 
final help file with name `Plexdata.Utilities.Attributes.chm` is automatically put into the 
release sub-folder after a successful build.

You can disable the help file generation, if you like, by opening the _Project Settings_ and 
moving to tab _Build Events_. There you simply clear out the content of box _Post-build event 
command line_.

## Breaking Changes

None at the moment.

## Trouble Shooting

If you get an error during release build you may need to install the _Sandcastle Help File 
Builder_ manually and edit the help project file `Plexdata.Utilities.Attributes.help.shfbproj`.

On the other hand, if you get an error that states something like `MSBuild.exe not found`, 
then you may need to correct the path of `MSBuild.exe` inside file `post-build.cmd`.

## Known Issues

Nothing known at the moment.
