using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineBanking
{
    public partial class AccountListing : System.Web.UI.Page
    {
        BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        /// <summary>
        /// Bind data to grid view controls as long as the page loads successfully.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    try
                    {
                       

                        String email = Page.User.Identity.Name;

                        int index = Page.User.Identity.Name.IndexOf('@');

                        //String substring = email.Substring(0,email.IndexOf("@"));
                        long clientNumber = long.Parse(email.Substring(0, email.IndexOf("@")));

                        //int clientId = db.Clients.
                                        //Where(x => x.ClientNumber == clientNumber).
                                        //Select(x => x.ClientId).
                                        //SingleOrDefault();

                        Client client = db.Clients.
                                        Where(x => x.ClientNumber == clientNumber).
                                        SingleOrDefault();

                        int clientId = client.ClientId;

                        Session["SessionClient"] = client;

                        IQueryable<BankAccount> accounts = db.BankAccounts.
                                                           Where(x => x.ClientId == clientId);

                        Session["SessionAccounts"] = accounts;

                        gvAccount.DataSource = accounts.ToList();

                        gvAccount.DataBind();

                        String fName = client.FirstName;

                        String lName = client.LastName;

                        lblClientName.Text = fName + " " + lName;

                        
                    }
                    catch (Exception)
                    {
                        lblErrorOrException.Text = "There are some exceptions.";
                    }
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }                 
            }           
        }

        /// <summary>
        /// The method is to catch the selected account number as session variables and direct to TransactionListing page.
        /// </summary>
        protected void gvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SessionAccountNumber"] = gvAccount.Rows[gvAccount.SelectedIndex].Cells[1].Text;

            Response.Redirect("TransactionListing.aspx");
        } 

    }
}