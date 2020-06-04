namespace SimpleBank.Core.Models.Abstractions
{
    public interface IDataObject<out TId>
    {
        public TId Id { get; }
    }
}