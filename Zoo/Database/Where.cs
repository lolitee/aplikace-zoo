using System.Linq;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Where(Where where, string column, Operator Operator, params string[] target)
        {
            string cond = "=";
            string str = "";

            switch (Operator)
            {
                case Operator.EQUALS: cond = "=";
                    break;
                case Operator.GREATER_THAN: cond = ">";
                    break;
                case Operator.GREATER_THAN_OR_EQUAL: cond = ">=";
                    break;
                case Operator.LESS_THAN: cond = "<";
                    break;
                case Operator.LESS_THAN_OR_EQUAL: cond = "<=";
                    break;
                case Operator.LIKE: cond = "LIKE";
                    break;
                case Operator.IN: cond = "IN";

                    str += "(";
                    
                    str += string.Join(", ", target.Select(x => $"'{x}'"));

                    str += ")";

                    break;
            }

            if(target.Length <= 1 && Operator != Operator.IN)
            {
                if (target[0].IsNumber())
                {
                    str = target[0].ToString();
                }
                else
                {
                    str = $"'{target[0]}'";
                }
            }

            sql += $"{where} {column} {cond} {str} ";
            return this;
        }
    }
}
