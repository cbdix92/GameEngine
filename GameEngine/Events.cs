using System;

namespace GameEngine
{
    public delegate void EventHandler(object source, EventArgs args);

    public static class Events
    {

        public static event EventHandler RenderCalled;
        public static event EventHandler InputCalled;
        public static event EventHandler UpdateCalled;

        public static void OnRenderCalled(object source, EventArgs args)
        {
            if (RenderCalled != null)
            {
                RenderCalled(source, args);
            }
        }
        public static void OnInputCalled(object source, EventArgs args)
        {
            if (InputCalled != null)
            {
                InputCalled(source, args);
            }
        }

        public static void OnUpdateCalled(object source, EventArgs args)
        {
            if (UpdateCalled != null)
            {
                UpdateCalled(source, args);
            }
        }
    }
}
