﻿using System;

using R5T.D0082;


namespace R5T.T0139.N002
{
    public class RemoteRepositoryContext : IRemoteRepositoryContext
    {
        public D0082.IGitHubOperator GitHubOperator { get; set; }

        public string Name { get; set; }

        public IRemoteRepositoryContext RemoteRepositoryContext_N002 => this;
    }
}
