using System.ComponentModel;

namespace MudServer.Common.Enums
{
    public enum Genre
    {
        [Description("Fantasy")]
        Fantasy = 0,
        [Description("Scy-Fi")]
        Scyfy = 1,
        [Description("Historical")]
        Historical = 2,
    }
}
