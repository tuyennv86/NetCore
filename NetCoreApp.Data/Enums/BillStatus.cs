using System.ComponentModel;

namespace NetCoreApp.Data.Enums
{
    public enum BillStatus
    {
        [Description("New Bill")]
        New,
        [Description("In Progress")]
        InProgress,
        [Description("Returned")]
        Returned,
        [Description("Cancelled")]
        Cancelled,
        [Description("Completed")]
        Compelted
    }
}
