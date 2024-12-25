using System.ServiceModel;

[ServiceContract]
public interface ICustomerService
{
    [OperationContract]
    string GetCustomerDetails(int customerId);
}