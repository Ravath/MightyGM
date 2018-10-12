#
# Loads The MightyGm working environment.
#
#
# In order to use this script, user have to define $MIGHTY_GM_DIR as an environment variable pointing to the MightyGm project directory.
# Then, call the script with the 'source' cmd : "source $MIGHTY_GM_DIR/mgTools/loadBashProfile.sh"
#
#

## MIGHTY GM VARIABLES ##
export MIGHTY_GM_TOOLS_DIR="$MIGHTY_GM_DIR/mgTools" 
export CURRENT_RPG_DLL=""   # Updated by setRpgDll.sh script
export TOOLS_EXE="" 		# Updated by setMgTools.sh script


## HANDY COMMANDS ##
alias gomi='cd "$MIGHTY_GM_DIR"'


## MIGHTY GM ALIASES : ENVIRONMENT ##
alias loadMgAlias='source "$MIGHTY_GM_TOOLS_DIR/loadBashProfile.sh"'
alias setMgTools='source "$MIGHTY_GM_TOOLS_DIR/setMgTools.sh"'
alias setRpgDll='source "$MIGHTY_GM_TOOLS_DIR/setRpgDll.sh"'
## MIGHTY GM ALIASES : SCRIPTS ##
alias dataGen='"$MIGHTY_GM_TOOLS_DIR/dataGen.sh"'
alias schemaGen='"$MIGHTY_GM_TOOLS_DIR/schemaGen.sh"'
alias excelGen='"$MIGHTY_GM_TOOLS_DIR/excelGen.sh"'
alias excelImport='"$MIGHTY_GM_TOOLS_DIR/excelImport.sh"'
alias excelImportAll='"$MIGHTY_GM_TOOLS_DIR/excelImportAll.sh"'
alias excelImportJoint='"$MIGHTY_GM_TOOLS_DIR/excelImportJoint.sh"'
alias excelCheck='"$MIGHTY_GM_TOOLS_DIR/excelCheck.sh"'

## COMMANDS MISC ##
alias gppg='"$MIGHTY_GM_TOOLS_DIR/Gppg.exe"'
alias roll='"$MIGHTY_GM_TOOLS_DIR/../Dice/bin/Debug/Dice.exe"'


## UPDATE ##
setMgTools -d
setRpgDll CinqAnneaux -d

## BACK TO ROOT ##
gomi