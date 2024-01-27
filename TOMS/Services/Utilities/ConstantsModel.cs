using System.ComponentModel;

namespace TOMS.Services.Utilities
{
    public static class ConstantsModel
    {
        public const string BUS_LINE_TYPE_VIP = "VIP";
        public const string BUS_LINE_TYPE_NORMAL = "NORMAL";

        public const string PASSENGER_TYPE_LOCAL = "LOCAL";
        public const string PASSENGER_TYPE_FOREIGN = "FOREIGN";

       public enum TicketOrderTransactionStatus
        {
            [Description("Unpaid")]
            Unpaid,
            [Description("Paid")]
            Paid
        }
        public enum TicketSeatStatus
        {
            [Description("Reserved")]
            Reserved,
            [Description("Confirmed")]
            Confirmed,
            [Description("Pending")]
            Pending,
            [Description("Cancaled")]
            Cancaled
        }
    }
}
