namespace Jalasoft.Eva.Evaluations.Domain
{
    using System.Text;

    public partial class ApplicationInfo
    {
        public static bool operator !=(ApplicationInfo info1, ApplicationInfo info2)
        {
            return !info1.Equals(info2);
        }

        public static bool operator ==(ApplicationInfo info1, ApplicationInfo info2)
        {
            return info1.Equals(info2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder()
                .AppendFormat("{{ ")
                .AppendFormat("id: {0}", this.Id)
                .AppendFormat("name: {0}", this.Name)
                .AppendFormat("version: {0}", this.Version)
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

            var appInfo = (ApplicationInfo)obj;

            return (appInfo.Id == this.Id)
                && (appInfo.Name == this.Name)
                && (appInfo.Version == this.Version);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + this.Id.GetHashCode();
                hash = (hash * 7) + this.Name.GetHashCode();
                hash = (hash * 7) + this.Version.GetHashCode();
                return hash;
            }
        }
    }
}
