using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace BackgroundScrollWithCharacter
{
    public class ScrollWithCharacter : MonoBehaviour
    {
        [SerializeField] private Transform theCamera;
        [SerializeField] private Transform theBackground;
        [SerializeField] private Transform theCharacter;
        [SerializeField] private float fCharacterMoveSpeed;

        [SerializeField] private float backgroundWidth;
        [SerializeField] private float viewWidth;
        [SerializeField] private float characterWidth;

        private float fCameraXPos;              // 区域中镜头的x坐标
        private float fCharacterXPos;           // 区域中角色的x坐标

        private float fMinLeft;
        private float fMaxRight;

        private float fCharacterMinLeft;
        private float fCharacterMaxRight;

        // Start is called before the first frame update
        void Start()
        {
            fMinLeft = -(backgroundWidth * 0.5f - viewWidth * 0.5f);
            fMaxRight = backgroundWidth * 0.5f - viewWidth * 0.5f;

            fCharacterMinLeft = -(backgroundWidth * 0.5f - characterWidth * 0.5f);
            fCharacterMaxRight = backgroundWidth * 0.5f - characterWidth * 0.5f;
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
                fCharacterXPos -= fCharacterMoveSpeed;
            }
            if(keyboard.rightArrowKey.isPressed)
            {
                fCharacterXPos += fCharacterMoveSpeed;
            }

            ScrollBackground();

            if(fCharacterXPos < fCharacterMinLeft)
            {
                fCharacterXPos = fCharacterMinLeft;
            }
            else if(fCharacterXPos > fCharacterMaxRight)
            {
                fCharacterXPos = fCharacterMaxRight;
            }

            theCharacter.position = new Vector3(fCharacterXPos, 0f, 0f);
            theCamera.position = new Vector3(fCameraXPos, 0f, -10f);
        }

        private void ScrollBackground()
        {
            fCameraXPos = fCharacterXPos;

            if(fCameraXPos < fMinLeft)
            {
                fCameraXPos = fMinLeft;
            }

            if(fCameraXPos > fMaxRight)
            {
                fCameraXPos = fMaxRight;
            }
        }
    }
}
