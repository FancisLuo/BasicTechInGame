using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveRandomly
{
    public class Target
    {
        private float xVelocity;
        private float yVelocity;
        private Transform theTarget;

        private bool canMove = false;
        private float curTime;
        private float xPos, yPos;

        public void InitTarget(Transform target, float xVel, float yVel)
        {
            if(target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            theTarget = target;
            xVelocity = xVel;
            yVelocity = yVel;

            canMove = true;
            curTime = 0f;
        }

        // Update is called once per frame
        public void Update()
        {
            if(!canMove)
            {
                return;
            }

            curTime += Time.deltaTime;
            xPos = xVelocity * curTime;
            yPos = yVelocity * curTime;

            theTarget.position = new Vector3(xPos, yPos);
        }
    }
}
