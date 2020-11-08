//*******************************************************************
// 根据方向按键移动
//*******************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace MovementByKeyboard
{
    /// <summary>
    /// 同时按下上和键（或者上、右或者下、左或者下、右）键时，
    /// 移动速度要比原给定的速度要快
    /// 移动中，如果x方向速度是vx，y方向速度是vy，那么，同时
    /// 按下两个方向上的移动键，速度v则为v=sqrt(vx*vx + vy * vy)，
    /// 所以，速度应该修正
    /// </summary>
    public class MovementEnhance : MonoBehaviour
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
        }

        // Update is called once per frame
        void Update()
        {
            var keyboard = Keyboard.current;
            if(keyboard == null)
            {
                return;
            }

            bool bLeftKey = keyboard.leftArrowKey.isPressed;
            bool bRightKey = keyboard.rightArrowKey.isPressed;

            bool bUpKey = keyboard.upArrowKey.isPressed;
            bool bDownKey = keyboard.downArrowKey.isPressed;

            if(bLeftKey)
            {
                if(bUpKey || bDownKey)
                {
                    xPos -= characterVelocity / Mathf.PI;
                }
                else
                {
                    xPos -= characterVelocity;
                }

                if(xPos < minLeft)
                {
                    xPos = minLeft;
                }
            }

            if(bRightKey)
            {
                if(bUpKey || bDownKey)
                {
                    xPos += characterVelocity / Mathf.PI;
                }
                else
                {
                    xPos += characterVelocity;
                }

                if(xPos > maxRight)
                {
                    xPos = maxRight;
                }
            }

            if(bUpKey)
            {
                if(bRightKey || bLeftKey)
                {
                    yPos += characterVelocity / Mathf.PI;
                }
                else
                {
                    yPos += characterVelocity;
                }

                if(yPos > maxUp)
                {
                    yPos = maxUp;
                }
            }

            if(bDownKey)
            {
                if(bRightKey || bLeftKey)
                {
                    yPos -= characterVelocity / Mathf.PI;
                }
                else
                {
                    yPos -= characterVelocity;
                }

                if(yPos < minDown)
                {
                    yPos = minDown;
                }
            }

            theCharacter.position = new Vector3(xPos, yPos);
        }
    }
}
