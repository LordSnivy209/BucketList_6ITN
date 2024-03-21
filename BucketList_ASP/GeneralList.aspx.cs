using BucketList_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BucketList_ASP
{
    public partial class GeneralList : System.Web.UI.Page
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
                lbxGeneralList.DataSource = _controller.getItems();
                lbxGeneralList.DataBind();
            }
          
        }

        protected void btnShowMenu_Click(object sender, EventArgs e)
        {
            menu.Style["display"] = "block";
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrWhiteSpace(txtNewItem.Text) && !string.IsNullOrWhiteSpace(txtItemDescription.Text))
                {
                    string itemName = txtNewItem.Text;
                    string itemDescription = txtItemDescription.Text;

                    //item in database
                    _controller.addItemToDB(itemName, itemDescription);

                    // Clear input fields
                    txtNewItem.Text = "";
                    txtItemDescription.Text = "";
                    Response.Redirect(Request.RawUrl);

                    //succes message
                    lblErrorMessage.CssClass = "text-success";
                    lblErrorMessage.Text = "Item added successfully!";

                }
                else
                {

                    // Display an error message indicating that both fields are required
                    lblErrorMessage.CssClass = "text-danger";
                    lblErrorMessage.Text = "Both item name and description are required.";
                }
            

        }

        protected void btnSendToPersonal_Click(object sender, EventArgs e)
        {
            _controller.addFromGeneralList(lbxGeneralList.SelectedIndex);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowBucketList.aspx");
        }
    }
}

