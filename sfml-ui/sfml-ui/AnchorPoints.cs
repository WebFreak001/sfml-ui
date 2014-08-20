using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sfml_ui
{
	public enum AnchorPoints
	{
		None = 0,
		Left = 1 << 0, //	b0001 = 1
		Top = 1 << 1, //	b0010 = 2
		Right = 1 << 2, //	b0100 = 4
		Bottom = 1 << 3 //	b1000 = 8
	}
}