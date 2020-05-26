#
# Will try to generate the excel files using dll of the given RPG name.
#
# arg1 : The output fileName (without extension)
#

# CHECK arguments
if [ -z $TOOLS_EXE ] ; then 
	echo "Can't find TOOLS_EXE variable"
	exit
fi
if [ ! -f $TOOLS_EXE ] ; then 
	echo "Can't find TOOLS_EXEools executable at : $TOOLS_EXE"
	exit
fi
if [ -z $CURRENT_RPG_DLL ] ; then 
	echo "Can't find CURRENT_RPG_DLL variable"
	exit
fi
if [ ! -f $CURRENT_RPG_DLL ] ; then 
	echo "Can't find RPG Dll at : $CURRENT_RPG_DLL"
	exit
fi
if [ -z $1 ] ; then 
	echo "Must have first argument : the output file name for the exported Excel file"
	exit
fi
if [ ! -d $(dirname $1) ] ; then 
	echo "Can't find Output directory : $(dirname $1)"
	read -p "Want you to create it now? y/n" yn
	if [ ${yn,,} == "y" ] ; then
		mkdir -p $(dirname $1)
	else
		exit
	fi
fi

# CALL EXECUTABLE
$TOOLS_EXE canvas "$CURRENT_RPG_DLL" "$1.xlsx"