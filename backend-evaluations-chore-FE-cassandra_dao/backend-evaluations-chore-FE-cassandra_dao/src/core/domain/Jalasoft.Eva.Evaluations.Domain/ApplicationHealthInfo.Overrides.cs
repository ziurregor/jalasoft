namespace Jalasoft.Eva.Evaluations.Domain
{
    using System.Text;

    public partial class ApplicationHealthInfo
    {
        public static bool operator !=(ApplicationHealthInfo info1, ApplicationHealthInfo info2)
        {
            return !info2.Equals(info2);
        }

        public static bool operator ==(ApplicationHealthInfo info1, ApplicationHealthInfo info2)
        {
            return info1.Equals(info2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder()
                .AppendFormat("{{ ")
                .AppendFormat("application: {0}", this.Application)
                .AppendFormat("status: {0}", this.Status)
                .AppendFormat(" }}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var appHealthInfo = (ApplicationHealthInfo)obj;

            return (appHealthInfo.Application == this.Application)
                && (appHealthInfo.Status == this.Status);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + this.Application.GetHashCode();
                hash = (hash * 7) + this.Status.GetHashCode();
                return hash;
            }
        }
    }
}
