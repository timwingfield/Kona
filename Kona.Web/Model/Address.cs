using System;
using System.Text;

namespace Kona.Model
{
    public class Address
    {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool IsDefault { get; set; }

        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }
        
        }

        public Address(string userName, string first, string last, string email, string street1, string street2, string city, string state, string zip, string country)
        {
            UserName = userName;
            FirstName = first;
            LastName = last;
            Email = email;
            Street1 = street1;
            Street2 = street2;
            City = city;
            StateOrProvince = state;
            Zip = zip;
            Country = country;
        }

        /// <summary>
        /// ToString() override, which formats an Address in a Postal-service, readable way
        /// </summary>
        /// <returns>System.String</returns>       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}\r\n",FirstName, LastName);
            sb.AppendLine(Street1);
            if (!String.IsNullOrEmpty(Street2))
                sb.AppendLine(Street2);

            sb.AppendLine(City + ", " + StateOrProvince + " " + Zip + ", " + Country);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            try
            {
                Address compareTo = (Address)obj;
                result = Street1.Equals(compareTo.Street1, StringComparison.CurrentCultureIgnoreCase) &&
                    City.Equals(compareTo.City, StringComparison.CurrentCultureIgnoreCase);


            }
            catch
            {
                result = base.Equals(obj);
            }
            return result;

        }

        public override int GetHashCode() {
            return Street1.GetHashCode();
        }

    }
}
