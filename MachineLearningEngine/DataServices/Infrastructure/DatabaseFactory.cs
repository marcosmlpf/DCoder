
namespace DataServices.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private PredictionEntities dataContext;
    public PredictionEntities Get()
    {
        return dataContext ?? (dataContext = new PredictionEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
