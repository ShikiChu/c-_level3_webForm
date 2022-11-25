using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterPage
{
    public class Member
    {
        public int Id { get; }
        public string Name { get; }

        public string preference { get; }

        public int count { get; set; }

        public double hours { get; set; }

        public List<Services> RegisteredService { get; }

        //Constructor
        public Member(string name, string preference)
        {
            Name = name;
            Random rand = new Random();
            Id = rand.Next(10000, 100000);
            RegisteredService = new List<Services>();
            this.preference = preference;
        }

        //Methods
        public virtual void Appointment(List<Services> selectedServices)
        {
            RegisteredService.Clear();
            foreach (Services service in selectedServices)
            {
                RegisteredService.Add(service);
            }
        }

        public int countService(List<Services> selectedServices)
        {
            count = selectedServices.Count;
            return count;
        }

        public double TotalServiceHours(List<Services> selectedServices)
        {
            hours = 0;
            foreach (Services s in selectedServices)
            {
                hours += s.ServiceHours;
            }
            return hours;
        }

        public override string ToString()
        {
            return string.Format($"{Id} - {Name}");
        }
    }
}