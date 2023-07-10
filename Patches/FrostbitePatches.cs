
namespace SkyLib
{
    public static class OniUtils
    {
        public static void AddStatusItem(string status_id, string stringtype, string statusitem, string category = "MISC")
        {
            category = category.ToUpperInvariant();
            Strings.Add($"STRINGS.{category}.STATUSITEMS.{status_id.ToUpperInvariant()}.{stringtype.ToUpperInvariant()}",
                statusitem);
        }
    }
}
