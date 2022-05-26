using System;
using System.Collections.Generic;
using System.Text;

namespace Kaprekar
{
	public interface IKaprekarService
	{
		public ValidationModel ValidateNumber(string numString);
		public KaprekarReturnModel KaprekarIteration(string numString);
	}
}
