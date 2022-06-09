using System;

using R5T.D0037;
using R5T.T0064;


namespace R5T.T0139.N003
{
    [ServiceImplementationMarker]
    public class LocalRepositoryContextProvider : ILocalRepositoryContextProvider, IServiceImplementation
    {
        public IGitOperator GitOperator { get; }


        public LocalRepositoryContextProvider(
            IGitOperator gitOperator)
        {
            this.GitOperator = gitOperator;
        }
    }
}
