#
# WIll try to generate the excel files using dll of the given RPG name.
#
# arg1 : Name of the RPG to generate.
# arg2 : The output fileName (without extension)
#

if [ -z $1 ] ; then 
	echo "Must pass Arg1 : Rpg Name"
	exit
fi
if [ -z $2 ] ; then 
	echo "Must pass Arg2 : File OutPath"
	exit
fi

jdrName=$1
outputName=$2


# Checks the RPG folder exists
if [ ! -d "$MIGHTY_GM_DIR/$jdrName" ] ; then
	echo "Folder $MIGHTY_GM_DIR/$jdrName doesn't exists"
	exit
fi

# Checks the generated dlls. (get Release First)
jdrDll="$MIGHTY_GM_DIR/$jdrName/bin/Release/$jdrName.dll"
if [ ! -f "$jdrDll" ] ; then
	jdrDll="$MIGHTY_GM_DIR/$jdrName/bin/Debug/$jdrName.dll"
	
	if [ ! -f "$jdrDll" ] ; then
		echo "Dll not found"
		exit
	else
		echo "uses Debug/$jdrName.exe"
	fi
else
	echo "uses Release/$jdrName.exe"
fi

# Get the mgTool Exe. (get Release First)
toolExe="$MIGHTY_GM_DIR/mgTools/bin/Release/mgTools.exe"
if [ ! -f "$toolExe" ] ; then
	toolExe="$MIGHTY_GM_DIR/mgTools/bin/Debug/mgTools.exe"
	
	if [ ! -f "$toolExe" ] ; then
		echo "mgTools.exe not found"
		exit
	else
		echo "uses Debug/mgTools.exe"
	fi
else
	echo "uses Release/mgTools.exe"
fi

#Execute
$toolExe canvas $jdrDll $outputName.xlsx