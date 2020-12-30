using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObliqueMoveScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _moveObject;

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private float _g = 9.8f;

    [SerializeField]
    private float _speed = 10;

    private float _verticalSpeed;
    private Vector3 _moveDirection;
    private float _angleSpeed;
    private float _angle;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        float tmepDistance = Vector3.Distance(_moveObject.transform.position, _target.transform.position);
        float tempTime = tmepDistance / _speed;
        float riseTime, downTime;
        riseTime = downTime = tempTime / 2;
        _verticalSpeed = _g * riseTime;
        _moveObject.transform.LookAt(_target.transform.position);
        float tempTan = _verticalSpeed / _speed;
        double hu = Math.Atan(tempTan);
        _angle = (float)(180 / Math.PI * hu);
        _moveObject.transform.eulerAngles = new Vector3(-_angle, _moveObject.transform.eulerAngles.y, _moveObject.transform.eulerAngles.z);
        _angleSpeed = _angle / riseTime;
        _moveDirection = _target.transform.position - _moveObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveObject.transform.position.y < _target.transform.position.y)
        {
            //finish  
            return;
        }

        _time += Time.deltaTime;
        float test = _verticalSpeed - _g * _time;
        _moveObject.transform.Translate(_moveDirection.normalized * _speed * Time.deltaTime, Space.World);
        _moveObject.transform.Translate(Vector3.up * test * Time.deltaTime, Space.World);
        float testAngle = -_angle + _angleSpeed * _time;
        _moveObject.transform.eulerAngles = new Vector3(testAngle, _moveObject.transform.eulerAngles.y, _moveObject.transform.eulerAngles.z);
    }
}
