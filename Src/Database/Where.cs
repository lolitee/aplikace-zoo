using System.Linq;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Where(Where where, string column, Operator Operator, params string[] target)
        {
            // skládání stringu pro update v databázi
            string op = "=";
            string str = "";

            switch (Operator)
            {
                case Operator.EQUALS:
                    op = "=";
                    break;

                case Operator.GREATER_THAN:
                    op = ">";
                    break;

                case Operator.GREATER_THAN_OR_EQUAL:
                    op = ">=";
                    break;

                case Operator.LESS_THAN:
                    op = "<";
                    break;

                case Operator.LESS_THAN_OR_EQUAL:
                    op = "<=";
                    break;

                case Operator.LIKE:
                    op = "LIKE";
                    break;

                case Operator.IN:
                    op = "IN";
                    str += $"({string.Join(", ", target.Select(x => $"'{x}'"))})";
                    break;

                case Operator.IS:
                    op = "IS";
                    break;
            }

            if (target.Length <= 1 && Operator != Operator.IN)
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

            sql += $"{where} {column} {op} {str} ";
            return this;
        }
    }
}