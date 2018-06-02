
# Argument 1: The file to generate
#	The script will look for the files in name relative to 'DataGenerator/bin'

bin="$MIGHTY_GM_DIR/DataGenerator/bin"
folder="$bin"
cd "$folder"

forceDebug=false
if [ "$2" == "-d" ] ; then
	forceDebug=true
	echo forceDebug
fi
file=$1

# Get GENERATOR

if [ -f "Release/DataGenerator.exe" ] && [ $forceDebug == "false" ] ; then
	generator="Release/DataGenerator.exe"
	folder="$folder/Release"
elif  [ -f "Debug/DataGenerator.exe" ] ; then
	generator="Debug/DataGenerator.exe"
	folder="$folder/Debug"
else
	echo "dataGen not found"
	exit
fi

echo $generator

# Get FILE

if [ ! -f "$file" ] ; then
	echo "$file not found"
	exit
fi

echo $file

# Get DATABASE NAME

databaseName=$(cat $file | grep database)
databaseName=${databaseName##* }
databaseName=$(echo "$databaseName" | tr -d [:space:])

if [ -z "$databaseName" ] ; then
	echo "Database Name not found"
	exit
else
	echo "Database=$databaseName"
	folder="$folder/$databaseName"
fi

# supprimer ancien dossier
if [ -d "$folder" ] ; then
	echo "removing $folder"
	rm -r "$folder"
fi
if [ -d "$databaseName" ] ; then
	echo "removing $databaseName"
	rm -r "databaseName"
fi

#GENERATE
"$generator" "$file"
if [ ! -d "$databaseName" ] ; then
	pwd
	ls -l
	echo $folder
	echo "can't find directory $databaseName"
	echo "Data has not been generated"
	exit
fi
mv "$databaseName" "$folder"

#UPDATE Files
cd "$MIGHTY_GM_DIR"
if [ ! -d "$databaseName" ] ; then
	mkdir "$databaseName"
fi
if [ ! -d "$databaseName/UserMade" ] ; then
	mkdir "$databaseName/UserMade"
fi
#replace 'Generated' repository
if [ -d "$databaseName/Generated" ] ; then
	rm -r "$databaseName/Generated"
fi
cp -r "$folder/Generated" "$databaseName/Generated"
#replace 'SQL' repository
if [ -d "$databaseName/SQL" ] ; then
	rm -r "$databaseName/SQL"
fi
cp -r "$folder/SQL" "$databaseName/SQL"
#remove unused userfiles
ls "$databaseName/UserMade" > files.temp
while read userFile ; do
	if [ ! -f "$folder/UserMade/$userFile" ] ; then
		echo "Delete File: $userFile"
		rm -f "$databaseName/UserMade/$userFile"
	fi
done < files.temp
#copy new userfiles
ls "$folder/UserMade" > files.temp
while read userFile ; do
	if [ ! -f "$databaseName/UserMade/$userFile" ] ; then
		echo "New File: $userFile"
		cp "$folder/UserMade/$userFile" "$databaseName/UserMade"
	fi
done < files.temp
rm -f files.temp
