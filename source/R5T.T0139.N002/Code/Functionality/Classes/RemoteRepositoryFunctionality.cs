using System;


namespace R5T.T0139.N002
{
    public class RemoteRepositoryFunctionality : IRemoteRepositoryFunctionality
    {
        #region Infrastructure

        public static RemoteRepositoryFunctionality Instance { get; } = new();

        private RemoteRepositoryFunctionality()
        {
        }

        #endregion
    }
}
