//*******************************************************************
// 任意方向的移动
//*******************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveAnyDirection
{
    public class AnyDirectionMovement : MonoBehaviour
    {
        [SerializeField] private float leftEdge;
        [SerializeField] private float rightEdge;
        [SerializeField] private float upEdge;
        [SerializeField] private float downEdge;

        [SerializeField] private float moveVelocity;
        [SerializeField] private float moveAngle;

        private Transform theTarget;

        private float vx;
        private float vy;

        private float xPos;
        private float yPos;

        private float fAngle;
        private const float fCircleAngle = 2.0f * Mathf.PI;

        // Start is called before the first frame update
        void Start()
        {
            Init();
            theTarget = transform;
            xPos = yPos = 0;
            theTarget.position = new Vector3(xPos, yPos, 0);
        }

        // Update is called once per frame
        void Update() => MoveTarget();

        private void Init()
        {
            fAngle = moveAngle * Mathf.Deg2Rad;
            UpdateVelocity();
        }

        private void MoveTarget()
        {
            xPos += vx;
            yPos += vy;
            theTarget.position = new Vector3(xPos, yPos, 0);

            if((xPos < leftEdge) || (xPos > rightEdge) || (yPos < downEdge) || (yPos > upEdge))
            {
                xPos = 0f;
                yPos = 0f;

                fAngle += fCircleAngle / 10.0f;

                if(fAngle > (fCircleAngle))
                {
                    fAngle -= fCircleAngle;
                }

                UpdateVelocity();
            }
        }

        private void UpdateVelocity()
        {
            vx = moveVelocity * Mathf.Cos(fAngle);
            vy = moveVelocity * Mathf.Sin(fAngle);
        }
    }
}
