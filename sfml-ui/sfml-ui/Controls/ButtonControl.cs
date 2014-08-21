using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui.Controls
{
	public class ButtonControl : UIComponent
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
				text.Size = value; size = value;
			}
		}

		public Vector2f Position { get; set; }

		public AnchorPoints Anchor { get; set; }

		public bool IsFocused { get; set; }

		public bool IsHovered { get; set; }

		public bool IsPressed { get; set; }

		public Color BackgroundColor { get; set; }

		public string Text { get { return text.Text; } set { text.Text = value; } }

		public float ClickYOffset { get; set; }

		public event EventHandler OnClick;

		private RectangleShape left, middle, right;
		private TextControl text;
		private Vector2f size;
		private Texture buttonTexture, hoverTexture, pressedTexture;

		public ButtonControl(Font font, uint size, Texture button, Texture hover, Texture press)
		{
			left = new RectangleShape();
			middle = new RectangleShape();
			right = new RectangleShape();

			left.Texture = button;
			middle.Texture = button;
			right.Texture = button;

			left.TextureRect = new IntRect(0, 0, (int)button.Size.X / 2 - 1, (int)button.Size.Y);
			middle.TextureRect = new IntRect((int)button.Size.X / 2 - 1, 0, 2, (int)button.Size.Y);
			right.TextureRect = new IntRect((int)button.Size.X / 2 + 1, 0, (int)button.Size.X / 2, (int)button.Size.Y);

			text = new TextControl(font, size) { TextAlignment = Alignment.MiddleCenter, Bold = true };
			text.BackgroundColor = Color.Transparent;

			IsHovered = false;
			IsPressed = false;
			ClickYOffset = 4.0f;

			buttonTexture = button;
			hoverTexture = hover;
			pressedTexture = press;
		}

		public ButtonControl(Font font, uint size, string button, string hover, string press)
			: this(font, size, new Texture(button) { Smooth = true }, new Texture(hover) { Smooth = true }, new Texture(press) { Smooth = true })
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
			IsPressed = true;
		}

		public void HandleMouseUp(Vector2i mousePosition, Mouse.Button button)
		{
			if (IsPressed && IsHovered)
			{
				if (OnClick != null)
					OnClick(this, EventArgs.Empty);
			}
			IsPressed = false;
		}

		public void HandleMouseMove(Vector2i mousePosition)
		{
			IsHovered = mousePosition.X > Position.X && mousePosition.X < Position.X + Size.X
					 && mousePosition.Y > Position.Y && mousePosition.Y < Position.Y + Size.Y;
		}

		public void Render(RenderTarget target, Vector2f position)
		{
			left.Position = position;
			left.Size = new Vector2f(left.TextureRect.Width, Size.Y);

			middle.Position = position + new Vector2f(left.Size.X, 0);
			middle.Size = new Vector2f(Size.X - left.Size.X - right.TextureRect.Width, Size.Y);

			right.Position = position + new Vector2f(left.Size.X + middle.Size.X, 0);
			right.Size = new Vector2f(right.TextureRect.Width, Size.Y);

			if (IsHovered)
			{
				if (IsPressed)
				{
					left.Texture = middle.Texture = right.Texture = pressedTexture;
				}
				else
				{
					left.Texture = middle.Texture = right.Texture = hoverTexture;
				}
			}
			else
			{
				left.Texture = middle.Texture = right.Texture = buttonTexture;
			}

			target.Draw(left);
			target.Draw(middle);
			target.Draw(right);
			if (IsHovered && IsPressed)
				text.Render(target, position + new Vector2f(0, ClickYOffset));
			else
				text.Render(target, position);
		}
	}
}