using System;

namespace GameEngine
{
    class Animation : Componet
    {
        /*
		 * Images are stored in the animation array.
		 * The keyFrame is used to index the animation array, returning an Image to be rendered.
		 *
		 */
        private bool isActive;
        private int keyFrame = 0;
        private Image[] animation;

        private string frameBuffer;

        public Animation(string animationSource)
        {
            animation = new Image[RCore.CalculateKeyFrames(animationSource)];
            foreach (char item in animationSource)
            {
                if (item != '\t')
                {
                    frameBuffer = String.Concat(frameBuffer, item);
                }
                else if (item == '\t')
                {
                    animation[keyFrame] = new Image(frameBuffer);
                    frameBuffer = "";
                    keyFrame++;
                }
            }

            keyFrame = 0;

        }
        public void Update()
        {
            keyFrame++;
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
            // returns the object back to a starting position.
            keyFrame = 0;
        }

    }
}
