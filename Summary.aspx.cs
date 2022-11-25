using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["memberList"] == null)
                {
                   /* Response.Redirect("Appointment.aspx");*/
                    tblSummary.Rows.Add(new TableRow
                    {
                        Cells =
                    {
                        new TableCell{ Text = "Nill"},
                        new TableCell{ Text = "Nill" },
                        new TableCell{ Text = "Nill"},
                        new TableCell{ Text = "Nill"},
                        new TableCell{ Text = "Nill"}
                    }
                    });
                }
                else
                {
                    List<Member> memberList = (List<Member>)Session["memberList"];
                    Session["memberList"] = memberList;

                    foreach (Member m in memberList)
                    {
                        tblSummary.Rows.Add(new TableRow
                        {
                            Cells =
                    {
                        new TableCell{ Text = m.Id.ToString() },
                        new TableCell{ Text = m.Name },
                        new TableCell{ Text = m.preference },
                        new TableCell{ Text = m.count.ToString() +"item(s)"},
                        new TableCell{ Text = m.hours.ToString() + "hour(s)"}
                    }
                        });
                    }
                }
            }
        }
    }
}