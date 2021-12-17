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
    public partial class Editform : System.Web.UI.Page
    {
        //All controls used in accordion is declared here and the connection to the db.
        TextBox txtModel = new TextBox();
        TextBox txtCarPrice = new TextBox();
        TextBox txtWheels = new TextBox();
        TextBox txtAlarm = new TextBox();
        TextBox txtHeadlights = new TextBox();
        TextBox txtSeats = new TextBox();
        TextBox txtRadio = new TextBox();
        TextBox txtLocking = new TextBox();
        TextBox txtWindows = new TextBox();
        TextBox txtAirbags = new TextBox();
        TextBox txtControl = new TextBox();
        TextBox txtCarID = new TextBox();
        TextBox txtCarModel = new TextBox();
        TextBox txtModelU = new TextBox();
        TextBox txtCarPriceU = new TextBox();
        TextBox txtWheelsU = new TextBox();
        TextBox txtAlarmU = new TextBox();
        TextBox txtHeadlightsU = new TextBox();
        TextBox txtSeatsU = new TextBox();
        TextBox txtRadioU = new TextBox();
        TextBox txtLockingU = new TextBox();
        TextBox txtWindowsU = new TextBox();
        TextBox txtAirbagsU = new TextBox();
        TextBox txtControlU = new TextBox();
        TextBox txtCarIDU = new TextBox();
        TextBox txtCarModelU = new TextBox();
        TextBox txtCarIDOrig = new TextBox();
        TextBox txtModelOrig = new TextBox();
        Label lblResponse = new Label();
        Label lblResponse2 = new Label();
        Label lblResponse3 = new Label();
        Label lblResponse4 = new Label();
        public SqlConnection conn;
        public SqlCommand comm;
        public DataSet ds;
        public SqlDataAdapter adap;
        public SqlCommand comm2;
        public DataSet ds2;
        public SqlDataAdapter adap2;
        public string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VolkswagenDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Accordion is created on load using AjaxControlToolKit plugin. 
            ///This pane is used for creating a record of a model in the table Features. Only the model textbox may not be null
            try
            {
                AjaxControlToolkit.AccordionPane accpane = new AjaxControlToolkit.AccordionPane();
                accpane.ID = "pane";
                accpane.HeaderContainer.Controls.Add(new LiteralControl("Create A Record For a Model"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Model: "));
                accpane.ContentContainer.Controls.Add(txtModel);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Price: "));
                accpane.ContentContainer.Controls.Add(txtCarPrice);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Wheels: "));
                accpane.ContentContainer.Controls.Add(txtWheels);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Model: "));
                accpane.ContentContainer.Controls.Add(txtAlarm);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Headlights: "));
                accpane.ContentContainer.Controls.Add(txtHeadlights);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Seats: "));
                accpane.ContentContainer.Controls.Add(txtSeats);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Radio: "));
                accpane.ContentContainer.Controls.Add(txtRadio);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Locking: "));
                accpane.ContentContainer.Controls.Add(txtLocking);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Windows: "));
                accpane.ContentContainer.Controls.Add(txtWindows);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Airbags: "));
                accpane.ContentContainer.Controls.Add(txtAirbags);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(new LiteralControl("Control: "));
                accpane.ContentContainer.Controls.Add(txtControl);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(lblResponse);
                Button btnSelect = new Button();
                btnSelect.Text = "Enter";
                btnSelect.Click += new EventHandler(this.btnSelect_Click);
                accpane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane.ContentContainer.Controls.Add(btnSelect);
                accEdit.Panes.Add(accpane);
                /////////////////////////////////////////////////////
                ///This pane is used fro creating a record of a car in the table Cars. Only the id textbox may not be null
                AjaxControlToolkit.AccordionPane accpane2 = new AjaxControlToolkit.AccordionPane();
                accpane2.ID = "pane2";
                accpane2.HeaderContainer.Controls.Add(new LiteralControl("Create A Record For a New Car Entry"));
                accpane2.ContentContainer.Controls.Add(new LiteralControl("Car ID: "));
                accpane2.ContentContainer.Controls.Add(txtCarID);
                accpane2.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane2.ContentContainer.Controls.Add(new LiteralControl("Model: "));
                accpane2.ContentContainer.Controls.Add(txtCarModel);
                accpane2.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane2.ContentContainer.Controls.Add(lblResponse2);
                Button btnSelect2 = new Button();
                btnSelect2.Text = "Enter";
                btnSelect2.Click += new EventHandler(this.btnSelect2_Click);
                accpane2.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane2.ContentContainer.Controls.Add(btnSelect2);
                accEdit.Panes.Add(accpane2);
                /////////////////////////////////////////////////////
                ///This pane is used for updating a record of a model in the table Features.
                ///The user must provide the model they want to update and the changes
                AjaxControlToolkit.AccordionPane accpane3 = new AjaxControlToolkit.AccordionPane();
                accpane3.ID = "pane3";
                accpane3.HeaderContainer.Controls.Add(new LiteralControl("Update A Record For a Model"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Original Model: "));
                accpane3.ContentContainer.Controls.Add(txtModelOrig);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Model: "));
                accpane3.ContentContainer.Controls.Add(txtModelU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Price: "));
                accpane3.ContentContainer.Controls.Add(txtCarPriceU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Wheels: "));
                accpane3.ContentContainer.Controls.Add(txtWheelsU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Model: "));
                accpane3.ContentContainer.Controls.Add(txtAlarmU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Headlights: "));
                accpane3.ContentContainer.Controls.Add(txtHeadlightsU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Seats: "));
                accpane3.ContentContainer.Controls.Add(txtSeatsU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Radio: "));
                accpane3.ContentContainer.Controls.Add(txtRadioU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Locking: "));
                accpane3.ContentContainer.Controls.Add(txtLockingU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Windows: "));
                accpane3.ContentContainer.Controls.Add(txtWindowsU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Airbags: "));
                accpane3.ContentContainer.Controls.Add(txtAirbagsU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(new LiteralControl("Control: "));
                accpane3.ContentContainer.Controls.Add(txtControlU);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(lblResponse3);
                Button btnSelect3 = new Button();
                btnSelect3.Text = "Enter";
                btnSelect3.Click += new EventHandler(this.btnSelect3_Click);
                accpane3.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane3.ContentContainer.Controls.Add(btnSelect3);
                accEdit.Panes.Add(accpane3);
                /////////////////////////////////////////////////////
                ///This pane is used for updating a record of a car in the table Cars.
                ///The user must provide the model they want to update and the changes
                AjaxControlToolkit.AccordionPane accpane4 = new AjaxControlToolkit.AccordionPane();
                accpane4.ID = "pane4";
                accpane4.HeaderContainer.Controls.Add(new LiteralControl("Update A Record For a New Car Entry"));
                accpane4.ContentContainer.Controls.Add(new LiteralControl("Original ID: "));
                accpane4.ContentContainer.Controls.Add(txtCarIDOrig);
                accpane4.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane4.ContentContainer.Controls.Add(new LiteralControl("New Car ID: "));
                accpane4.ContentContainer.Controls.Add(txtCarIDU);
                accpane4.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane4.ContentContainer.Controls.Add(new LiteralControl("New Model: "));
                accpane4.ContentContainer.Controls.Add(txtCarModelU);
                accpane4.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane4.ContentContainer.Controls.Add(lblResponse4);
                Button btnSelect4 = new Button();
                btnSelect4.Text = "Enter";
                btnSelect4.Click += new EventHandler(this.btnSelect4_Click);
                accpane4.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                accpane4.ContentContainer.Controls.Add(btnSelect4);
                accEdit.Panes.Add(accpane4);
            }
            catch
            {

            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //Connects to the Features table and inserts the information using a stored procedure.
            try
            {
                ds = new DataSet();
                adap = new SqlDataAdapter();
                comm = new SqlCommand();
                conn = new SqlConnection(constr);
                comm = new SqlCommand("InsertFeatures", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@Model", SqlDbType.VarChar).Value = txtModel.Text;
                comm.Parameters.Add("@Price", SqlDbType.VarChar).Value = txtCarPrice.Text;
                comm.Parameters.Add("@ft_wheels", SqlDbType.VarChar).Value = txtWheels.Text;
                comm.Parameters.Add("@ft_alarm", SqlDbType.VarChar).Value = txtAlarm.Text;
                comm.Parameters.Add("@ft_headlights", SqlDbType.VarChar).Value = txtHeadlights.Text;
                comm.Parameters.Add("@ft_seats", SqlDbType.VarChar).Value = txtSeats.Text;
                comm.Parameters.Add("@ft_radio", SqlDbType.VarChar).Value = txtRadio.Text;
                comm.Parameters.Add("@ft_locking", SqlDbType.VarChar).Value = txtLocking.Text;
                comm.Parameters.Add("@ft_windows", SqlDbType.VarChar).Value = txtWindows.Text;
                comm.Parameters.Add("@ft_airbags", SqlDbType.VarChar).Value = txtAirbags.Text;
                comm.Parameters.Add("@ft_control", SqlDbType.VarChar).Value = txtControl.Text;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                txtModel.Text = "";
                txtCarPrice.Text = "";
                txtAirbags.Text = "";
                txtLocking.Text = "";
                txtHeadlights.Text = "";
                txtControl.Text = "";
                txtAlarm.Text = "";
                txtRadio.Text = "";
                txtSeats.Text = "";
                txtWheels.Text = "";
                txtWindows.Text = "";
                lblResponse.Text = "Successfully Regestered Model And Features!";
            }
            catch (Exception ex)
            {
                lblResponse.Text = "Something went wrong! " + ex.Message;
            }

}

        protected void btnSelect2_Click(object sender, EventArgs e)
        {
            //Connects to the Cars table and inserts the information using a stored procedure.
            try
            {
                ds = new DataSet();
                adap = new SqlDataAdapter();
                comm = new SqlCommand();
                conn = new SqlConnection(constr);
                comm = new SqlCommand("InsertCars", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@Car_ID", SqlDbType.VarChar).Value = txtCarID.Text;
                comm.Parameters.Add("@Model", SqlDbType.VarChar).Value = txtCarModel.Text;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                txtCarID.Text = "";
                txtCarModel.Text = "";
                lblResponse2.Text = "Car Successfully Regestered!";
            }
            catch (Exception ex)
            {
                lblResponse2.Text = "Something went wrong! Please ensure that the Original ID matches one in the database and that both id's are only 6 characters long. Also ensure that the model matches a model from the Featurs table. The description of the error is as follows: " + ex.Message;
            }
}

        protected void btnSelect3_Click(object sender, EventArgs e)
        {
            //Connects to the Features table and updates the information using a stored procedure.
            try
            {
                ds = new DataSet();
                adap = new SqlDataAdapter();
                comm = new SqlCommand();
                conn = new SqlConnection(constr);
                comm = new SqlCommand("UpdateFeatures", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@Original_Model", SqlDbType.VarChar).Value = txtModelOrig.Text;
                comm.Parameters.Add("@Model", SqlDbType.VarChar).Value = txtModelU.Text;
                comm.Parameters.Add("@Price", SqlDbType.VarChar).Value = txtCarPriceU.Text;
                comm.Parameters.Add("@ft_wheels", SqlDbType.VarChar).Value = txtWheelsU.Text;
                comm.Parameters.Add("@ft_alarm", SqlDbType.VarChar).Value = txtAlarmU.Text;
                comm.Parameters.Add("@ft_headlights", SqlDbType.VarChar).Value = txtHeadlightsU.Text;
                comm.Parameters.Add("@ft_seats", SqlDbType.VarChar).Value = txtSeatsU.Text;
                comm.Parameters.Add("@ft_radio", SqlDbType.VarChar).Value = txtRadioU.Text;
                comm.Parameters.Add("@ft_locking", SqlDbType.VarChar).Value = txtLockingU.Text;
                comm.Parameters.Add("@ft_windows", SqlDbType.VarChar).Value = txtWindowsU.Text;
                comm.Parameters.Add("@ft_airbags", SqlDbType.VarChar).Value = txtAirbagsU.Text;
                comm.Parameters.Add("@ft_control", SqlDbType.VarChar).Value = txtControlU.Text;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                txtModelOrig.Text = "";
                txtModelU.Text = "";
                txtCarPriceU.Text = "";
                txtAirbagsU.Text = "";
                txtLockingU.Text = "";
                txtHeadlightsU.Text = "";
                txtControlU.Text = "";
                txtAlarmU.Text = "";
                txtRadioU.Text = "";
                txtSeatsU.Text = "";
                txtWheelsU.Text = "";
                txtWindowsU.Text = "";
                lblResponse3.Text = "Successfully Updated Model And Features!";
            }
            catch (Exception ex)
            {
                lblResponse3.Text = "Something went wrong! The description of the error is as follows: " + ex.Message;
            }
        }

        protected void btnSelect4_Click(object sender, EventArgs e)
        {
            //Connects to the Cars table and updates the information using a stored procedure.
            try
            {
                ds = new DataSet();
                adap = new SqlDataAdapter();
                comm = new SqlCommand();
                conn = new SqlConnection(constr);
                comm = new SqlCommand("UpdateCars", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@Original_Car_ID", SqlDbType.VarChar).Value = txtCarIDOrig.Text;
                comm.Parameters.Add("@Car_ID", SqlDbType.VarChar).Value = txtCarIDU.Text;
                comm.Parameters.Add("@Model", SqlDbType.VarChar).Value = txtCarModelU.Text;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                txtCarIDOrig.Text = "";
                txtCarIDU.Text = "";
                txtCarModelU.Text = "";
                lblResponse4.Text = "Car Successfully Updated!";
            }
            catch (Exception ex)
            {
                lblResponse4.Text = "Something went wrong! Please ensure that the Original ID matches one in the database and that both id's are only 6 characters long. Also ensure that the model matches a model from the Featurs table. The description of the error is as follows: " + ex.Message;
            }
            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}