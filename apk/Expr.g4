grammar Expr;
prog:   (expr NEWLINE)* ;
expr:   expr op=(MULT|DIV) expr     {if(Convert.ToInt32($expr.text)<0) NotifyErrorListeners("Los valores numericos deben ser mayores a 0");} {Console.WriteLine("Token Encontrado: "+ $op.text);}
    |   expr op=(SUM|RES) expr         {Console.WriteLine("Token Encontrado: "+ $op.text);}
    |   INT                         {Console.WriteLine("Token Encontrado: "+ $INT.text);}
    |   DOUBLE                       {Console.WriteLine("Token Encontrado: "+ $DOUBLE.text);}
    |   PARDER expr PARIZQ          
    ;

MULT: '*';
DIV: '/';
RES: '-';
SUM: '+';
PARDER: '(';
PARIZQ: ')';
NEWLINE : [\r\n]+ ;
INT     : '-'?[0-9]+  ;
DOUBLE  : '-'?INT'.'INT  ;