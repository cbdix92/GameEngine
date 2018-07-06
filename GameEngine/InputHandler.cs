using System;
using System.Windows.Input;

namespace GameEngine
{
    class InputHandler
    {	
		public delegate void KeyPressedEventHandler(object source, KeyPressedEventArgs args);	
		public event KeyPressedEventHandler KeyPressed;
		
		private string key;
		
		protected virtual void OnKeyPressed()
		{
			if (KeyPressed != null)
			{
				KeyPressed(this, new KeyPressedEventArgs { Key = this.key } );
			}
		}
		
		public void Update()
		{
			// Check if any key has been pressed
			// if (key pressed)
				// Store which key has been presed in the key variable
				// Call OnKeyPressed() Event
		}

    }
	
	class KeyPressedEventArgs : EventArgs
	{
		private string Key { get; set; }
	}
}
