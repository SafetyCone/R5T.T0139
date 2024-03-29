﻿using System;

using R5T.D0037;
using R5T.T0137;


namespace R5T.T0139.N003
{
    [ContextImplementationMarker]
    public class LocalRepositoryContext : ILocalRepositoryContext
    {
        public IGitOperator GitOperator { get; set; }

        public string DirectoryPath { get; set; }

        public ILocalRepositoryContext LocalRepositoryContext_N003 => this;
    }
}
