using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0139.N007;


namespace System
{
    public static class IHasProjectContextExtensions
    {
        public static async Task Modify(this IHasProjectContext hasContext,
            Func<IProjectContext, Task> projectModifierAction)
        {
            await projectModifierAction(hasContext.ProjectContext_N007);
        }
    }
}
