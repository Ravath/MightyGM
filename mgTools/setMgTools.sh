#
# Get the MgTool Executable.
#
# arguments : 
#	1 : -d to force debug executable.
#		Default : try to get release, and use debug if release is not found.
#

bin="$MIGHTY_GM_DIR/mgTools/bin"
cd "$bin"

# ARGUMENT 1 (opt) : use debug Dll
forceDebug=false
if [ "$1" == "-d" ] ; then
	forceDebug=true
	echo forceDebug
fi

# Try and get executable
if [ -f "Release/mgTools.exe" ] && [ $forceDebug == "false" ] ; then
	bin="$bin/Release/mgTools.exe"
elif  [ -f "Debug/mgTools.exe" ] ; then
	bin="$bin/Debug/mgTools.exe"
else
	echo "mgTools executable not found"
	exit
fi

# SUCCESSFUL : every one should know
echo "TOOLS_EXE=$bin"
export TOOLS_EXE="$bin"