using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sfml_ui
{
	public enum ScrollInputs // BitFlags
	{
		None = 0,
		Bars = 1 << 0, //		b0001 = 1
		Drag = 1 << 1, //		b0010 = 2
		ArrowKeys = 1 << 2, //	b0100 = 4
		All = Bars | Drag | ArrowKeys
	}
}