using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using System.Data;
namespace TravelSite
{
    public partial class PageTempleASCX : System.Web.UI.UserControl
    {
        public String title { set { pagetitle.InnerText = value; } }
        public String navDefaultHeading { set { navDefault.InnerText = value; } }
        public String navHeading2 { set { navAgency.InnerText = value; } }
        public String navHeading3 { set { navActivity.InnerText = value; } }
        public String navHeading4 { set { navAgencyAndActivity.InnerText = value; } }
        public String navHeading5 { set { navSearch4.InnerText = value; } }

        //city and state labels
        public String cityCrit { set { cityCriteria.InnerText = value; } }
        public String stateCrit { set { stateCriteria.InnerText = value; } }
        //city and state text boxes
        public Control cityCritbox { get { return txtCity; } }
        public Control stateCritbox { get { return txtState; } }
        //city and state validators
        public Control cityValidator { get { return valCity; } }
        public Control stateValidator { get { return valState; } }
        //TEXTBOX LABELS
        //default search
        public String txtbox1head { set { txtbox1Heading.InnerText = value; } }
        public String txtbox2head { set { txtbox2Heading.InnerText = value; } }
        //search2
        public String txtbox3head { set { txtbox3Heading.InnerText = value; } }
        public String txtbox4head { set { txtbox4Heading.InnerText = value; } }
        public String txtbox5head { set { txtbox5Heading.InnerText = value; } }
        //search3
        public String txtbox6head { set { txtbox6Heading.InnerText = value; } }
        public String txtbox7head { set { txtbox7Heading.InnerText = value; } }
        public String txtbox8head { set { txtbox8Heading.InnerText = value; } }
        //search4
        public String txtbox9head { set { txtbox9Heading.InnerText = value; } }
        public String txtbox10head { set { txtbox10Heading.InnerText = value; } }
        public String txtbox11head { set { txtbox11Heading.InnerText = value; } }
        //search5
        public String txtbox12head { set { txtbox12Heading.InnerText = value; } }
        public String txtbox13head { set { txtbox13Heading.InnerText = value; } }
        public String txtbox14head { set { txtbox14Heading.InnerText = value; } }


        //TEXTBOX VALIDATORS
        //defaultSearch
        public Control txtbox1validator { get { return valtxtbox1; } }
        public Control txtbox2validator { get { return valtxtbox2; } }
        //search2
        public Control txtbox3validator { get { return valtxtbox3; } }
        public Control txtbox4validator { get { return valtxtbox4; } }
        public Control txtbox5validator { get { return valtxtbox5; } }
        //search3
        public Control txtbox6validator { get { return valtxtbox6; } }
        public Control txtbox7validator { get { return valtxtbox7; } }
        public Control txtbox8validator { get { return valtxtbox8; } }
        //search4
        public Control txtbox9validator { get { return valtxtbox9; } }
        public Control txtbox10validator { get { return valtxtbox10; } }
        public Control txtbox11validator { get { return valtxtbox11; } }
        //search5
        public Control txtbox12validator { get { return valtxtbox12; } }
        public Control txtbox13validator { get { return valtxtbox13; } }
        public Control txtbox14validator { get { return valtxtbox14; } }


        //TXTBOX CONTROL
        //defaultSearch
        public Control txtbox1control { get { return txtbox1; } }
        public Control txtbox2control { get { return txtbox2; } }
        //search2
        public Control txtbox3control { get { return txtbox3; } }
        public Control txtbox4control { get { return txtbox4; } }
        public Control txtbox5control { get { return txtbox5; } }
        //search 3
        public Control txtbox6control { get { return txtbox6; } }
        public Control txtbox7control { get { return txtbox7; } }
        public Control txtbox8control { get { return txtbox8; } }
        //search4
        public Control txtbox9control { get { return txtbox9; } }
        public Control txtbox10control { get { return txtbox10; } }
        public Control txtbox11control { get { return txtbox11; } }
        //search5
        public Control txtbox12control { get { return txtbox12; } }
        public Control txtbox13control { get { return txtbox13; } }
        public Control txtbox14control { get { return txtbox14; } }


        //error messages  
        public Control failedSearchError { get { return failedSearch; } }
        public Control failedAddError { get { return failedAdd; } }
        public Control noResultsError { get { return noResults; } }
        public Control successfulAddMessage { get { return successfulAdd; } }

        //gridview
        public Control gridview { get { return gvAvailable; } }

        //buttons
        public Control addButton { get { return btnAdd; } }
        public Control searchButton { get { return btnSearch; } }

        //viewstate object
        public object viewState { get { return ViewState["method"]; } set { ViewState["method"] = value; } }

        //EVENT HANDLERS FOR THE BUTTONS
        public event EventHandler searchButtonClick;
        public event EventHandler addButtonClick;

        //OTHER PROPERTIES
        public DataSet defaultData;
        public DataSet ds; //set up dataset
        public HttpCookie objCookie; //setup cookie
        public VacationPackage myPackage; //user's vacation package
        public ExperienceClass newExp;
        public String method = ""; //string to carry web method name
        //this will be used to know which column to extract the correct value for creating an object
        //because methods may return different fields 

        public void Page_Load(object sender, EventArgs e)
        {
            objCookie = Request.Cookies["TravelSite"];

            if (!Page.IsPostBack)
            {
                //copy and paste to check if a user is logged in

                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {
                    myPackage = VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString());

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.searchButtonClick != null)
                this.searchButtonClick(this, e);
        }



        /*
        public  void btnSearch_Click(object sender, EventArgs e)
        {
            reset();
            gvAvailable.DataSource = null;
            ds = null;
            ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
            if (validateRequirements())
            {
                if (ViewState["method"] != null)
                {
                    switch (ViewState["method"].ToString())
                    {
                        case "default":
                            ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                            if (ds != null)
                            {
                                gvAvailable.DataSource = ds; //assign as datasource
                                gvAvailable.DataBind(); //databind it to gridview
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                    btnAdd.Enabled = true;
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }
                            break;
                        case "byAgency":
                            if (validate2())
                            {
                                ExperienceWebService.Agency agency = new Agency();
                                agency.Agency_id = Convert.ToInt32(txtbox1.Text);

                                ds = pxy.GetActivities(agency, txtState.Text, txtCity.Text); //get appropriate dataset
                                if (ds != null)
                                {
                                    gvAvailable.DataSource = ds; //assign as datasource

                                    gvAvailable.DataBind(); //databind it to gridview
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        btnAdd.Enabled = true;

                                    }
                                    else
                                    { noResults.Style["display"] = "block"; }
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }

                            break;
                        case "byActivity":
                            if (txtbox2.Text != "")
                            {

                                ExperienceWebService.Activities activity = new Activities();
                                activity.Activity_type = txtbox2.Text;
                                activity.Activity_startDate = "02/02/2018";
                                activity.Activity_enddate = "02/03/2018";
                                ds = null;
                                ds = pxy.FindActivities(activity, txtState.Text, txtCity.Text); //get appropriate dataset
                                if (ds != null)
                                {
                                    gvAvailable.DataSource = ds; //assign as datasource

                                    gvAvailable.DataBind(); //databind it to gridview
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {

                                        btnAdd.Enabled = true;
                                    }
                                    else
                                    { noResults.Style["display"] = "block"; }

                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; valtxtbox2.Style["display"] = "inline"; }
                            break;
                        case "byVenue":

                            break;
                        case "byAgencyAndActivity":

                            break;
                        default:
                            ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                            if (ds != null)
                            {
                                gvAvailable.DataSource = ds; //assign as datasource
                                gvAvailable.DataBind(); //databind it to gridview
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                    btnAdd.Enabled = true;
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }
                            break;
                    }
                }
            }
            else
            {
                ViewState["method"] = "default";
            }
        }
        */
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.addButtonClick != null)
                this.addButtonClick(this, e);
        }
        /*
        public void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            int selectedCount = 0; //count number selected
            for (int i = 0; i < gvAvailable.Rows.Count; i++) //count
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; } //if selected, increment counter
            }
            if (selectedCount == 0) //if none selected
            {
                failedAdd.Style["display"] = "block";
            }
            else //if at least one selected
            {
                //reloop through gridview
                for (int j = 0; j < gvAvailable.Rows.Count; j++)
                {
                    //if the select box is checked..
                    CheckBox selected = (CheckBox)gvAvailable.Rows[j].FindControl("chkSelect");
                    if (selected.Checked == true)
                    {
                        //create a new object
                        ExperienceClass newExp = new ExperienceClass();
                        //initialize its properities to the record's values that was chosen
                        newExp.Agency_id = 1;

                        //if a vacation package exists
                        if (VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString()) == null)
                        {
                            myPackage = new VacationPackage(); //if not, create a new one
                        }
                        else
                        {
                            //if yes, retrieve the package
                            myPackage = VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString());
                        }
                        //finally, add the new object to the vacation package's appropriate list
                        myPackage.experienceArray.Add(newExp);
                    }
                }
                //update the vacation package in the database
                VacationPackage.updatePackage(objCookie.Values["LoginID"].ToString(), myPackage);
                successfulAdd.Style["display"] = "block";
            }

        }
        */
        //---------------------------------------------------------------------------------------------------------------------
        //PRIVATE METHODS -----------------------------------------------------------------------------------------------------

        public Boolean validateRequirements()
        {
            Boolean valid = true;
            if (txtCity.Text == "")
            {
                valid = false;
                valCity.Style["display"] = "inline";
                failedSearch.Style["display"] = "block";
            }
            if (txtState.Text == "")
            {
                valid = false;
                valState.Style["display"] = "inline";
                failedSearch.Style["display"] = "block";
            }
            return valid;
        }

        public Boolean validate2()
        {
            Boolean valid = true;
            if (txtbox1.Text == "")
            {
                failedSearch.Style["display"] = "block";
                txtbox1.Style["display"] = "inline";
                valid = false;
            }
            else if (txtbox1.Text != "")
            {
                try
                {
                    int convertedID = Convert.ToInt32(txtbox1.Text);
                }
                catch (FormatException e)
                {
                    valid = false;
                }
            }
            return valid;
        }
        public void reset() //resets error and validation messages
        {
            //reset error messagess
            failedAdd.Style["display"] = "none";
            successfulAdd.Style["display"] = "none";
            failedSearch.Style["display"] = "none";
            noResults.Style["display"] = "none";
           
            //reset validation
            valCity.Style["display"] = "none";
            valState.Style["display"] = "none";
            valtxtbox1.Style["display"] = "none";
            valtxtbox2.Style["display"] = "none";
            valtxtbox3.Style["display"] = "none";
            valtxtbox4.Style["display"] = "none";
            valtxtbox5.Style["display"] = "none";
            valtxtbox6.Style["display"] = "none";
            valtxtbox7.Style["display"] = "none";
            valtxtbox8.Style["display"] = "none";
            valtxtbox9.Style["display"] = "none";
            valtxtbox10.Style["display"] = "none";
            valtxtbox11.Style["display"] = "none";
            valtxtbox12.Style["display"] = "none";
            valtxtbox13.Style["display"] = "none";
            valtxtbox14.Style["display"] = "none";

        }

        public void resetSearch() //resets search section visibility
        {
            searchDefault.Style["display"] = "none";
            search2.Style["display"] = "none";
            search3.Style["display"] = "none";
            search4.Style["display"] = "none";
            search5.Style["display"] = "none";
        }

        //-------------------------------------------------------------------------------------------------------------
        //SPECIFIES WEB METHOD IN VIEW STATE OBJECT DEPENDING ON SEARCH TAB THAT WAS CLICKED

        //DISPLAYS APPROPRIATE SEARCH SECTION
        public void displayDefault(object Source, EventArgs e) 
        {
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            ViewState["method"] = "default";
            searchDefault.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display2(object Source, EventArgs e) 
        {

            //ViewState["method"] = "byAgency";
            ViewState["method"] = "2";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search2.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display3(object Source, EventArgs e) 
        {
            //ViewState["method"] = "byActivity";
            ViewState["method"] = "3";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search3.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display4(object Source, EventArgs e)
        {
            //ViewState["method"] = "byAgencyAndActivity";
            ViewState["method"] = "4";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search4.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display5(object Source, EventArgs e)
        {
            //ViewState["method"] = "byAgencyAndActivity";
            ViewState["method"] = "5";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search5.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        //DISPLAY ERROR / SUCCESS MESSAGES
        public void noSearchResults()
        {
            noResults.Style["display"] = "block";
        }

        public void failedAddResults()
        {
            failedAdd.Style["display"] = "block";
        }

        public void successfulAddResults()
        {
            successfulAdd.Style["display"] = "block";
        }

        public void failedSearchResults()
        {
            failedSearch.Style["display"] = "block";
        }
    
        //DISPLAY VALIDATORS
        public void displayCityVal() { valCity.Style["display"] = "inline"; }
        public void displayStateVal() { valState.Style["display"] = "inline"; }
        public void displayVal1() { valtxtbox1.Style["display"] = "inline"; }
        public void displayVal2() { valtxtbox2.Style["display"] = "inline"; }
        public void displayVal3() { valtxtbox3.Style["display"] = "inline"; }
        public void displayVal4() { valtxtbox4.Style["display"] = "inline"; }
        public void displayVal5() { valtxtbox5.Style["display"] = "inline"; }
        public void displayVal6() { valtxtbox6.Style["display"] = "inline"; }
        public void displayVal7() { valtxtbox7.Style["display"] = "inline"; }
        public void displayVal8() { valtxtbox8.Style["display"] = "inline"; }
        public void displayVal9() { valtxtbox9.Style["display"] = "inline"; }
        public void displayVal10() { valtxtbox10.Style["display"] = "inline"; }
        public void displayVal11() { valtxtbox11.Style["display"] = "inline"; }
        public void displayVal12() { valtxtbox12.Style["display"] = "inline"; }
        public void displayVal13() { valtxtbox13.Style["display"] = "inline"; }
        public void displayVal14() { valtxtbox14.Style["display"] = "inline"; }

        //HIDE VALIDATORS
        public void hideCityVal() { valCity.Style["display"] = "none"; }
        public void hideStateVal() { valState.Style["display"] = "none"; }
        public void hideVal1() { valtxtbox1.Style["display"] = "none"; }
        public void hideVal2() { valtxtbox2.Style["display"] = "none"; }
        public void hideVal3() { valtxtbox3.Style["display"] = "none"; }
        public void hideVal4() { valtxtbox4.Style["display"] = "none"; }
        public void hideVal5() { valtxtbox5.Style["display"] = "none"; }
        public void hideVal6() { valtxtbox6.Style["display"] = "none"; }
        public void hideVal7() { valtxtbox7.Style["display"] = "none"; }
        public void hideVal8() { valtxtbox8.Style["display"] = "none"; }
        public void hideVal9() { valtxtbox9.Style["display"] = "none"; }
        public void hideVal10() { valtxtbox10.Style["display"] = "none"; }
        public void hideVal11() { valtxtbox11.Style["display"] = "none"; }
        public void hideVal12() { valtxtbox12.Style["display"] = "none"; }
        public void hideVal13() { valtxtbox13.Style["display"] = "none"; }
        public void hideVal14() { valtxtbox14.Style["display"] = "none"; }

        //hide unnecessary textboxes, and their headings & validators
        public void hideTxtBox1() { txtbox1Heading.Visible = false; valtxtbox1.Visible = false; txtbox1.Visible = false; }
        public void hideTxtBox2() { txtbox2Heading.Visible = false; valtxtbox2.Visible = false; txtbox2.Visible = false; }
        public void hideTxtBox3() { txtbox3Heading.Visible = false; valtxtbox3.Visible = false; txtbox3.Visible = false; }
        public void hideTxtBox4() { txtbox4Heading.Visible = false; valtxtbox4.Visible = false; txtbox4.Visible = false; }
        public void hideTxtBox5() { txtbox5Heading.Visible = false; valtxtbox5.Visible = false; txtbox5.Visible = false; }
        public void hideTxtBox6() { txtbox6Heading.Visible = false; valtxtbox6.Visible = false; txtbox6.Visible = false; }
        public void hideTxtBox7() { txtbox7Heading.Visible = false; valtxtbox7.Visible = false; txtbox7.Visible = false; }
        public void hideTxtBox8() { txtbox8Heading.Visible = false; valtxtbox8.Visible = false; txtbox8.Visible = false; }
        public void hideTxtBox9() { txtbox9Heading.Visible = false; valtxtbox9.Visible = false; txtbox9.Visible = false; }
        public void hideTxtBox10() { txtbox10Heading.Visible = false; valtxtbox10.Visible = false; txtbox10.Visible = false; }
        public void hideTxtBox11() { txtbox11Heading.Visible = false; valtxtbox11.Visible = false; txtbox11.Visible = false; }
        public void hideTxtBox12() { txtbox12Heading.Visible = false; valtxtbox12.Visible = false; txtbox12.Visible = false; }
        public void hideTxtBox13() { txtbox13Heading.Visible = false; valtxtbox13.Visible = false; txtbox13.Visible = false; }
        public void hideTxtBox14() { txtbox14Heading.Visible = false; valtxtbox14.Visible = false; txtbox14.Visible = false; }

    }

}