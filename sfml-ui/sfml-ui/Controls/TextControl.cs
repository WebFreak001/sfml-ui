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

		public Vector2f Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				if (Size.X < 1 || Size.Y < 1)
				{
					if (renderContainer != null) renderContainer.Dispose();
					renderContainer = new RenderTexture(1, 1);
				}
				else
				{
					if (renderContainer != null) renderContainer.Dispose();
					renderContainer = new RenderTexture((uint)value.X, (uint)value.Y);
				}
			}
		}

		public Vector2f Position { get; set; }

		public bool IsFocused { get; set; }

		public Font TextFont { get; set; }

		public uint TextSize { get; set; }

		public AnchorPoints Anchor { get; set; }

		public string Text { get { return textObject.DisplayedString; } set { textObject.DisplayedString = value; } }

		public Color Color { get { return textObject.Color; } set { textObject.Color = value; } }

		public Alignment TextAlignment { get; set; }

		public FloatRect Padding { get; set; }

		public Color BackgroundColor { get; set; }

		public bool Bold
		{
			get
			{
				return textObject.Style.HasFlag(SFML.Graphics.Text.Styles.Bold);
			}
			set
			{
				if (value)
					textObject.Style = SFML.Graphics.Text.Styles.Bold;
				else
					textObject.Style = SFML.Graphics.Text.Styles.Regular;
			}
		}

		protected Text textObject;
		protected RenderTexture renderContainer;
		protected Sprite renderSprite;
		protected Vector2f size;

		public TextControl(Font font, uint size)
		{
			TextFont = font;
			TextSize = size;
			TextAlignment = Alignment.TopLeft;

			Size = new Vector2f(50, 50);
			Anchor = AnchorPoints.None;
			Padding = new FloatRect(3, 3, 3, 3);
			BackgroundColor = Color.Transparent;

			textObject = new Text("Set Text Property", font, size);
			renderSprite = new Sprite();
			renderContainer = new RenderTexture((uint)Size.X, (uint)Size.Y);
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

		public void Render(RenderTarget target, Vector2f position)
		{
			renderContainer.Clear(BackgroundColor);
			Vector2f textPosition = new Vector2f(Padding.Left, Padding.Top);

			if (TextAlignment.GetHorizontal() == 0)
			{
				textPosition.X = (renderContainer.Size.X - textObject.GetLocalBounds().Width) * 0.5f;
			}
			else if (TextAlignment.GetHorizontal() == 1)
			{
				textPosition.X = renderContainer.Size.X - textObject.GetLocalBounds().Width - Padding.Width;
			}

			if (TextAlignment.GetVertical() == 0)
			{
				textPosition.Y = (renderContainer.Size.Y - textObject.Font.GetLineSpacing(TextSize) * 1.1f) * 0.5f;
			}
			else if (TextAlignment.GetVertical() == 1)
			{
				textPosition.Y = renderContainer.Size.Y - textObject.Font.GetLineSpacing(TextSize) * 1.1f - Padding.Height;
			}

			textObject.Position = textPosition;
			renderContainer.Draw(textObject);
			renderSprite.Texture = renderContainer.Texture;
			renderSprite.Position = position + new Vector2f(0, size.Y);
			renderSprite.TextureRect = new IntRect(0, 0, (int)size.X, (int)size.Y);
			renderSprite.Scale = new Vector2f(1, -1);
			target.Draw(renderSprite);
		}
	}
}