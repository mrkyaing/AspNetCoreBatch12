using OOPDay1;
using System;
try
{
	Car myCar = new Car();//create a car object / instance of Car class 
	myCar.Model = "M203";
	myCar.Type = "Truck";
	myCar.Color = "Black";
	myCar.LicenceNo = "YGN-203";
	myCar.GearNo = "D";
	myCar.StartEngine();
	myCar.Drive();
	myCar.PlayHorn(3);
	myCar.ShowInfo();
	myCar.StopEngine();
	Console.WriteLine("inheritance demo practice result");
	TruckCar tc= new TruckCar();
	tc.LicenceNo= "YGN-808";
	tc.Color = "red";
	tc.Type = "TruckCar";
	tc.GearNo = "R";
    tc.MaximunLoadInTon = 300;
    tc.ShowInfo();
	tc.LoadMaterial(100);
	tc.StartEngine();
	tc.PlayHorn(1);
	tc.StopEngine();

	TruckCar homeTruckCar = new TruckCar()
	{
		Type = "truck",
		LicenceNo = "MDY-606",
		MaximunLoadInTon = 1000,
		NumberOfWheel = 6,
		Color = "BLACK",
		Model="M2023",
		GearNo = "D",
	};
	homeTruckCar.LoadMaterial(10);
	homeTruckCar.LoadMaterial(20, "Generator Machine");
	homeTruckCar.ShowInfo();
	Console.WriteLine();
	Console.WriteLine("Hello");
}
catch (Exception e)
{
	Console.WriteLine($"Error occur because of {e.Message}");
}