using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterPage
{
    public class ServiceContents
    {
        public static List<Services> GetAvailableServices()
        {
            List<Services> services = new List<Services>();

            Services service = new Services("RM30", "Remedial Massage");
            service.ServiceHours = 0.5;
            services.Add(service);

            service = new Services("RM60", "Relaxation Massage");
            service.ServiceHours = 1;
            services.Add(service);

            service = new Services("TM30", "Foot Massage");
            service.ServiceHours = 0.5;
            services.Add(service);

            service = new Services("OSM120", "Oil Swedish Massage PLUS Facial");
            service.ServiceHours = 2;
            services.Add(service);

            service = new Services("ATM150", "Anti-aging Treatment PLUS Massage");
            service.ServiceHours = 2.5;
            services.Add(service);

            service = new Services("DF90", "Deluxe Facial");
            service.ServiceHours = 1.5;
            services.Add(service);

            service = new Services("RMF90", "Remedial Massage PLUS Foot Massage");
            service.ServiceHours = 1.5;
            services.Add(service);

            return services;
        }

        public static Services GetServiceByCode(string code)
        {
            foreach (Services s in GetAvailableServices())
            {
                if (s.Code == code)
                {
                    return s;
                }
            }
            return null;
        }
    }
}