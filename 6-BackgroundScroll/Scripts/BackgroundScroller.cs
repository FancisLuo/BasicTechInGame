using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace BackgroundScroll
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private Transform backgroundTarget;
        [SerializeField] private float scorllSpeed;

        [SerializeField] private float maxEdge;
        [SerializeField] private float minEdge;

        private float targetXPos;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var keyboard = Keyboard.current;
            if(keyboard == null)
            {
                return;
            }

            if(keyboard.leftArrowKey.isPressed)
            {
                targetXPos += scorllSpeed;
                if(targetXPos > maxEdge)
                {
                    targetXPos = maxEdge;
                }
            }

            if(keyboard.rightArrowKey.isPressed)
            {
                targetXPos -= scorllSpeed;
                if(targetXPos < minEdge)
                {
                    targetXPos = minEdge;
                }
            }

            backgroundTarget.position = new Vector3(targetXPos, 0, 0);
        }
    }
}
