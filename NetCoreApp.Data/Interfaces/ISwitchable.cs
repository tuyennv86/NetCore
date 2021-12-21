using NetCoreApp.Data.Enums;

namespace NetCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
