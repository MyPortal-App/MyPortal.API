namespace MyPortal.Services.Connetion
{
    public interface IConnectionManager<TConnection>
    {
        TConnection GetConnection();
    }
}
