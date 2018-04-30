using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
namespace TravelSite
{
    public partial class Hotel : System.Web.UI.Page
    {
        Button myaddButton;
        Button mysearchButton;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //copy and paste to check if a user is logged in
                HttpCookie objCookie;
                objCookie = Request.Cookies["TravelSite"];
                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {
                    //do nothing
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                this.PageTemplateASCX.title = "Test Page";
                this.PageTemplateASCX.navDefaultHeading = "Default Search";

                //search sections
                this.PageTemplateASCX.navHeading2 = "Rooms By Hotel";
                this.PageTemplateASCX.navHeading3 = "Find Rooms";
                this.PageTemplateASCX.navHeading4 = "Find Rooms By Hotel";
                //this.PageTemplateASCX.navHeading4 = "Search 4";

                //defaultSearch
                this.PageTemplateASCX.cityCrit = "City";
                this.PageTemplateASCX.stateCrit = "State";
                this.PageTemplateASCX.txtbox3head = "Agency ID";
                this.PageTemplateASCX.hideTxtBox1();
                this.PageTemplateASCX.hideTxtBox2();
                /*
                this.PageTemplateASCX.txtbox1head = "Agency ID";
                this.PageTemplateASCX.txtbox2head = "Agency ID";
                //search2
                this.PageTemplateASCX.txtbox3head = "Agency ID";
                this.PageTemplateASCX.txtbox4head = "Agency ID";
                this.PageTemplateASCX.txtbox5head = "Agency ID";
                //search3
                this.PageTemplateASCX.txtbox6head = "Agency ID";
                this.PageTemplateASCX.txtbox7head = "Agency ID";
                this.PageTemplateASCX.txtbox8head = "Agency ID";
                //search4
                this.PageTemplateASCX.txtbox9head = "Agency ID";
                this.PageTemplateASCX.txtbox10head = "Agency ID";
                this.PageTemplateASCX.txtbox11head = "Agency ID";
                */



            }
            //buttons
            myaddButton = (Button)this.PageTemplateASCX.addButton;
            mysearchButton = (Button)this.PageTemplateASCX.searchButton;
            this.PageTemplateASCX.searchButtonClick += new EventHandler(search);
            this.PageTemplateASCX.addButtonClick += new EventHandler(add);
        }

        //search button event - added to the control
        private void search(object sender, System.EventArgs e)
        {
            this.PageTemplateASCX.reset();
            ((GridView)this.PageTemplateASCX.gridview).DataSource = null;
            this.PageTemplateASCX.ds = null;

            //CHANGE THIS-----------------------------------------------------------------------------------------FILL
            HotelWebService.HotelService pxy = new HotelWebService.HotelService();

            //check if mandatory fields were filled out
            //in this case, city and state must be filled out for every search
            Boolean valid = true;
            if (((TextBox)this.PageTemplateASCX.cityCritbox).Text == "")
            {
                valid = false;
                //valCity.Style["display"] = "inline";
                this.PageTemplateASCX.displayCityVal();
                this.PageTemplateASCX.failedAddResults();
            }
            if (((TextBox)this.PageTemplateASCX.stateCritbox).Text == "")
            {
                valid = false;
                //valState.Style["display"] = "inline";
                this.PageTemplateASCX.displayStateVal();
                this.PageTemplateASCX.failedAddResults();
            }

            if (valid)
            {
                if (this.PageTemplateASCX.viewState != null)
                {
                    switch (this.PageTemplateASCX.viewState.ToString())
                    {
                        case "default": //default search
                            this.PageTemplateASCX.ds = //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                pxy.GetHotels(((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                            if (this.PageTemplateASCX.ds != null)
                            {
                                ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource
                                ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                {

                                    ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            { this.PageTemplateASCX.noSearchResults(); }
                            break;
                        case "2": //search 2
                            if (((TextBox)this.PageTemplateASCX.txtbox3control).Text != "")
                            {
                                //CREATE NECESSARY OBJECTS TO RUN METHOD//CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                HotelWebService.Hotel hotel = new HotelWebService.Hotel();
                                hotel.ID = Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox3control).Text);

                                //REPLACE THIS METHOD //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds =
                                    pxy.GetRoomsByHotel(hotel); //get appropriate dataset
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {
                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;

                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal3();
                                this.PageTemplateASCX.failedSearchResults();
                            }

                            break;
                        case "3": //search 3
                            if (((TextBox)this.PageTemplateASCX.txtbox2control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                HotelWebService.Amenities amenities = new HotelWebService.Amenities();
                                //((TextBox)PageTemplateASCX.txtbox2control).Text;

                                this.PageTemplateASCX.ds = null;
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds = pxy.FindRooms(amenities, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text);   //get appropriate dataset
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }

                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            { this.PageTemplateASCX.noSearchResults(); }
                            break;
                        case "4": //search 4

                            if (((TextBox)this.PageTemplateASCX.txtbox2control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                HotelWebService.Hotel hotel = new HotelWebService.Hotel();
                                HotelWebService.Amenities amenities = new HotelWebService.Amenities();
                                //((TextBox)PageTemplateASCX.txtbox2control).Text;

                                this.PageTemplateASCX.ds = null;
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds = pxy.FindRoomsByHotel(hotel, amenities);   //get appropriate dataset
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }

                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            { this.PageTemplateASCX.noSearchResults(); }
                            break;
                        default:
                            //this.PageTemplateASCX.ds = pxy.FindRoomsByHotel(hotel, amenities); //get appropriate dataset
                            //if (this.PageTemplateASCX.ds != null)
                            //{
                            //    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource
                            //    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                            //    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                            //    {

                            //        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                            //    }
                            //    else
                            //    { this.PageTemplateASCX.noSearchResults(); }
                            //}
                            //else
                            //{ this.PageTemplateASCX.noSearchResults(); }
                            break;
                    }
                }
            }
            else
            {
                this.PageTemplateASCX.viewState = "default";
            }
        }

        private void add(object sender, System.EventArgs e)
        {
            this.PageTemplateASCX.reset();
            int selectedCount = 0; //count number selected
            for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++) //count
            {
                CheckBox selected = (CheckBox)((GridView)this.PageTemplateASCX.gridview).Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; } //if selected, increment counter
            }
            if (selectedCount == 0) //if none selected
            {
                this.PageTemplateASCX.failedAddResults();
            }
            else //if at least one selected
            {
                //reloop through gridview
                for (int j = 0; j < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; j++)
                {
                    //if the select box is checked..
                    CheckBox selected = (CheckBox)((GridView)this.PageTemplateASCX.gridview).Rows[j].FindControl("chkSelect");
                    if (selected.Checked == true)
                    {
                        //create a new object
                        ExperienceClass newExp = new ExperienceClass();
                        //initialize its properities to the record's values that was chosen
                        newExp.Agency_id = 1;

                        //if a vacation package exists
                        if (VacationPackage.getCustomerPackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString()) == null)
                        {
                            this.PageTemplateASCX.myPackage = new VacationPackage(); //if not, create a new one
                        }
                        else
                        {
                            //if yes, retrieve the package
                            this.PageTemplateASCX.myPackage = VacationPackage.getCustomerPackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString());
                        }
                        //finally, add the new object to the vacation package's appropriate list
                        this.PageTemplateASCX.myPackage.experienceArray.Add(newExp);
                    }
                }
                //update the vacation package in the database
                VacationPackage.updatePackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString(), this.PageTemplateASCX.myPackage);
                this.PageTemplateASCX.successfulAddResults();
            }

        }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
        }
    }
}
    
