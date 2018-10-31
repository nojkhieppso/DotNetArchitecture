namespace Solution.CrossCutting.Security
{
    public interface IHash
    {
        string Create(string value);
    }
}
