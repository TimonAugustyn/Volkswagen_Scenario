using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Volkswagen_Scenario
{
    public partial class Home : System.Web.UI.Page
    {
        //Declares tools used for connecting to the db.
        public SqlConnection conn;
        public SqlCommand comm;
        public SqlCommand commSelectModel;
        public DataSet ds;
        public DataSet ds1;
        public SqlDataAdapter adap;
        public SqlDataAdapter adap1;
        public string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VolkswagenDB.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Accordion is created on page load where the models are fetched from the Features table.
            //All features relevant to each model is displayed in its respective pane.
            //The button in each pane will lead the user to the purchase form where the Delete function will be.
            ds = new DataSet();
            adap = new SqlDataAdapter();
            comm = new SqlCommand();
            conn = new SqlConnection(constr);
            comm = new SqlCommand("SelectFeatures", conn);
            conn.Open();
            comm.ExecuteNonQuery();
            adap.SelectCommand = comm;
            adap.Fill(ds);
            conn.Close();

            for (int i = 0; i < 14; i++)
            {
                AjaxControlToolkit.AccordionPane accpane = new AjaxControlToolkit.AccordionPane();
                accpane.ID = "pane" + i;
                accpane.HeaderContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[0].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[1].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[2].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[3].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[4].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[5].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[6].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[7].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[8].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[9].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl(ds.Tables[0].Rows[i].ItemArray[10].ToString()));
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                Button btnSelect = new Button();
                btnSelect.Text = "Proceed To Purchase";
                btnSelect.Click += new EventHandler(this.btnSelect_Click);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(btnSelect);
                accCars.Panes.Add(accpane);
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayForm.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditForm.aspx");
        }
    }
}