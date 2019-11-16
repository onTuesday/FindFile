grammar Request;

options
{
	language = CSharp2;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }

@members
{
	String NAME = file.Name;
	long LENGTH = file.Length;
	String CONTENT = file.Content;
}

request	
	: statement
	;

statement
	: boolexpr NEWLINE { Console.WriteLine($boolexpr.value); }
	;

boolexpr returns[bool value]
	: e1=expr { $value = e1; }
	('&' e2=expr { $value &= $e2.value; }
	|'|' e3=expr { $value |= $e3.value; }
	|'^' e4=expr { $value = !$e4.value; } )*
	;

expr returns[bool value]
  : ( '('? eName     = exprName     {$value = eName;}    ')'? )*
  | ( '('? eLength   = exprLength   {$value = eLength;}  ')'? )*
  | ( '('? eContent  = exprContent  {$value = eContent;} ')'? )*
 
  | '(' boolexpr ')' {$value = $boolexpr.value;}
  ;

exprName returns[bool value]
  :
	'Name' MASK_SIGN '"' NAME_SYMBOLS '"'
	{
		if (MASK_SIGN == "=")
		{
			$value = (NAME == NAME_SYMBOLS);
		}
		
		if (MASK_SIGN == "~")
		{
			$value = (NAME == NAME_SYMBOLS);
		}
	}
  ;

exprLength returns[bool value]
  :
	LENGTH_SYMBOLS EQUAL_SIGN 'Length'
	{
		$value = (LENGTH_SYMBOLS EQUAL_SIGN LENGTH);
	} 
  
  |
	LENGTH_SYMBOLS EQUAL_SIGN 'Length'
	{
		$value = (LENGTH EQUAL_SIGN LENGTH_SYMBOLS)
	} 
  ;

exprContent returns[bool value]
  :
	'Content' '~' '"' CONTENT_SYMBOLS '"'
	{
		$value = ();
	}
  ;

MASK_SIGN
	: '='
	| '~'
	;

EQUAL_SIGN
	: '='
	| '>'
	| '<'
	| '<='
	| '>='
	;

NAME_SYMBOLS
	: 'a'..'z''A'..'Z''0'..'9''?''*'+ '.' 'a'..'z''A'..'Z''0'..'9''?''*'+
	;
	
LENGTH_SYMBOLS
	: '0'..'9'+
	;

CONTENT_SYMBOLS
	: 'a'..'z''A'..'Z''0'..'9''?''*'+
	;

NEWLINE
	: '\r'? '\n'
	;