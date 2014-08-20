using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui
{
	public class UISceneManager
	{
		public Scene CurrentScene { get; set; }

		protected bool handleInput = false;

		public void Init(Window window)
		{
			window.GainedFocus += window_HasGainedFocus;
			window.LostFocus += window_HasLostFocus;

			window.MouseButtonPressed += window_MouseButtonPressed;
			window.MouseButtonReleased += window_MouseButtonReleased;
			window.MouseMoved += window_MouseMoved;

			window.KeyPressed += window_KeyPressed;
			window.KeyReleased += window_KeyReleased;

			window.Resized += window_Resized;
		}

		private void window_HasGainedFocus(object sender, EventArgs e)
		{
			handleInput = true;
		}

		private void window_HasLostFocus(object sender, EventArgs e)
		{
			handleInput = false;
		}

		private void window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleMouseDown(new Vector2i(e.X, e.Y), e.Button);
		}

		private void window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleMouseUp(new Vector2i(e.X, e.Y), e.Button);
		}

		private void window_MouseMoved(object sender, MouseMoveEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleMouseMove(new Vector2i(e.X, e.Y));
		}

		private void window_Resized(object sender, SizeEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleResize();
		}

		private void window_KeyPressed(object sender, KeyEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleKeyDown(e.Code, e.Control, e.Shift, e.Alt, e.System);
		}

		private void window_KeyReleased(object sender, KeyEventArgs e)
		{
			if (handleInput)
				CurrentScene.HandleKeyUp(e.Code, e.Control, e.Shift, e.Alt, e.System);
		}
	}
}