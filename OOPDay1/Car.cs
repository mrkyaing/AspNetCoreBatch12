using System;
namespace OOPDay1
{
    public class Car
    {
        //states/members
        public string Color { get; set; }
        public string Model { get; set; }  
        private string licenceNo;
        public string   LicenceNo
        {
            get { return licenceNo; }
            set { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("invalid Licence no");
                }
                licenceNo = value; 
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set { type = value; }
        }
        private string gearNo;
        public string GearNo
        {
            get
            {
                return gearNo;
            }
            set
            {
               gearNo= value;
            }
        }
        //behaviors
        public void Drive()
        {
            Console.WriteLine("car is driving with gear no" + gearNo);
            if ( gearNo.Equals("p",StringComparison.OrdinalIgnoreCase))
            {
                this.ChangePinion(0);
            }
            else if (gearNo.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                this.ChangePinion(3);
            }
            else if (gearNo.Equals("r", StringComparison.OrdinalIgnoreCase))
            {
                this.ChangePinion(5);
            }
        
        }
        public void StartEngine() => Console.WriteLine("start the Engine");
        public void StopEngine() => Console.WriteLine("stop the engine");
        public void PlayHorn(int count)
        {
            for (int i =1;i<= count;i++)
            {
                Console.WriteLine("T");
            }
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Car Model {Model}");
            Console.WriteLine($"Color {Color}");
            Console.WriteLine($"Type {Type}");
            Console.WriteLine($"LicenceNo {LicenceNo}");
            Console.WriteLine($"Gear No :{GearNo}");
        }

        private void ChangePinion(int pinion)
        {
            Console.WriteLine("Change pinion " + pinion);
        }
    }
}
