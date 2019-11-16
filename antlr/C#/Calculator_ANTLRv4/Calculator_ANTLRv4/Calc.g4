grammar Calc;

options
{
	language = CSharp2;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }

@header{
	using System;
	using System.Collections;
}

@members{
	Hashtable memory = new Hashtable();
}

calc	
	: statement+
	;

statement
	: expr NEWLINE { Console.WriteLine($expr.value); }
	| ID '=' expr NEWLINE { memory.Add($ID.text, $expr.value); }
	| NEWLINE
	;

expr returns[int value]	
	: me1=multExpression {$value = $me1.value;}
	('+' me2=multExpression {$value += $me2.value;}
	|'-' me2=multExpression {$value -= $me2.value;})*
	;

multExpression returns[int value]
	: a1=atom {$value = $a1.value;}
	('*' a2=atom {$value *= $a2.value;}
	|'/' a2=atom {$value /= $a2.value;})*
	;

atom returns[int value]
	: ID {$value = (int)memory[$ID.text];}
	| INT {$value = int.Parse($INT.text);}
	| '(' expr ')' {$value = $expr.value;}
	;

NEWLINE : '\r'? '\n'
	;

ID
	: 'a'..'z'+
	;

INT
	: '0'..'9'+
	;