grammar Request1;

request1
	: statement
	;

statement
	: boolexpr NEWLINE
	;

boolexpr returns
	: expr
	('&' expr
	|'|' expr
	|'^' expr)*
	;

expr
  : ( '('? exprName ')'? )*
  | ( '('? exprLength ')'? )*
  | ( '('? exprContent ')'? )*
 
  | '(' boolexpr ')'
  ;

exprName
  : 'Name' MASK_SIGN '"' NAME_SYMBOLS '"'
  ;

exprLength
  : LENGTH_SYMBOLS EQUAL_SIGN 'Length'
  | 'Length' EQUAL_SIGN LENGTH_SYMBOLS
  ;

exprContent
  : 'Content' '~' '"' CONTENT_SYMBOLS '"'
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