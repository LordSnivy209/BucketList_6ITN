using BucketList_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BucketList_ASP
{
    public partial class ShowBucketList : System.Web.UI.Page
    {
        Controller _controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _controller = (Controller)HttpContext.Current.Session["_controller"];
            }
            else
            {
                if (HttpContext.Current.Session["_controller"] == null)
                {
                    _controller = new Controller();
                    HttpContext.Current.Session["_controller"] = _controller;
                    Response.Redirect("default.aspx");
                }
                else
                {
                    _controller = (Controller)HttpContext.Current.Session["_controller"];
                }


                fillControls();

                
            }
        }
        private void fillControls()
        {
            List<BucketListItemPersonal> list = _controller.getPersonalItems();
            int teller = 0;
            foreach (BucketListItemPersonal item in list)
            {
                
                if (item.IsDone)
                {
                    //item in de lijst
                    cbxPersonalList.Items.Add(item.ToString());
                    //item aanvinken
                    cbxPersonalList.Items[teller].Selected = true;
                    //item disable
                    cbxPersonalList.Items[teller].Enabled = false;
                }
                else
                {
                    //item in de lijst
                    cbxPersonalList.Items.Add(item.ToString());
                }
                teller++;
            }

            lblName.Text = _controller.LoggedInUser.NaamPersoon;

        }

        protected void btnToGeneralList_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralList.aspx");
        }
        protected void btnUitgevoerd_Click(object sender, EventArgs e)
        {
            for(int i=0; i<cbxPersonalList.Items.Count; i++)
            {
                if (cbxPersonalList.Items[i].Selected)
                {
                    _controller.setAsCheckedInPL(i);
                    cbxPersonalList.Items[i].Enabled = false;
                }
            }
        }
    }
}