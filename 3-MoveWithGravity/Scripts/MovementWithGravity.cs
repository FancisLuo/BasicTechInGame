using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveWithGravity
{
    public class MovementWithGravity : MonoBehaviour
    {
        [SerializeField] private float xInitVelocity;
        [SerializeField] private float yInitVelocity;

        [SerializeField] private Vector2 initPosition;

        [SerializeField] private float rightEdge;
        [SerializeField] private float downEdge;

        /// <summary>
        /// 重力加速度
        /// </summary>
        [SerializeField, Tooltip("模拟的重力加速度值")] private float g;

        private Transform theTarget;

        private float xPos;
        private float yPos;

        private bool canMove;
        private float curTime;

        // Start is called before the first frame update
        void Start()
        {
            theTarget = transform;

            xPos = initPosition.x;
            yPos = initPosition.y;
            theTarget.position = new Vector3(xPos, yPos, 0);
            canMove = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(canMove)
            {
                curTime += Time.deltaTime;
                MoveTarget(curTime);
            }
        }

        private void MoveTarget(float t)
        {
            xPos = xInitVelocity * t + initPosition.x;
            yPos = 0.5f * g * t * t + yInitVelocity * t + initPosition.y;

            if(xPos > rightEdge || yPos < downEdge)
            {
                canMove = false;
                return;
            }

            theTarget.position = new Vector3(xPos, yPos, 0);
        }
    }

}
