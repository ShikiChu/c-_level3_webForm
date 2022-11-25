using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterPage
{
    public class PlatinumMember : Member
    {
        public static int MaxHours { get; set; }
        public static int MaxNumOfService { get; set; }

        //constructor:
        public PlatinumMember(string name, string preference) : base(name, preference)
        {
        }

        //override menthod
        public override void Appointment(List<Services> selectedServices)
        {
            double totalServiceHours = TotalServiceHours(selectedServices);
            int totalNumOfService = selectedServices.Count;

            //checking rules
            if (totalServiceHours > MaxHours)
            {
                throw new Exception($"Platinum members can enjoy free services for maximum {MaxHours} hours");
            }
            else if (totalNumOfService > MaxNumOfService)
            {
                throw new Exception($"Platinum members exceeds Maximum {MaxNumOfService} items of free services");
            }
            else
            {
                base.Appointment(selectedServices);
            }
        }

        public override string ToString()
        {
            return base.ToString() + "**Platinum Member**";
        }

    }
}