using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// book 的摘要说明
/// </summary>
public class book
{
    public book()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    Sql sqlclass = new Sql(table_get: "books");

    public void Add_book(string book_name, string book_author, string book_class)
    {
        string sqlstr = "insert into books values(N'" + book_name + "',N'" + book_author + "',N'" + book_class + "')";
        sqlclass.Sql_deal_with(sqlstr);
    }

    public void Delete_book(string book_name)
    {
        string sqlstr = "delete from books where book_name = N'" + book_name + "'";
        sqlclass.Sql_deal_with(sqlstr);
    }

    /// <summary>
    ///获取指定书籍
    /// </summary>
    public DataTable Get_books(string imformation,string where)
    {
        string sqlstr = "select * from books where " + where + " like N'%" + imformation + "%'";
        return sqlclass.Sql_get_Datatable(sqlstr);
    }
}