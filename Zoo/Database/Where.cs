using System;

[Flags]
public enum Conditions
{
    EQUALS,
    GREATER_THAN,
    GREATER_THAN_OR_EQUAL,
    LESS_THAN,
    LESS_THAN_OR_EQUAL,
    OR,
    AND,
    LIKE,
    IN,
}

namespace Zoo.Database
{
    public partial class Query
    {
        public virtual Query Where(string column, Conditions conditions, params object[] target)
        {
            string cond = "=";
            string str = "";

            switch (conditions)
            {
                case Conditions.EQUALS: cond = "=";
                    break;
                case Conditions.GREATER_THAN: cond = ">";
                    break;
                case Conditions.GREATER_THAN_OR_EQUAL: cond = ">=";
                    break;
                case Conditions.LESS_THAN: cond = "<";
                    break;
                case Conditions.LESS_THAN_OR_EQUAL: cond = "<=";
                    break;
                case Conditions.OR: cond = "OR";
                    break;
                case Conditions.AND: cond = "AND";
                    break;
                case Conditions.LIKE: cond = "LIKE";
                    break;
                case Conditions.IN: cond = "IN";

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

            if(target.Length <= 1 && conditions != Conditions.IN)
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

            sql += $"WHERE {column} {cond} {str} ";
            return this;
        }
    }
}
