using ASPIntroduction.Contracts;
using ASPIntroduction.Models;

namespace ASPIntroduction.Services
{
	public class TestService : ITestService
	{
		public string GetProduct(TestModel model)
		{
			return model.Product;
		}
	}
}
