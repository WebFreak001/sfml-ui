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

			uimanager = new UISceneManager();
			uimanager.Init(window);

			scene1 = new Scene(ScrollInputs.None);
			scene1.AddComponent(new TextControl(new Font("C:/Windows/Fonts/arial.ttf")));
		}

		private void window_OnCloseRequest(object sender, EventArgs e)
		{
			window.Close();
		}

		public void Dispose()
		{
		}
	}
}