using ASPIntroduction.Models;

namespace ASPIntroduction.Contracts
{
	public interface ITestService
	{
		string GetProduct(TestModel model);
	}
}
