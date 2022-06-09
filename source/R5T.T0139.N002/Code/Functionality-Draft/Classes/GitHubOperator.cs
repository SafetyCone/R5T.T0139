using System;


namespace R5T.T0139.N002
{
    public class GitHubOperator : IGitHubOperator
    {
        #region Infrastructure

        public static GitHubOperator Instance { get; } = new();

        private GitHubOperator()
        {
        }

        #endregion
    }
}
