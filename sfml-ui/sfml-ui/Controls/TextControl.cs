using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui.Controls
{
	public class TextControl : UIComponent
	{
		public bool IsFocusable { get { return false; } }

		public Vector2f MaxSize { get; set; }

		public Vector2f MinSize { get; set; }

		public Vector2f Size { get { return size; } set { size = value; renderContainer = new RenderTexture((uint)value.X, (uint)value.Y); } }

		public Vector2f Position { get; set; }

		public bool IsFocused { get; set; }

		public Font TextFont { get; set; }

		public uint TextSize { get; set; }

		public string Text { get { return textObject.DisplayedString; } set { textObject.DisplayedString = value; } }

		protected Text textObject;
		protected RenderTexture renderContainer;
		protected Sprite renderSprite;
		protected Vector2f size;

		public TextControl(Font font, uint size)
		{
			TextFont = font;
			TextSize = size;
			renderSprite = new Sprite();
		}

		public TextControl(Font font)
			: this(font, 12)
		{
		}

		public void HandleKeyDown(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows)
		{
		}

		public void HandleKeyUp(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows)
		{
		}

		public void HandleMouseDown(Vector2i mousePosition, Mouse.Button button)
		{
		}

		public void HandleMouseUp(Vector2i mousePosition, Mouse.Button button)
		{
		}

		public void HandleMouseMove(Vector2i mousePosition)
		{
		}

		public void Render(RenderTarget target)
		{
			renderContainer.Clear(Color.Transparent);
			renderContainer.Draw(textObject);
			renderSprite.Texture = renderContainer.Texture;
			target.Draw(renderSprite);
		}
	}
}