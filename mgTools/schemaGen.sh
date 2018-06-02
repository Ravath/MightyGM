#
#
# Generates the sql schema of the given RPG using the generated script.
#
# Arg1 : The name of the RPG, as in the Repertory name in the project.
#
#
#

if [ -z $1 ] ; then
	echo "Must pass Arg1: jdr Name"
	exit
fi

jdrName=$1

# goes in the RPG folder
if [ -d "$MIGHTY_GM_DIR/$jdrName" ] ; then
	cd "$MIGHTY_GM_DIR/$jdrName"
else
	echo "Folder $MIGHTY_GM_DIR/$jdrName doesn't exists"
	exit
fi

# generates schema using SQL script
if [ -f "SQL/SqlGeneration.sql" ] ; then
	psql --host=localhost --port=5432 --dbname=MightyGM --username=postgres -c "\i ./SQL/SqlGeneration.sql"
else
	echo "SQL/SqlGeneration.sql doesn't exists"
	exit
fi
