namespace HouseRentSystem.Core.Exeptions
{
    public class UnauthoriseActionExeption : Exception
    {
        public UnauthoriseActionExeption() { }

        public UnauthoriseActionExeption(string message)
            : base(message) { }        
    }
}
