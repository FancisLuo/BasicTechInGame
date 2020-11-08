//*******************************************************************
// 根据方向按键移动
//*******************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace MovementByKeyboard
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float characterWidth;
        [SerializeField] private float characterHeight;

        [SerializeField] private float minLeft = 0.0f;
        [SerializeField] private float maxRight = 0.1f;
        [SerializeField] private float minDown = 0.0f;
        [SerializeField] private float maxUp = 0.1f;

        [SerializeField] private float characterVelocity;

        private Transform theCharacter;

        private float xPos;
        private float yPos;


        // Start is called before the first frame update
        void Start()
        {
            theCharacter = transform;

            theCharacter.position = Vector2.zero;
            xPos = yPos = 0f;
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
                // left
                xPos -= characterVelocity;
                if(xPos < minLeft)
                {
                    xPos = minLeft;
                }
            }

            if(keyboard.rightArrowKey.isPressed)
            {
                // right
                xPos += characterVelocity;
                if(xPos > maxRight)
                {
                    xPos = maxRight;
                }
            }

            if(keyboard.upArrowKey.isPressed)
            {
                yPos += characterVelocity;
                if(yPos > maxUp)
                {
                    yPos = maxUp;
                }
            }

            if(keyboard.downArrowKey.isPressed)
            {
                yPos -= characterVelocity;
                if(yPos < minDown)
                {
                    yPos = minDown;
                }
            }

            theCharacter.position = new Vector3(xPos, yPos);
        }
    }
}
