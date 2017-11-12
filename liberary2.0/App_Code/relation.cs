using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// relation 的摘要说明
/// </summary>
public class relation
{
    Sql sqlcalss = new Sql(table_get: "user_book_relation");
    public relation()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    
    public int Check_relation(string userName, string bookName)
    {
        DataTable dt = new DataTable();
        string sqlstr = "select user_name from user_book_relation where user_name = N'" + userName + "'and book_name_borrow = N'" + bookName + "'";
        dt = sqlcalss.Sql_get_Datatable(sqlstr);
        if (dt.Rows.Count == 0)
        { return -1; }
        else
        {
            return 1;
        }
    }
}