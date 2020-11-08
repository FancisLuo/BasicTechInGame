1. 初步使用Input System
    新版输入模块的初步使用方式比较简单
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MyPlayerScript : MonoBehaviour
    {
        void FixedUpdate()
        {
            var gamepad = Gamepad.current;
            if (gamepad == null)
                return; // No gamepad connected.

            if (gamepad.rightTrigger.wasPressedThisFrame)
            {
                // 'Use' code here
            }

            Vector2 move = gamepad.leftStick.ReadValue();
            // 'Move' code here
        }
    }
    如果不需要比较复杂的方式，以上方式即可。目测，以上方式可以满足大部分需求了。

2. 根据输入的移动
    检查是否超过边界

3. 根据物理上的运动规律，任何的移动，都可以分解为水平和垂直两个方向上的运动，以上的移动，
    是分别在两个方向上的按速度v的移动，如果同时按下水平和垂直两个方向键。则移动速度要大于v。