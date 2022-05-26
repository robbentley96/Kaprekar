using System;

namespace Kaprekar
{
	class Program
	{
		static void Main(string[] args)
		{
			IKaprekarService service = new KaprekarService();
			bool numberSelected = false;
			string numString = "";
			while (!numberSelected)
			{
				Console.WriteLine("Enter a 4 digit number:");
				numString = Console.ReadLine();
				ValidationModel validationModel = service.ValidateNumber(numString);
				numberSelected = validationModel.Valid;
				Console.WriteLine(validationModel.ReturnMessage);
			}
			string currentValue = "0000";
			while (currentValue != numString)
			{
				currentValue = numString;
				KaprekarReturnModel model = service.KaprekarIteration(currentValue);
				numString = model.Result;
				Console.WriteLine(model.ReturnMessage);
			}

		}
	}
}
