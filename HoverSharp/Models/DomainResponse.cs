using System.Collections.Generic;

namespace HoverSharp.Models
{

    public class DomainResponse 
    {
        public bool succeeded { get; set; }
        public List<Domain> domains { get; set; }
    }

    public class Domain
    {
        public string id { get; set; }
        public string domain_name { get; set; }
        public int num_emails { get; set; }
        public string renewal_date { get; set; }
        public string display_date { get; set; }
        public string registered_date { get; set; }
        public string status { get; set; }
        public bool auto_renew { get; set; }
        public bool renewable { get; set; }
        public bool locked { get; set; }
        public bool whois_privacy { get; set; }
        public string auth_code { get; set; }
        public string[] nameservers { get; set; }
        public Contacts contacts { get; set; }
        public Glue glue { get; set; }
        public Hover_User hover_user { get; set; }
        public bool active { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Contacts
    {
        public Admin admin { get; set; }
        public Owner owner { get; set; }
        public Tech tech { get; set; }
    }

    public class Admin
    {
        public string country { get; set; }
        public string address3 { get; set; }
        public string org_name { get; set; }
        public string phone { get; set; }
        public string address2 { get; set; }
        public string last_name { get; set; }
        public string state { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string fax { get; set; }
        public string address1 { get; set; }
        public string first_name { get; set; }
        public string zip { get; set; }
    }

    public class Owner
    {
        public string country { get; set; }
        public string address3 { get; set; }
        public string org_name { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string last_name { get; set; }
        public string address2 { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string fax { get; set; }
        public string address1 { get; set; }
        public string first_name { get; set; }
        public string zip { get; set; }
    }

    public class Tech
    {
        public string country { get; set; }
        public string address3 { get; set; }
        public string org_name { get; set; }
        public string phone { get; set; }
        public string address2 { get; set; }
        public string state { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string fax { get; set; }
        public string address1 { get; set; }
        public string first_name { get; set; }
        public string zip { get; set; }
    }

    public class Glue
    {
    }

    public class Hover_User
    {
        public string email { get; set; }
        public object email_secondary { get; set; }
        public Billing billing { get; set; }
    }

    public class Billing
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string pay_mode { get; set; }
        public string card_number { get; set; }
        public string card_expires { get; set; }
    }

}
