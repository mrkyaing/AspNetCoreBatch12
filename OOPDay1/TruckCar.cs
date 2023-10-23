using System;
namespace OOPDay1
{
    public class TruckCar :Car //Inheritance  >> OOD is-a-relationship
    {
        //specialization for Truck Car in here 
        public int MaximunLoadInTon { get; set; }
        public int  NumberOfWheel { get; set; }
        /// <summary>
        /// Load Metarial  by passing the ton in int type
        /// </summary>
        /// <param name="ton"></param>
        public void LoadMaterial(int ton)
        {
            if(ton < MaximunLoadInTon)
            {
                Console.WriteLine("load a material" + ton);
            }
            else
                Console.WriteLine("overload in ton !! maximun load is "+MaximunLoadInTon);
        }
        //compile time polymporhism >> method overloading 
        /// <summary>
        /// Load Metarial  by passing the ton and item type 
        /// </summary>
        /// <param name="ton"></param>
        /// <param name="itemType"></param>
        public void LoadMaterial(int ton,string itemType)//200,
        {
            if (ton < MaximunLoadInTon) 
            {
                Console.WriteLine($"Load a {itemType} with" + ton+"ton(s).");
            }
            else
                Console.WriteLine("overload in ton !! maximun load is " + MaximunLoadInTon);
        }
        public override void ShowInfo()
        {
            base.ShowInfo();//
            Console.WriteLine("Maximun load is " + MaximunLoadInTon);//runtime polymorphism >> Method override
            Console.WriteLine("Wheels :" + NumberOfWheel);
        }
    }
}
