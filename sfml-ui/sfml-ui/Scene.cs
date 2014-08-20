using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui
{
	public class Scene : UIComponent
	{
		public List<UIComponent> Components;
		public ScrollInputs ScrollInput;
		public Vector2f ScrollValues;

		public bool IsFocusable { get { return false; } }

		public Vector2f MaxSize { get; set; }

		public Vector2f MinSize { get; set; }

		public Vector2f Size { get; set; }

		public Vector2f Position { get; set; }

		public bool IsFocused { get; set; }

		public Scene(ScrollInputs scrollType)
		{
			Components = new List<UIComponent>();
			ScrollValues = new Vector2f();
			ScrollInput = scrollType;
			MaxSize = new Vector2f();
			MinSize = new Vector2f();
			Size = new Vector2f();
			Position = new Vector2f();
			IsFocused = false;
		}

		public void AddComponent(UIComponent component)
		{
			Components.Add(component);
		}

		public void Render(RenderTarget target)
		{
			foreach (UIComponent component in Components)
				component.Render(target);
		}

		public UIComponent GetTopMost(Vector2i position)
		{
			// Reverse for getting top most instead of bottom most
			Components.Reverse();
			foreach (UIComponent component in Components)
			{
				if (position.X > component.Position.X && position.X < component.Position.X + component.Size.X
				 && position.Y > component.Position.Y && position.Y < component.Position.Y + component.Size.Y)
				{
					Components.Reverse();
					return component;
				}
			}
			Components.Reverse();
			return null;
		}

		public void UnfocusAll()
		{
			foreach (UIComponent component in Components)
			{
				component.IsFocused = false;
			}
		}

		public void HandleResize()
		{
		}

		public void HandleKeyDown(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows)
		{
			foreach (UIComponent component in Components)
			{
				component.HandleKeyDown(key, Ctrl, Shift, Alt, Windows);
			}
		}

		public void HandleKeyUp(Keyboard.Key key, bool Ctrl, bool Shift, bool Alt, bool Windows)
		{
			foreach (UIComponent component in Components)
			{
				component.HandleKeyUp(key, Ctrl, Shift, Alt, Windows);
			}
		}

		public void HandleMouseDown(Vector2i mousePosition, Mouse.Button button)
		{
			foreach (UIComponent component in Components)
			{
				component.HandleMouseDown(mousePosition, button);
			}
		}

		public void HandleMouseUp(Vector2i mousePosition, Mouse.Button button)
		{
			UIComponent target = GetTopMost(mousePosition);
			if (target.IsFocusable && button == Mouse.Button.Left)
			{
				UnfocusAll();
				target.IsFocused = true;
			}
			foreach (UIComponent component in Components)
			{
				component.HandleMouseUp(mousePosition, button);
			}
		}

		public void HandleMouseMove(Vector2i mousePosition)
		{
			foreach (UIComponent component in Components)
			{
				component.HandleMouseMove(mousePosition);
			}
		}
	}
}