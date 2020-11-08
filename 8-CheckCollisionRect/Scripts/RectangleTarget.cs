using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckCollisionRect
{
    public class RectangleTarget : MonoBehaviour
    {
        public Vector2 RectCenter;
        public float Width;
        public float Height;

        private float xLeft, xRight, yUp, yBottom;

        private Vector2 pLeftBottom, pLeftUp, pRightBottom, pRightUp;

        private void Start()
        {
            xLeft   = RectCenter.x - Width * 0.5f;
            xRight  = RectCenter.x + Width * 0.5f;
            yUp     = RectCenter.y + Height * 0.5f;
            yBottom = RectCenter.y - Height * 0.5f;

            pLeftBottom     = new Vector2(xLeft, yBottom);
            pRightBottom    = new Vector2(xRight, yBottom);
            pLeftUp         = new Vector2(xLeft, yUp);
            pRightUp        = new Vector2(xRight, yUp);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pLeftBottom, pRightBottom);
            Gizmos.DrawLine(pLeftBottom, pLeftUp);
            Gizmos.DrawLine(pLeftUp, pRightUp);
            Gizmos.DrawLine(pRightUp, pRightBottom);
        }
    }
}
