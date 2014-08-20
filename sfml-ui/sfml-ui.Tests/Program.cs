using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui.Tests
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			using (Example example = new Example())
				example.Run();
		}
	}
}