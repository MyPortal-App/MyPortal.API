namespace MyPortal.Services.Connetion
{
    public interface IConnectionStringProvider<TContext>
    {
        string GetConnectionString(TContext context);
    }
}
