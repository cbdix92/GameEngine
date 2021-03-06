﻿using System;

namespace GameEngine
{
    public class Animation : Componet
    {
        /*
		 * Images are stored in the animation array.
		 * The keyFrame is used to index the animation array, returning an Image to be rendered.
		 *
		 */
		
		private Image[] animation;
        private bool isActive;
        private int keyFrame = 0;

        public Animation(string animationSource)
        {
            animation = new Image[Core.CalculateKeyFrames(animationSource)];
            Core.AnimationParser(ref animation, animationSource);

        }
        public void Update()
        {
			if (isActive)
			{
				keyFrame++;
				
				// Raise Render Event
				// ...
			}
        }

        public Image GetImage()
        {

            // Loop the animation
            if (keyFrame == animation.Length)
            {
                keyFrame = 0;
            }

            return animation[keyFrame];
        }

        public void Start()
        {
            isActive = true;
        }

        public void Stop()
        {
            isActive = false;
        }

        public void Reset()
        {
            keyFrame = 0;
        }

    }
}
