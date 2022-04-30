using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListBox1.Items.Add(new ListItem("campo1", "1"));
        ListBox1.Items.Add(new ListItem("campo2", "2"));

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = ListBox1.Items[ListBox1.SelectedIndex].ToString();
    }
}