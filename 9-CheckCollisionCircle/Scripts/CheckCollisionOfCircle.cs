using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckCollisionCircle
{
    public class CheckCollisionOfCircle : MonoBehaviour
    {
        [SerializeField] private CircleTarget circleFirst;
        [SerializeField] private CircleTarget circleSecond;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var checkResult = CheckCollision();
            Debug.Log($"check result = {checkResult}");
        }

        private bool CheckCollision()
        {
            var sqrtDist = Vector2.SqrMagnitude(circleSecond.Center - circleFirst.Center);
            var dist = circleFirst.Radius + circleSecond.Radius;

            return sqrtDist <= (dist * dist);
        }
    }
}
