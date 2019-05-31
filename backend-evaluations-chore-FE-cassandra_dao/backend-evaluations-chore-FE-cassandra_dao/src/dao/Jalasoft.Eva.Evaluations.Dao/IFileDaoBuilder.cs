namespace Jalasoft.Eva.Evaluations.Dao
{
    public interface IFileDaoBuilder<T>
    {
        T CreateFromFile(string fileName);
    }
}
