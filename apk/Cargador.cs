using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using Antlr4;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime;

namespace apk
{
    public class Cargador : ExprBaseListener
    {
        public Stack<double> pila { get; set; }=new Stack<double>();
        public Stack<char> pilaC { get; set; } = new Stack<char>();
        public override void ExitExpr([NotNull] ExprParser.ExprContext context)
        {
            base.ExitExpr(context);
            if (context.ChildCount == 3)
            {
                double derecha = pila.Pop();
                double izquierda = pila.Pop();

                if (context.op.Type == ExprParser.SUM)
                {
                        pila.Push( (izquierda + derecha));
                }
                if (context.op.Type == ExprParser.RES)
                {
                    pila.Push(izquierda+derecha);
                }
                if (context.op.Type == ExprParser.MULT)
                {
                    pila.Push(izquierda * derecha);
                }
                if (context.op.Type == ExprParser.DIV)
                {
                    if (derecha>0)
                    {
                        pila.Push(izquierda / derecha);
                    }
                    else
                    {
                        pila.Push(-1);
                    }
                }

               /* if (context.op.Type == ExprParser.PARDER && context.op.Type == ExprParser.PARIZQ)
                {
                    pilaC.Push('A');
                }*/


            }
            base.ExitExpr(context);
        }
        public override void VisitTerminal([NotNull] ITerminalNode node)
        {
            base.VisitTerminal(node);
            IToken simbolo = node.Symbol;
            if (simbolo.Type == ExprParser.INT || simbolo.Type == ExprParser.DOUBLE)
            {
                pila.Push(double.Parse(simbolo.Text));
            }
            if (simbolo.Type == ExprParser.PARDER || simbolo.Type == ExprParser.PARIZQ)
            {
                pilaC.Push(char.Parse(simbolo.Text));
            }

        }
    }
}
