#
# Get the RPG Dll.
#
# arguments :
#	1 : RPG Name
#	2 : -d to force debug executable.
#		Default : try to get release, and use debug if release is not found.
#

# ARGUMENT 1 : The Rpg Name
if [ -z $1 ] ; then 
	echo "Must pass Arg1 : Rpg Name"
	exit
fi
jdrName=$1

# ARGUMENT 2 (opt) : use debug Dll
forceDebug=false
if [ "$2" == "-d" ] ; then
	forceDebug=true
	echo forceDebug
fi


# Checks the RPG folder exists
if [ ! -d "$MIGHTY_GM_DIR/$jdrName" ] ; then
	echo "Folder $MIGHTY_GM_DIR/$jdrName doesn't exists"
	exit
fi

# Try and get executable
if [ -f "$MIGHTY_GM_DIR/$jdrName/bin/Release/$jdrName.dll" ] && [ $forceDebug == "false" ] ; then
	jdrDll="$MIGHTY_GM_DIR/$jdrName/bin/Release/$jdrName.dll"
elif  [ -f "$MIGHTY_GM_DIR/$jdrName/bin/Debug/$jdrName.dll" ] ; then
	jdrDll="$MIGHTY_GM_DIR/$jdrName/bin/Debug/$jdrName.dll"
else
	echo "$jdrName dll not found"
	exit
fi

# SUCCESSFUL : every one should know
echo "CURRENT_RPG_DLL=$jdrDll"
export CURRENT_RPG_DLL="$jdrDll"