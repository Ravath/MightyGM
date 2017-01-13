// ==========================================================================
//  GPPG definition file
// ==========================================================================
//  Version:  1.0.0
//  Machine:  EHLION-MSI
//  DateTime: 01/12/2016 16:37:27
//  UserName: Ehlion
// ==========================================================================
%{
	string section;
	RawAttribute curAtt = new RawAttribute();
	RawTable curTable = new RawTable();
%}

%start MAIN
%partial
%namespace DataGenerator2
%using System.Linq
%visibility internal

%union { public double dVal; 
         public char cVal; 
         public int iVal; 
		 public string sVal;}

%token <sVal> LETTER
%token SPACE
%type <sVal> idName
%type <sVal> underscores
%type <sVal> cardSymbol

%%
//=====================MAIN=====================
MAIN
	:   /*empty */
	|  	declarationDatabase 
			change newSection change
		allDataTables
			{
				
			}
	|   MAIN error '\n'
			{
				yyerrok();
			}
	;	
//=====================TOKENS=====================
spaces
	: SPACE
	| spaces SPACE
	;
change
	: /*empty*/
	| spaces
	;
underscores
	: '_' { $$ = "_";}
	| '_' underscores {$$ = "_" + $2;}
	;
newSection
	: '%' '%'
	;
idName
	: LETTER 		{ $$ = $1; }
	| idName LETTER { $$ = $1 + $2; }
	| idName underscores idName {  $$ = $1 + $2 + $3; }
	;
cardSymbol
	: LETTER { $$ = $1; }
	| '*' { $$ = "*"; }
	;
//=====================Database=====================
databaseCall
	: idName 
		{
			if($1!="database")
				throw new ParserException("Received "+$1+ " but `database` was expected");
		}
	;
declarationDatabase
	: databaseCall spaces idName { RawData.DatabaseName = $3; }
	;
//=====================TABLE LEAFS=====================
tableType
	: change idName { curTable.Type = $2; }
	;
tableName
	: change idName { curTable.Name = $2; }
	;
tags
	: idName { curTable.MinorTags.Add($1); }
	| tags change ',' change idName { curTable.MinorTags.Add($5); }
	;
minorTags
	: /*empy*/ 
	| '&' '[' change tags change ']'
	;
majorTag
	: '[' change idName change ']' { curTable.MajorTag = $3; }
	| /*optionnal*/
	;
//=====================ATTRIBUTES LEAFS=====================
cardinalite
	: change '[' cardSymbol change '-' change cardSymbol ']' 
		{
			curAtt.CardMin = $3;
			curAtt.CardMax = $7;
		}
	;
targetAttribute
	: '(' change idName change ')' { curAtt.Target = $3; }
	;
sectionName
	: '%' change idName change ':' { section = $3; }
	;
cardinaliteAndTargetAttribute
	: cardinalite change targetAttribute change 
	| cardinalite change 
	| targetAttribute change 
	;
//=====================Declaration attributs=====================
attributeDef
	: idName change { curAtt.Name = $1; }
	| idName spaces idName  change { curAtt.Type = $1; curAtt.Name = $3; }
	| idName change '(' change idName change ')' change idName change  { curAtt.Type = $1; curAtt.TypeTag = $5; curAtt.Name = $9; }
	;
attribute
	: attributeDef change 
	| attributeDef change cardinaliteAndTargetAttribute change 
	;
oneOrMultipleAttributes
	: attribute  change { curAtt.Section = section; curTable.Attributes.Add(curAtt); curAtt = new RawAttribute(); }
	| oneOrMultipleAttributes change ',' change attribute  change { curAtt.Section = section; curTable.Attributes.Add(curAtt); curAtt = new RawAttribute(); }
	;
section
	: sectionName change 
	| oneOrMultipleAttributes change 
	| sectionName change oneOrMultipleAttributes change 
	;
allAttributesSection
	: change /* nothing */ 
	| section change 
	| allAttributesSection change section change 
	;
//=====================Declaration table=====================
changeTable
	: change
	| changeTable newSection change
	;
allDataTables
	: /*empty*/
	| declarationDataTable { RawData.RawTables.Add(curTable); curTable = new RawTable(); section = ""; }
	| allDataTables changeTable declarationDataTable { RawData.RawTables.Add(curTable); curTable = new RawTable(); section = "";  }
	;
declarationDataTable
	: tableType spaces tableName change majorTag change minorTags change '(' change
		allAttributesSection
	  change ')'
	;