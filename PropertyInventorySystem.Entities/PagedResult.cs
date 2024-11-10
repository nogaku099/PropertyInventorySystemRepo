namespace PropertyInventorySystem.Entities;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; }  // The items on the current page
    public int TotalCount { get; set; }        // Total number of items in the entire dataset
    public int PageNumber { get; set; }        // Current page number
    public int PageSize { get; set; }          // Number of items per page
    public int TotalPages { get; set; }        // Total number of pages
}