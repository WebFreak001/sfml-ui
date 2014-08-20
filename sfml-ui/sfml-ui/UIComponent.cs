using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sfml_ui
{
	public interface UIComponent
	{
		bool IsFocusable { get; }

		Vector2f MaxSize { get; set; }

		Vector2f MinSize { get; set; }

		Vector2f Size { get; set; }

		Vector2f Position { get; set; }

		AnchorPoints Anchor { get; set; }

		bool IsFocused { get; set; }

		Color BackgroundColor { get; set; }

		void HandleKeyDown(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows);

		void HandleKeyUp(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows);

		void HandleMouseDown(Vector2i mousePosition, Mouse.Button button);

		void HandleMouseUp(Vector2i mousePosition, Mouse.Button button);

		void HandleMouseMove(Vector2i mousePosition);

		void Render(RenderTarget target, Vector2f position);
	}
}