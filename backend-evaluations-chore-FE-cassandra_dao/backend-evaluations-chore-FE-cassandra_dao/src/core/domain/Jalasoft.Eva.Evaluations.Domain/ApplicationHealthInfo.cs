namespace Jalasoft.Eva.Evaluations.Domain
{
    public partial class ApplicationHealthInfo
    {
        public ApplicationInfo Application { get; set; }

        public ApplicationHealthStatus Status { get; set; }
    }
}
