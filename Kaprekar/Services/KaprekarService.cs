using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaprekar
{
	public class KaprekarService : IKaprekarService
	{
		public ValidationModel ValidateNumber(string numString)
		{
			ValidationModel validationModel = new ValidationModel() { Valid = false };
			if (string.IsNullOrEmpty(numString) || !int.TryParse(numString, out int num))
			{
				validationModel.ReturnMessage = "That is not a number!";
			}
			else if (numString.Length != 4)
			{
				validationModel.ReturnMessage = "Your number must be 4 digits!";
			}
			else if (numString[0] == numString[1] && numString[0] == numString[2] && numString[0] == numString[3])
			{
				validationModel.ReturnMessage = "Your number must not be 4 repeating digits!";
			}
			else
			{
				validationModel.ReturnMessage = $"You have selected {numString}";
				validationModel.Valid = true;
			}
			return validationModel;
		}
		public KaprekarReturnModel KaprekarIteration(string numString)
		{
			try
			{
				string numbersDescending = ArrangeNumber(numString, false);
				string numbersAscending = ArrangeNumber(numString, true);
				int result = int.Parse(numbersDescending) - int.Parse(numbersAscending);
				return new KaprekarReturnModel() { Result = ConvertToFourDigits(result.ToString()), ReturnMessage = $"{numbersDescending} - {numbersAscending} = {ConvertToFourDigits(result.ToString())}" };
			}
			catch
			{
				return new KaprekarReturnModel() { ReturnMessage = "Iteration Failed" };
			}
		}
		private string ArrangeNumber(string numString, bool ascending)
		{
			List<char> digitList = numString.ToList();
			List<char> digitListOrdered = ascending ? digitList.OrderBy(x => x.ToString()).ToList() : digitList.OrderByDescending(x => x.ToString()).ToList();
			return string.Join("", digitListOrdered);
		}
		private string ConvertToFourDigits(string numString)
		{
			int num = int.Parse(numString);
			string returnString = num < 10 ? $"000{numString}" : num < 100 ? $"00{numString}" : num < 1000 ? $"0{numString}" : numString;
			return returnString;
		}
	}
}
