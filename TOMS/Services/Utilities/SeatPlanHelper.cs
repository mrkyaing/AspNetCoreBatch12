using TOMS.Models.ViewModels;

namespace TOMS.Services.Utilities
{
    public static class SeatPlanHelper
    {
        public static List<SeatPlan> GetSeatPlans()
        {
            return new List<SeatPlan> { 
                new SeatPlan("A1") ,new SeatPlan("A2"),
                new SeatPlan("B1"),new SeatPlan("B2"), 
                new SeatPlan("C1") , new SeatPlan("C2"), 
                new SeatPlan("D1") , new SeatPlan("D2"), 
                new SeatPlan("E1"), new SeatPlan("E2") ,
                new SeatPlan("F1"), new SeatPlan("F2"),
                new SeatPlan("G1"), new SeatPlan("G2"),
                new SeatPlan("H1"), new SeatPlan("H2"),
                new SeatPlan("I1"), new SeatPlan("I2"),
                new SeatPlan("J1"), new SeatPlan("J2"),
                new SeatPlan("K1") ,new SeatPlan("K2"),
                new SeatPlan("L1"),new SeatPlan("L2"),
                new SeatPlan("M1") , new SeatPlan("M2"),
                new SeatPlan("N1") , new SeatPlan("N2"),
                new SeatPlan("O1"), new SeatPlan("O2") ,
                new SeatPlan("P1"), new SeatPlan("P2"),
                new SeatPlan("Q1"), new SeatPlan("Q2"),
                new SeatPlan("R1"), new SeatPlan("R2"),
                new SeatPlan("S1"), new SeatPlan("S2"),
                new SeatPlan("T1"), new SeatPlan("T2")
            };
        }
    }
}
