using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyRandom = UnityEngine.Random;

namespace MoveRandomly
{
    public class RandomMovement : MonoBehaviour
    {
        [SerializeField] private GameObject prefabTemplate;
        [SerializeField] private int targetCount;

        private Target[] targets;


        // Start is called before the first frame update
        void Start()
        {
            if(prefabTemplate == null)
            {
                throw new ArgumentNullException(nameof(prefabTemplate));
            }

            targets = new Target[targetCount];

            for(int i = 0; i < targetCount; ++i)
            {
                float vx = MyRandom.Range(-10f, 10f);
                float vy = MyRandom.Range(0, 15f);
                targets[i] = new Target();
                var obj = GameObject.Instantiate<GameObject>(prefabTemplate, new Vector3(0, -3f, 0), Quaternion.identity, transform);
                targets[i].InitTarget(obj.transform, vx, vy);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(var i = 0; i < targetCount; ++i)
            {
                targets[i].Update();
            }
        }
    }
}
