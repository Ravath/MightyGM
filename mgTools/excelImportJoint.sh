#
# Import the excel file using dll of the given RPG name.
#
# arg1 : The input Excel fileName
#
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
	echo "Must have first argument : the path to the Excel file to import"
	exit
fi
if [ ! -f $1 ] ; then 
	echo "Can't find excel file at : $1"
	exit
fi

# CALL EXECUTABLE
$TOOLS_EXE excel importjoint "$CURRENT_RPG_DLL" "$1"