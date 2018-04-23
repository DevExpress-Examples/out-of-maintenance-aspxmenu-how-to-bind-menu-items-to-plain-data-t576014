using DevExpress.Web;
using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable table = GetDataTable();
            CreateMenuRecursively(table, Menu.Items, "0");
        }
    }

    private void CreateMenuRecursively(DataTable table, MenuItemCollection items, string parentID)
    {
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (table.Rows[i]["ParentID"].ToString() == parentID)
            {
                MenuItem item = new MenuItem(table.Rows[i]["Title"].ToString(), 
                    table.Rows[i]["ID"].ToString());
                items.Add(item);
                CreateMenuRecursively(table, item.Items, item.Name);
            }
        }
    }

    private DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("ParentID", typeof(int));

        dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

        dt.Rows.Add(1, "Node1", 0);
        dt.Rows.Add(2, "Node2", 0);
        dt.Rows.Add(3, "Node3", 0);
        dt.Rows.Add(4, "Node11", 1);
        dt.Rows.Add(5, "Node12", 1);
        dt.Rows.Add(6, "Node21", 2);
        dt.Rows.Add(7, "Node22", 2);
        dt.Rows.Add(8, "Node31", 3);
        dt.Rows.Add(9, "Node32", 3);
        dt.Rows.Add(10, "Node121", 5);

        return dt;
    }
}