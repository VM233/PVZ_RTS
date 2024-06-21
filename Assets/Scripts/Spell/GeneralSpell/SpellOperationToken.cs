using System;

namespace TH.Spells
{
    public class SpellOperationToken
    {
        public Action Abort { get; init; }

        public Func<bool> IsAborted { get; init; }

        public Func<SpellAbortInfo> GetAbortInfo { get; init; }

        public Action Complete { get; init; }
    }
}