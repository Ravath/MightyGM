#
# Create a new RPG project.
#
# arguments :
#	1 : RPG Name
#	2 : Localisation of the generated files
#

if [ ! -d "$2" ] ; then
	echo "'$2' doesn't exists"
	exit
fi

RPG_NAME=${1:-TEST}
FILES_FOLER="$2"

NAME_TAG=Unbound
COMPILE_LIST_TAG=TEMPLATE_LIST
TEMPLATE_DIR=${MIGHTY_GM_TOOLS_DIR}/ProjectTemplate

# create basic repos
if [ -d ${MIGHTY_GM_DIR}/$RPG_NAME ] ; then
	echo "${MIGHTY_GM_DIR}/$RPG_NAME already exist"
	exit 1
fi
cp -R $TEMPLATE_DIR ${MIGHTY_GM_DIR}/$RPG_NAME
mv ${MIGHTY_GM_DIR}/$RPG_NAME/$NAME_TAG.csproj ${MIGHTY_GM_DIR}/$RPG_NAME/$RPG_NAME.csproj
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/bin
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/bin/Debug
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/bin/Release
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/obj
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/obj/Debug
mkdir ${MIGHTY_GM_DIR}/$RPG_NAME/JdrCore


for file in $(find ${MIGHTY_GM_DIR}/$RPG_NAME -name "*" -type f)
do
	echo $file
	sed -i -e "s/$NAME_TAG/$RPG_NAME/g" $file
done

FILE_LIST="<Compile Include=\"Langues\\\\Fr.Designer.cs\">\r\t\t<DependentUpon>Fr.resx</DependentUpon>\r\t\t<AutoGen>True</AutoGen>\r\t\t<DesignTime>True</DesignTime>\r\t</Compile>\r\t<Compile Include=\"LocalContext.cs\" />"

pushd "$FILES_FOLER"
for rep in Generated UserMade
do
	pushd $rep
	for file in *
	do
		FILE_LIST="$FILE_LIST\r\t<Compile Include=\"$rep\\\\$file\" />"
	done
	popd
done
popd

sed -i -e "s@$COMPILE_LIST_TAG@$FILE_LIST@g" ${MIGHTY_GM_DIR}/$RPG_NAME/$RPG_NAME.csproj

unset FILE_LIST
unset rep
unset file