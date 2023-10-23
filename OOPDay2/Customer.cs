using System;
namespace OOPDay2
{
    public class Customer
    {
        //member
        public string Name { get; set; }
        private string nrc;
        public string Nrc
        {
            get { return nrc; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("invalid nrc");
                nrc = value;
            }
        }
        private string phoneNumer;
        public string PhoneNumber
        {
            get { return phoneNumer; }
            set
            {
                if (value.Length < 0 || value.Length > 11)
                    throw new ArgumentException("invalid phone number");
                phoneNumer = value;
            }
        }
        public string Address { get; set; }
        //Has-A relationship
        public BankAccount BankAccount { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine("Customer information ");
            Console.WriteLine("Name:" + Name);
            Console.WriteLine(":" + Nrc);
            Console.WriteLine("PhoneNumber:" + PhoneNumber);
            Console.WriteLine("Address:" + Address);
        }
    }
}
