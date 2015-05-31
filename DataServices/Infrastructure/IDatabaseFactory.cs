using System;

namespace DataServices.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PredictionEntities Get();
    }
}
