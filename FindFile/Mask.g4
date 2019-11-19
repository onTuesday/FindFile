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
	using FindFile;
	using System.IO;
}

@members
{
	String NAME	= Path.GetFileName(MaskHandler.currentFile.GetName());
    UInt64 LENGTH = MaskHandler.currentFile.GetLength();
    String CONTENT = MaskHandler.currentFile.GetContent();

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
	: boolexpr  { MaskHandler.final = $boolexpr.value; }
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
		String Size = $LENGTH_SYMBOLS.text;
		UInt64 Length;
		
		switch(Size.Substring(Size.Length - 1))
		{
			case "k": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024; break;
			case "K": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024; break;
			case "m": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024; break;
			case "M": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024; break;
			case "g": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024 * 1024; break;
			case "G": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024 * 1024; break;
			default: Length = UInt64.Parse(Size); break;
		}
		
		if ($EQUAL_SIGN.text == "=")
		{
			$value = (Length == LENGTH);
		}

		if ($EQUAL_SIGN.text  == "<")
		{
			$value = (Length < LENGTH);
		}

		if ($EQUAL_SIGN.text  == ">")
		{
			$value = (Length > LENGTH);
		}

		if ($EQUAL_SIGN.text  == ">=")
		{
			$value = (Length >= LENGTH);
		}

		if ($EQUAL_SIGN.text  == "<=")
		{
			$value = (Length <= LENGTH);
		}
	} 
  
	| 'Length' EQUAL_SIGN LENGTH_SYMBOLS
	{
		String Size = $LENGTH_SYMBOLS.text;
		UInt64 Length;
		
		switch(Size.Substring(Size.Length - 1))
		{
			case "k": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024; break;
			case "K": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024; break;
			case "m": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024; break;
			case "M": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024; break;
			case "g": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024 * 1024; break;
			case "G": Length = UInt64.Parse(Size.TrimEnd(Size[Size.Length - 1])) * 1024 * 1024 * 1024; break;
			default: Length = UInt64.Parse(Size); break;
		}

		if ($EQUAL_SIGN.text == "=")
		{
			$value = (LENGTH == Length);
		}

		if ($EQUAL_SIGN.text  == "<")
		{
			$value = (LENGTH < Length);
		}

		if ($EQUAL_SIGN.text  == ">")
		{
			$value = (LENGTH > Length);
		}

		if ($EQUAL_SIGN.text  == ">=")
		{
			$value = (LENGTH >= Length);
		}

		if ($EQUAL_SIGN.text  == "<=")
		{
			$value = (LENGTH <= Length);
		}
	}

	| LENGTH_SYMBOLS_1 EQUAL_SIGN_1 'Length' EQUAL_SIGN_2 LENGTH_SYMBOLS_2
	{
		String Size1 = $LENGTH_SYMBOLS_1.text;
		UInt64 Length1;
		
		switch(Size1.Substring(Size1.Length - 1))
		{
			case "k": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024; break;
			case "K": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024; break;
			case "m": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024 * 1024; break;
			case "M": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024 * 1024; break;
			case "g": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024 * 1024 * 1024; break;
			case "G": Length1 = UInt64.Parse(Size1.TrimEnd(Size1[Size1.Length - 1])) * 1024 * 1024 * 1024; break;
			default: Length1 = UInt64.Parse(Size1); break;
		}

		String Size2 = $LENGTH_SYMBOLS_2.text;
		UInt64 Length2;
		
		switch(Size2.Substring(Size2.Length - 1))
		{
			case "k": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024; break;
			case "K": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024; break;
			case "m": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024 * 1024; break;
			case "M": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024 * 1024; break;
			case "g": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024 * 1024 * 1024; break;
			case "G": Length2 = UInt64.Parse(Size2.TrimEnd(Size2[Size2.Length - 1])) * 1024 * 1024 * 1024; break;
			default: Length2 = UInt64.Parse(Size2); break;
		}
		
		if ($EQUAL_SIGN_1.text == ">")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH < Length1) && (LENGTH < Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH < Length1) && (LENGTH > Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH < Length1) && (LENGTH >= Length2));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH < Length1) && (LENGTH <= Length2));
			}
		}

		if ($EQUAL_SIGN_1.text == "<")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH > Length1) && (LENGTH < Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH > Length1) && (LENGTH > Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH > Length1) && (LENGTH >= Length2));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH > Length1) && (LENGTH <= Length2));
			}
		}

		if ($EQUAL_SIGN_1.text == ">=")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH <= Length1) && (LENGTH < Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH <= Length1) && (LENGTH > Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH <= Length1) && (LENGTH >= Length2));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH <= Length1) && (LENGTH <= Length2));
			}
		}

		if ($EQUAL_SIGN_1.text == "<=")
		{
			if ($EQUAL_SIGN_2.text  == "<")
			{
				$value = ((LENGTH >= Length1) && (LENGTH < Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">")
			{
				$value = ((LENGTH >= Length1) && (LENGTH > Length2));
			}

			if ($EQUAL_SIGN_2.text  == ">=")
			{
				$value = ((LENGTH >= Length1) && (LENGTH >= Length2));
			}

			if ($EQUAL_SIGN_2.text  == "<=")
			{
				$value = ((LENGTH >= Length1) && (LENGTH <= Length2));
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
	: '0'..'9'+ [kKmMgG]?
	;

LENGTH_SYMBOLS_1
	: '0'..'9'+ [kKmMgG]?
	;

LENGTH_SYMBOLS_2
	: '0'..'9'+ [kKmMgG]?
	;

CONTENT_SYMBOLS
	: [a-zA-Z0-9?*.]+
	;

NEWLINE
	: '\r'? '\n'
	;