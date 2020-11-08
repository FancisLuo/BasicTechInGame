using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckLineAndCircle
{
    [Serializable]
    public class MyCircle
    {
        public Vector2 Center;
        public float Radius;
    }

    [Serializable]
    public class LineSegment
    {
        public Vector2 PointA;
        public Vector2 PointB;
    }

    public class CheckCollisionForLineAndCircle : MonoBehaviour
    {
        [SerializeField] private MyCircle circle;
        [SerializeField] private LineSegment lineSegment;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CheckCollision();
        }

        private void OnDrawGizmos()
        {
            // draw line segment
            Gizmos.color = Color.red;
            Gizmos.DrawLine(lineSegment.PointA, lineSegment.PointB);

            // draw circle
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(circle.Center, circle.Radius);
        }

        private void CheckCollision()
        {
            var leastDistance = CalculateDistanceFromPointToSegment(circle.Center, lineSegment.PointA, lineSegment.PointB);
            if(leastDistance < circle.Radius)
            {
                Debug.Log("collided");
            }
            else
            {
                Debug.Log("not collided");
            }
        }

        private float CalculateDistanceFromPointToSegment(Vector2 point, Vector2 point1, Vector2 point2)
        {
            var ab = point2 - point1;
            var ap = point - point1;

            var cross = Vector2.Dot(ap, ab);
            if(cross <= 0)
            {
                return Vector2.Distance(point, point1);
            }

            var distAB = ab.magnitude;
            if(cross >= distAB)
            {
                return Vector2.Distance(point, point2);
            }

            var r = cross / distAB;
            var px = point1.x + (point2.x - point1.x) * r;
            var py = point1.y + (point2.y - point1.y) * r;
            var p = new Vector2(px, py);

            return Vector2.Distance(point, p);
        }
    }
}
