namespace TradeProcessorWithAbstraction
{
    public interface ITradeMapper
    {
        TradeRecord Map(string[] lines);
    }
}