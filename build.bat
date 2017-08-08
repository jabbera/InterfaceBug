@echo off

mkdir binworking
mkdir binnotworking

echo "Cleaning binaries"
del binworking\*.exe
del binworking\*.dll
del binnotworking\*.dll
del binnotworking\*.exe


echo "Building working version"

echo "Compiling base lib to binworking"
csc /out:binworking\baseclasses.dll /target:library baseclasses\TroubleClass.cs baseclasses\ITroubleInterface.NoBug.cs baseclasses\TestBase.cs
echo "Compiling derived lib to binworking"
csc /out:binworking\derivedclasses.dll /target:library /reference:binworking\baseclasses.dll derivedclasses\*.cs 
echo "Compiling driver lib to binworking"
csc /out:binworking\consoledriver.exe /target:exe /reference:binworking\derivedclasses.dll consoledriver\*.cs

echo "Demoing working app"
binworking\consoledriver.exe

echo "Copying binaries to binnotworking"
copy binworking\*.* binnotworking\

del binnotworking\baseclasses.dll
del binnotworking\baseclasses.pdb

echo "Rebuilding baseclasses.dll into binnotworking with IDerivedWorking.QueryContext commented out"
echo "This should be a non breaking change to both consoledriver.exe and deriveddll.dll since they do not use this interface directly or indirectly."
csc /out:binnotworking\baseclasses.dll /target:library baseclasses\TroubleClass.cs baseclasses\ITroubleInterface.Bug.cs baseclasses\TestBase.cs

echo "Demoing failing app"
binnotworking\consoledriver.exe