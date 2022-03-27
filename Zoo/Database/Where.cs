namespace Zoo.Database
{
    public partial class Query
    {
        public Query Where(Where where, string column, Operator Operator, params object[] target)
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

                    foreach (var item in target)
                    {
                        if (item.IsNumber())
                        {
                            str += $"{item},";
                        }
                        else
                        {
                            str += $"'{item}',";
                        }
                    }
                    str = str.Remove(str.Length - 1, 1);
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
