grammar Mask;

options
{
	language = CSharp;
}
@parser::namespace { Generated }
@lexer::namespace  { Generated }

@header
{
	using System;
	using System.Text;
	using System.Text.RegularExpressions;
}

@members
{
	String NAME	= Program.Name;
    UInt64 LENGTH = Program.Length;
    String CONTENT = Program.Content;

	bool IfFitsToNamemask(String Name, String Mask)
	{
		Regex mask = new Regex(Mask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
		return mask.IsMatch(Name);
	}
}

mask
	: statement
	;

statement
	: boolexpr  { Program.final = $boolexpr.value; }
	;

boolexpr returns[bool value]
	: e1 = expr { $value = $e1.value; }
	('&' e2 = expr { $value &= $e2.value; }
	|'|' e3 = expr { $value |= $e3.value; }
	|'^' e4 = expr { $value = !$e4.value; } )*
	;

expr returns[bool value]
	: ( '('? eName     = exprName     {$value = $eName.value;}    ')'? )*
	| ( '('? eLength   = exprLength   {$value = $eLength.value;}  ')'? )*
	| ( '('? eContent  = exprContent  {$value = $eContent.value;} ')'? )*
 
	| '(' boolexpr ')' {$value = $boolexpr.value;}
	;

exprName returns[bool value]
	: 'Name' '=' '\'' NAME_SYMBOLS '\'' { $value = (NAME == $NAME_SYMBOLS.text); }
	| 'Name' '~' '\'' NAME_SYMBOLS '\''{ $value = IfFitsToNamemask(NAME, $NAME_SYMBOLS.text); }
	;

exprLength returns[bool value]
	: LENGTH_SYMBOLS EQUAL_SIGN 'Length'
	{
		if ($EQUAL_SIGN.text == "=")
		{
			$value = (UInt64.Parse($LENGTH_SYMBOLS.text) == LENGTH);
		}

		if ($EQUAL_SIGN.text  == "<")
		{
			$value = (UInt64.Parse($LENGTH_SYMBOLS.text) < LENGTH);
		}

		if ($EQUAL_SIGN.text  == ">")
		{
			$value = (UInt64.Parse($LENGTH_SYMBOLS.text) > LENGTH);
		}

		if ($EQUAL_SIGN.text  == ">=")
		{
			$value = (UInt64.Parse($LENGTH_SYMBOLS.text) >= LENGTH);
		}

		if ($EQUAL_SIGN.text  == "<=")
		{
			$value = (UInt64.Parse($LENGTH_SYMBOLS.text) <= LENGTH);
		}
	} 
  
	| 'Length' EQUAL_SIGN LENGTH_SYMBOLS
	{
		if ($EQUAL_SIGN.text == "=")
		{
			$value = (LENGTH == UInt64.Parse($LENGTH_SYMBOLS.text));
		}

		if ($EQUAL_SIGN.text  == "<")
		{
			$value = (LENGTH < UInt64.Parse($LENGTH_SYMBOLS.text));
		}

		if ($EQUAL_SIGN.text  == ">")
		{
			$value = (LENGTH > UInt64.Parse($LENGTH_SYMBOLS.text));
		}

		if ($EQUAL_SIGN.text  == ">=")
		{
			$value = (LENGTH >= UInt64.Parse($LENGTH_SYMBOLS.text));
		}

		if ($EQUAL_SIGN.text  == "<=")
		{
			$value = (LENGTH == UInt64.Parse($LENGTH_SYMBOLS.text));
		}
	}

	| LENGTH_SYMBOLS_1 EQUAL_SIGN_1 'Length' EQUAL_SIGN_2 LENGTH_SYMBOLS_2
	{
		if ($EQUAL_SIGN_1.text == ">")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH < UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH < UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH < UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH > UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH < UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH < UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}
		}

		if ($EQUAL_SIGN_1.text == "<")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH > UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH < UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH > UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH > UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH > UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH > UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}
		}

		if ($EQUAL_SIGN_1.text == ">=")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH < UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH > UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}
		}

		if ($EQUAL_SIGN_1.text == "<=")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH < UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH > UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH >= UInt64.Parse($LENGTH_SYMBOLS_1.text)) && (LENGTH <= UInt64.Parse($LENGTH_SYMBOLS_2.text)));
			}
		}
	}
  ;

exprContent returns[bool value]
	: 'Content' '~' '\'' CONTENT_SYMBOLS '\''{ $value = CONTENT.Contains($CONTENT_SYMBOLS.text); }
	;

EQUAL_SIGN
	: '='
	| '>'
	| '<'
	| '<='
	| '>='
	;

EQUAL_SIGN_1
	: '>'
	| '<'
	| '<='
	| '>='
	;

EQUAL_SIGN_2
	: '>'
	| '<'
	| '<='
	| '>='
	;

NAME_SYMBOLS
	: [a-zA-Z0-9?*]+ '.' [a-zA-Z0-9?*]+
	;
	
LENGTH_SYMBOLS
	: '0'..'9'+
	;

LENGTH_SYMBOLS_1
	: '0'..'9'+
	;

LENGTH_SYMBOLS_2
	: '0'..'9'+
	;

CONTENT_SYMBOLS
	: [a-zA-Z0-9?*.]+
	;

NEWLINE
	: '\r'? '\n'
	;