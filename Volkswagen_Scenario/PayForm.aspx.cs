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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public SqlConnection conn;
        public SqlCommand commSelectModel;
        public SqlCommand commCount;
        public SqlCommand commDelete;
        public DataSet ds1;
        public DataSet ds2;
        public DataSet ds3;
        public SqlDataAdapter adap1;
        public SqlDataAdapter adap2;
        public SqlDataAdapter adap3;
        public string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VolkswagenDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Here i connected to the db and populated the drop down list based on the models
                //from the Features table.
                Label2.Visible = false;
                lblPurchase.Visible = false;
                btnSelect.Visible = false;
                txtID.Visible = false;
                lblModel.Text = "";
                lblCount.Text = "";
                grdModels.Visible = false;
                ds1 = new DataSet();
                commSelectModel = new SqlCommand();
                conn = new SqlConnection(constr);
                adap1 = new SqlDataAdapter();
                commSelectModel = new SqlCommand("selectModel", conn);
                conn.Open();
                commSelectModel.ExecuteNonQuery();
                adap1.SelectCommand = commSelectModel;
                adap1.Fill(ds1);
                drpModel.DataSource = ds1;
                drpModel.DataBind();
                drpModel.DataTextField = "Model";
                drpModel.DataBind();
                conn.Close();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //Here a simulated purchase happens where a Delete query is called using a stored procedure.
            //The gridview will be cleared and the label confirming the purchase will become visible.
            try
            {
                ds3 = new DataSet();
                commDelete = new SqlCommand();
                conn = new SqlConnection(constr);
                adap3 = new SqlDataAdapter();
                commDelete = new SqlCommand("DeleteCars", conn);
                commDelete.CommandType = CommandType.StoredProcedure;
                commDelete.Parameters.Add("@Original_Car_ID", SqlDbType.VarChar).Value = txtID.Text;
                conn.Open();
                commDelete.ExecuteNonQuery();
                conn.Close();
                lblPurchase.Visible = true;
                grdModels.DataSource = null;
            }
            catch (Exception ex)
            {
                lblPurchase.Text = "Something went wrong! " + ex.Message;
            }
        }

        protected void drpModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When an item is selected from the drop down list, the gridview will be populated with
            //only the records where the model is the same as the one selected.
            //Only the model and its ID will be shown.
            string param = drpModel.SelectedValue;
            ds2 = new DataSet();
            commCount = new SqlCommand();
            conn = new SqlConnection(constr);
            adap2 = new SqlDataAdapter();
            commCount = new SqlCommand("CountCars", conn);
            commCount.CommandType = CommandType.StoredProcedure;
            commCount.Parameters.Add("@Model", SqlDbType.VarChar).Value = param;
            conn.Open();
            commCount.ExecuteNonQuery();
            adap2.SelectCommand = commCount;
            adap2.Fill(ds2);
            grdModels.DataSource = ds2;
            grdModels.DataBind();
            grdModels.Visible = true;
            conn.Close();
            Label2.Visible = true;
            btnSelect.Visible = true;
            txtID.Visible = true;
            lblModel.Text = drpModel.SelectedValue;
            lblCount.Text = "Total Stock Of " + drpModel.SelectedValue + " Is: " + grdModels.Rows.Count.ToString();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}