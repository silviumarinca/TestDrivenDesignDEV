namespace TradeProcessorWithAbstraction
{
    public interface ITradeValidator
    {

        bool Validate(string[] lines);
    }
}