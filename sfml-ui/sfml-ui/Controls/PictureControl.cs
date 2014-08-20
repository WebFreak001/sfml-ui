using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui.Controls
{
	public class PictureControl : UIComponent
	{
		public bool IsFocusable { get { return false; } }

		public Vector2f MaxSize { get; set; }

		public Vector2f MinSize { get; set; }

		public Vector2f Size { get; set; }

		public Vector2f Position { get; set; }

		public AnchorPoints Anchor { get; set; }

		public bool IsFocused { get; set; }

		public Color BackgroundColor { get; set; }

		private RectangleShape pictureShape;
		private RectangleShape backgroundShape;

		public PictureControl(Texture texture)
		{
			pictureShape = new RectangleShape();
			backgroundShape = new RectangleShape();
			pictureShape.Texture = texture;
		}

		public PictureControl(string path)
			: this(new Texture(path) { Smooth = true })
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

		public void Render(RenderTarget target, Vector2f position)
		{
			pictureShape.Size = Size;
			pictureShape.Position = position;
			backgroundShape.FillColor = BackgroundColor;
			target.Draw(backgroundShape);
			target.Draw(pictureShape);
		}
	}
}