
public static class BookStore
{
    private static readonly Dictionary<int, decimal> discounts = new()
        {
            { 1, 0.00m },
            { 2, 0.05m },
            { 3, 0.10m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

    private static Dictionary<string, decimal> cache = new();

    public static decimal Total(IEnumerable<int> books)
    {
        // Convert input into state: counts of each distinct book (order doesn't matter)
        List<int> state = books
            .GroupBy(b => b)
            .Select(b => b.Count())
            .OrderByDescending(x => x)
            .ToList();

        return BestPrice(state);
    }

    private static decimal BestPrice(List<int> state)
    {
        // Create a unique key for this state (used for memoization)
        var key = string.Join(",", state);

        // If we've already solved this state, return cached result
        if (cache.ContainsKey(key))
            return cache[key];

        // Base case: no books left → no cost
        if (state.Count() == 0) return 0;

        decimal minPrice = decimal.MaxValue;

        // Try all possible group sizes and choose the minimum total price
        for (int size = 1; size <= state.Count(); size++)
        {
            // Copy state so each choice is evaluated independently
            var newState = new List<int>(state);

            // Take a group of 'size' distinct books (reduce largest counts first)
            for (int i = 0; i < size; i++)
            {
                newState[i]--;
            }

            // Remove books with no remaining copies
            newState.RemoveAll(s => s == 0);

            // Calculate price for this group size with discount applied
            var basePrice = size * 8m;
            var priceAfterDiscount = basePrice * (1 - discounts[size]);

            // Recursively compute best price for remaining books
            var totalPrice = priceAfterDiscount + BestPrice(newState);

            minPrice = Math.Min(minPrice, totalPrice);
        }

        // Store result to avoid recomputing this state
        cache[key] = minPrice;
        return minPrice;
    }
}