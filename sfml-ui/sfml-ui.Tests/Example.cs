using SFML.Graphics;
using SFML.Window;
using sfml_ui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfml_ui.Tests
{
	public class Example : IDisposable
	{
		private RenderWindow window;
		private UISceneManager uimanager;
		private Scene scene1;

		public void Run()
		{
			window = new RenderWindow(new VideoMode(800, 600), "sfml-ui Examples", Styles.Default);
			window.Closed += window_OnCloseRequest;
			window.Resized += window_Resized;

			uimanager = new UISceneManager();
			uimanager.Init(window);

			scene1 = new Scene(ScrollInputs.None);
			scene1.Size = new Vector2f(window.Size.X, window.Size.Y);
			scene1.AddComponent(new TextControl(new Font("C:/Windows/Fonts/arial.ttf"), 50) { Size = new Vector2f(800, 100), Color = Color.White, Text = "Hello There.", TextAlignment = Alignment.MiddleCenter, Anchor = AnchorPoints.Left | AnchorPoints.Right | AnchorPoints.Top, BackgroundColor = Colors.SteelBlue });
			scene1.AddComponent(new TextControl(new Font("C:/Windows/Fonts/arial.ttf"), 30) { Size = new Vector2f(600, 100), Position = new Vector2f(100, 200), Color = Color.Black, Text = "This is an example of sfml-ui", TextAlignment = Alignment.MiddleCenter, Anchor = AnchorPoints.Left | AnchorPoints.Right | AnchorPoints.Top });
			scene1.AddComponent(new TextControl(new Font("C:/Windows/Fonts/arial.ttf"), 30) { Size = new Vector2f(350, 200), Position = new Vector2f(50, 350), Color = Color.Black, Text = "This is an SFML program\nHello", TextAlignment = Alignment.MiddleCenter, Anchor = AnchorPoints.Left | AnchorPoints.Top });
			scene1.AddComponent(new TextControl(new Font("C:/Windows/Fonts/arial.ttf"), 30) { Size = new Vector2f(300, 200), Position = new Vector2f(450, 350), Color = Color.Black, Text = "and its awesome :D", TextAlignment = Alignment.MiddleLeft, Anchor = AnchorPoints.Left | AnchorPoints.Right | AnchorPoints.Top });

			uimanager.CurrentScene = scene1;

			while (window.IsOpen())
			{
				window.DispatchEvents();
				window.Clear(Colors.WhiteSmoke);

				uimanager.Render(window);

				window.Display();
			}
		}

		private void window_Resized(object sender, SizeEventArgs e)
		{
			View view = new View(new FloatRect(0, 0, window.Size.X, window.Size.Y));
			window.SetView(view);
		}

		private void window_OnCloseRequest(object sender, EventArgs e)
		{
			window.Close();
		}

		public void Dispose()
		{
			window.Dispose();
		}
	}
}