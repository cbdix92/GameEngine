using System;
using System.Windows.Input;

namespace GameEngine
{
    class Input
    {
        KeyListener[] keyListeners;

        public void Update()
        {
            foreach (KeyListener item in keyListeners)
            {
                if (item.Update())
                {
                    break;
                }
            }
        }

        public void AddKeyListener(Key key)
        {
            Core.ListUp<KeyListener>(ref keyListeners);
            keyListeners[keyListeners.Length - 1] = new KeyListener(key);
        }
    }

    class KeyListener
    {
        Key key;

        public KeyListener(Key key)
        {
            this.key = key;
        }

        public bool Update()
        {
            if (Keyboard.IsKeyDown(key))
            {
                Events.OnInputCalled(this, new KeyArgs { keyArg = key });

                return true;
            }
            return false;
        }

        private class KeyArgs : EventArgs
        {
            public Key keyArg;
        }
    }
}
