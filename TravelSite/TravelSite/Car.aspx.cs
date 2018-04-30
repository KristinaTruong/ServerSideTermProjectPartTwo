using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using TravelSite.CarWebService;
using System.Data;
using TravelSite.CarWebService;

namespace TravelSite
{
    public partial class Car : System.Web.UI.Page
    {
        Button myaddButton;
        Button mysearchButton;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                HttpCookie objCookie;
                objCookie = Request.Cookies["TravelSite"];
                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {

                    this.PageTemplateASCX.title = "Car Rentals";
                    this.PageTemplateASCX.navDefaultHeading = "Get Rental Car Agencies";

                    //search sections
                    this.PageTemplateASCX.navHeading2 = "Get Cars By Agency";
                    this.PageTemplateASCX.navHeading3 = "Find Cars";
                    this.PageTemplateASCX.navHeading4 = "Find Cars By Agency";
                    this.PageTemplateASCX.navHeading5 = "Find Activities By Agency";

                    //defaultSearch
                    this.PageTemplateASCX.cityCrit = "City";
                    this.PageTemplateASCX.stateCrit = "State";
                    this.PageTemplateASCX.txtbox3head = "Agency ID";
                    this.PageTemplateASCX.txtbox9head = "Agency ID";
                    this.PageTemplateASCX.txtbox10head = "Perks ID";
                    this.PageTemplateASCX.hideTxtBox1();
                    this.PageTemplateASCX.hideTxtBox2();
                    this.PageTemplateASCX.hideTxtBox8();

                    this.PageTemplateASCX.txtbox6head = "Perks ID";
                    //this.PageTemplateASCX.txtbox7head = "Activity Day";

                    this.PageTemplateASCX.hideTxtBox4();
                    this.PageTemplateASCX.hideTxtBox5();
                    this.PageTemplateASCX.hideTxtBox7();
                    this.PageTemplateASCX.hideTxtBox11();
                    this.PageTemplateASCX.hideTxtBox14();

                    this.PageTemplateASCX.hideNav4();
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
                    //buttons



                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
               
            }
            
            myaddButton = (Button)this.PageTemplateASCX.addButton;
            mysearchButton = (Button)this.PageTemplateASCX.searchButton;
            this.PageTemplateASCX.searchButtonClick += new EventHandler(search);
            this.PageTemplateASCX.addButtonClick += new EventHandler(add);
            //ViewState["dataSource"] = this.PageTemplateASCX.ds;
        }

        //search button event - added to the control
        private void search(object sender, System.EventArgs e)
        {
            ((GridView)this.PageTemplateASCX.gridview).DataBind();
            this.PageTemplateASCX.reset();
            //((GridView)this.PageTemplateASCX.gridview).DataSource = null;
            // this.PageTemplateASCX.ds = null;

            //CHANGE THIS-----------------------------------------------------------------------------------------FILL
            CarWebService.CarService pxy = new CarWebService.CarService();

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
                                pxy.GetRentalCarAgencies(((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset

                            if (this.PageTemplateASCX.ds != null)
                            {
                                ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource
                                ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                //((GridView)this.PageTemplateASCX.gridview).AutoGenerateColumns = false;
                                
                            }
                            else
                            { this.PageTemplateASCX.noSearchResults(); }
                            break;
                        case "2": //search 2
                            if (((TextBox)this.PageTemplateASCX.txtbox3control).Text != "")
                            {
                                try
                                {
                                    //REPLACE THIS METHOD //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                    this.PageTemplateASCX.ds =
                                    pxy.GetCarsByAgency(Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox3control).Text), ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset

                                    if (this.PageTemplateASCX.ds != null)
                                    {
                                        ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                        ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                       
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                }
                                catch (FormatException a)
                                {
                                    this.PageTemplateASCX.displayVal3();
                                    this.PageTemplateASCX.failedSearchResults();
                                }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal3();
                                this.PageTemplateASCX.failedSearchResults();
                            }

                            break;
                        case "3": //search 3
                            if (((TextBox)this.PageTemplateASCX.txtbox6control).Text != "")
                            {
                                try
                                {
                                    //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                    CarWebService.CarPerks perks = new CarPerks();
                                    perks.PerkID = Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox6control).Text);
                                    String[] perkArray = { ((TextBox)this.PageTemplateASCX.txtbox7control).Text };

                                    perks.PerkName = perkArray;
                                    //this.PageTemplateASCX.ds = null;
                                    //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                    this.PageTemplateASCX.ds = pxy.FindCars(perks, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset

                                    if (this.PageTemplateASCX.ds != null)
                                    {
                                        ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                        ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                        
                                        /*
                                        for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                        {
                                            String image = "";
                                            image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                            ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                        }
                                        */
                                    }



                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                }
                                catch (FormatException a)
                                {
                                    this.PageTemplateASCX.displayVal6();
                                    this.PageTemplateASCX.displayVal7();
                                    this.PageTemplateASCX.failedSearchResults();
                                }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal6();
                                this.PageTemplateASCX.displayVal7();
                                this.PageTemplateASCX.failedSearchResults();
                            }

                            break;
                        case "4": //search 4
                            if (((TextBox)this.PageTemplateASCX.txtbox9control).Text != ""
                                && ((TextBox)this.PageTemplateASCX.txtbox10control).Text != "")
                            {
                                try
                                {
                                    //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                    CarWebService.CarPerks perks = new CarPerks();
                                    perks.PerkID = Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox9control).Text);
                                    String[] perkArray = { ((TextBox)this.PageTemplateASCX.txtbox10control).Text };

                                    perks.PerkName = perkArray;
                                    //this.PageTemplateASCX.ds = null;

                                    //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                    this.PageTemplateASCX.ds = pxy.FindCarByAgency(Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox9control).Text),
                                         ((TextBox)this.PageTemplateASCX.stateCritbox).Text, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, perks); //get appropriate dataset
                                                                                                                                                        //ViewState["dataSource"] = this.PageTemplateASCX.ds;
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
                                        
                                        for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                        {
                                            String image = "";
                                            image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                            ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[6].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                        }
                                        
                                    }



                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }


                                }
                                catch (FormatException a)
                                {
                                    this.PageTemplateASCX.displayVal9();
                                    this.PageTemplateASCX.displayVal10();
                                    this.PageTemplateASCX.failedSearchResults();
                                }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal9();
                                this.PageTemplateASCX.displayVal10();
                                this.PageTemplateASCX.failedSearchResults();
                            }
                            break;
                        case "5": //search 4
                            /*
                            if (((TextBox)this.PageTemplateASCX.txtbox12control).Text != ""
                                && ((TextBox)this.PageTemplateASCX.txtbox13control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                CarWebService.Activity activity = new Activity();
                                activity.activityType = ((TextBox)this.PageTemplateASCX.txtbox12control).Text;
                                CarWebService.Agencies agency = new Agencies();
                                agency.agenciesName = ((TextBox)this.PageTemplateASCX.txtbox13control).Text;

                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds = pxy.FindActivities(agency, activity, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset

                                if (this.PageTemplateASCX.ds != null)
                                {
                                    // ViewState["dataSource"] = this.PageTemplateASCX.ds;
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                    /*
                                    for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                    {
                                        String image = "";
                                        image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                        ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                    }
                                    
                                }



                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal12();
                                this.PageTemplateASCX.displayVal13();
                                this.PageTemplateASCX.failedSearchResults();
                            }*/
                            break;
                        default:

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
            //((GridView)this.PageTemplateASCX.gridview).DataBind();
            this.PageTemplateASCX.reset();
            //((GridView)this.PageTemplateASCX.gridview).DataSource = ViewState["dataSource"];
            //((GridView)this.PageTemplateASCX.gridview).DataBind();

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
                        CarClass newCar = new CarClass();
                        //initialize its properities to the record's values that was chosen

                        newCar.agencyID = Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox9control).Text);

                        newCar.CarID = ((GridView)this.PageTemplateASCX.gridview).Rows[j].Cells[5].Text;
                        newCar.Cost = ((GridView)this.PageTemplateASCX.gridview).Rows[j].Cells[3].Text;

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
                        this.PageTemplateASCX.myPackage.carArray.Add(newCar);
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