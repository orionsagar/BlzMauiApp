using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzMauiApp.Helpers
{
    public sealed class InfiniteScrollingItemsProviderRequest
    {
        public InfiniteScrollingItemsProviderRequest(int startIndex, CancellationToken cancellationToken)
        {
            StartIndex = startIndex;
            CancellationToken = cancellationToken;
        }

        public int StartIndex { get; }
        public CancellationToken CancellationToken { get; }
    }

    public delegate Task<IEnumerable<int>> ItemsProviderRequestDelegate(InfiniteScrollingItemsProviderRequest request);
}
