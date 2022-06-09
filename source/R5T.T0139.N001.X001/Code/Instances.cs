using System;

using R5T.T0040;


namespace R5T.T0139.N001.X001
{
    public static class Instances
    {
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
    }
}
