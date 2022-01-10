using NBomber.Contracts;

namespace PerfTests.Steps
{
    public interface IProductsStepsFixture
    {
        IStep GetAllProducts();
        IStep GetProductById(int id);
    }

}