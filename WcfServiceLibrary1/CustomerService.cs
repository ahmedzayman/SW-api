public class CustomerService : ICustomerService
{
    public string GetCustomerDetails(int customerId)
    {
        return $"Customer details for ID {customerId}";
    }
}