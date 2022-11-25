using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class About : System.Web.UI.Page
    {
        protected List<Member> memberList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memberList"] != null)
            {
                memberList = (List<Member>)Session["memberList"]; //retrieve session
            }
            else
            {
                memberList = new List<Member>();
                Session["memberList"] = memberList;// store session
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // turn off the validation for next part
            rfvDrpMember.Enabled = false;

            bool showNextStep = false;  

            if (drpMembership.SelectedIndex == 1)
            {
                PlatinumMember platinumMember = new PlatinumMember(txtName.Text, rblPreference.SelectedItem.Value);
                memberList.Add(platinumMember);
                showNextStep= true;
            }
            else if (drpMembership.SelectedIndex == 2)
            {
                GoldMember goldMember = new GoldMember(txtName.Text, rblPreference.SelectedItem.Value);
                memberList.Add(goldMember);
                showNextStep = true;
            }
            else if (drpMembership.SelectedIndex == 3)
            {
                BronzeMember bronzeMember = new BronzeMember(txtName.Text, rblPreference.SelectedItem.Value);
                memberList.Add(bronzeMember);
                showNextStep = true;
            }

            Session["memberList"] = memberList;

            //back to default value for step 1 
            txtName.Text = "";
            drpMembership.SelectedIndex = 0;
            rblPreference.SelectedIndex = -1;
            

            // process to  step 2 when no error
            if (showNextStep==true)
            {
               //clear items first, otherwise, items duplicates!
                drpMember.Items.Clear();
                drpMember.Items.Add("Select..");
                
                foreach (Member m in memberList)
                {
                    ListItem listItem = new ListItem(m.ToString());
                    drpMember.Items.Add(listItem);
                }

                drpMember.Visible = true;
                lbldrpMember.Visible = true;
                step2.Visible= true;
                BtnSave.Visible = true;

                List<Services> serviceList = ServiceContents.GetAvailableServices();
                checkList.Items.Clear();//clear the previous 
                foreach (Services s in serviceList)
                {
                    ListItem listItem = new ListItem
                    {
                        Text = $" {s.Code} {s.ServiceItem} - {s.ServiceHours} hours",
                        Value = s.Code
                    };
                    checkList.Items.Add(listItem);
                }
            }
        }

        protected void drpMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            rfvMembership.Enabled = false;
            rfvName.Enabled = false;
            rfvRadioButton.Enabled = false;

            Session["memberList"] = memberList;

            int index = drpMember.SelectedIndex;
            if (index == 0)
            {
                foreach (ListItem listItem in checkList.Items)
                {
                    listItem.Selected = false;
                }
            }
            else
            {
                //display pre-checked  & Preview user's choice
                List<Member> memberList = (List<Member>)Session["memberList"];
                List<Services> selectedServices = memberList[index - 1].RegisteredService;
                if (selectedServices.Count != 0)
                {
                    foreach (ListItem listItem in checkList.Items)
                    {
                        listItem.Selected = false;
                        foreach (Services s in selectedServices)
                        {
                            if (listItem.Value == s.Code)
                            {
                                listItem.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ListItem listItem in checkList.Items)
                    {
                        listItem.Selected = false;
                    }
                }
                lblSummary.Visible = true;
                lblSummary.Text = $"Preview: {selectedServices.Count} service(s), with total {memberList[index - 1].TotalServiceHours(selectedServices)} hours";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            rfvDrpMember.Enabled = true;
            rfvMembership.Enabled = false;
            rfvName.Enabled = false;
            rfvRadioButton.Enabled = false;

            try
            {
                //generate a list of selected courses
                List<Services> selected = new List<Services>();
                foreach (ListItem listItem in checkList.Items)
                {
                    if (listItem.Selected)
                    {
                        Services service = ServiceContents.GetServiceByCode(listItem.Value);
                        selected.Add(service);
                    }
                }
                //put selected service into the "Appointment" 
                List<Member> memberList = (List<Member>)Session["memberList"];
                Member m = memberList[drpMember.SelectedIndex - 1];
                m.Appointment(selected);
                m.countService(selected);
                m.TotalServiceHours(selected);

                if (IsPostBack)
                {
                    double hours = m.TotalServiceHours(selected);
                    int count = selected.Count;
                    if (count == 0)
                    {
                        lblSummary.Visible = false;
                        lblCheckListError.Visible = true;
                        lblCheckListError.Text = "You need to select at least one service for the appointment!";
                    }
                    else
                    {
                        lblCheckListError.Visible = false;
                        lblSummary.Visible = true;
                        lblSummary.Text = $"Successful added {count} item(s) of service, {hours} hours in total for this appointment.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSummary.Visible = false;
                lblCheckListError.Visible = true;
                lblCheckListError.Text = ex.Message;
            }
        }
    }
}