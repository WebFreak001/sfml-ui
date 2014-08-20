using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sfml_ui
{
	public enum Alignment
	{
		TopLeft, TopCenter, TopRight,
		MiddleLeft, MiddleCenter, MiddleRight,
		BottomLeft, BottomCenter, BottomRight
	}

	public static class AlignExt
	{
		/// <summary>
		/// Gets the horizontal alignment in a range of -1 to 1 on the SFML coordinate system. Example: *Left = -1, *Right = 1
		/// </summary>
		/// <param name="alignment">Alignment to check</param>
		/// <returns>Horizontal alignment in a range of -1 to 1</returns>
		public static int GetHorizontal(this Alignment alignment)
		{
			switch (alignment)
			{
				case Alignment.TopLeft:
				case Alignment.MiddleLeft:
				case Alignment.BottomLeft:
					return -1;

				case Alignment.TopCenter:
				case Alignment.MiddleCenter:
				case Alignment.BottomCenter:
					return 0;

				case Alignment.TopRight:
				case Alignment.MiddleRight:
				case Alignment.BottomRight:
					return 1;

				default:
					return 0;
			}
		}

		/// <summary>
		/// Gets the vertical alignment in a range of -1 to 1 based on the SFML coordinate system. Example: Top* = -1, Middle* = 0
		/// </summary>
		/// <param name="alignment">Alignment to check</param>
		/// <returns>Vertical alignment in a range of -1 to 1</returns>
		public static int GetVertical(this Alignment alignment)
		{
			switch (alignment)
			{
				case Alignment.TopLeft:
				case Alignment.TopCenter:
				case Alignment.TopRight:
					return -1;

				case Alignment.MiddleLeft:
				case Alignment.MiddleCenter:
				case Alignment.MiddleRight:
					return 0;

				case Alignment.BottomLeft:
				case Alignment.BottomCenter:
				case Alignment.BottomRight:
					return 1;

				default:
					return 0;
			}
		}
	}
}