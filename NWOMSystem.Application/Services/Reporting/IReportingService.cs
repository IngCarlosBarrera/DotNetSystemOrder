public interface IOrderReadOnlyRepository 
{
    /*
    Task<IEnumerable<OrderSummaryDto>> GetFilteredOrdersAsync(int year, int month, int week, string region);
    Task<DashboardMetricsDto> GetDashboardMetricsAsync();
    */
}

//learn to create DTOs and Mappers to convert between entities and DTOs. This will help to decouple the domain entities from the presentation layer and allow for more flexibility in how data is presented on the dashboard and in documents.