using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObliqueEquationMoveScript : MonoBehaviour
{
    [SerializeField]
    private float _height;

    private float _distance;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private GameObject _moveObject;
    [SerializeField]
    private GameObject _target;

    private float _a;
    private float _b;

    private float _toMoveTime;

    private float _vx;
    private float _vz;

    private float _timer;

    private Vector3 _originPosition;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        CalculateCoff();
        _originPosition = _moveObject.transform.position;

        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer >= _toMoveTime)
            return;

        float dt = Time.deltaTime;
        float dsx = _vx * dt;
        float dsz = _vz * dt;

        var pos = _moveObject.transform.position;
        pos.x += dsx;
        pos.z += dsz;

        var dir = pos - _originPosition;
        var sqrtDist = dir.x * dir.x + dir.z * dir.z;
        var ds = Mathf.Sqrt(sqrtDist);
        pos.y = GetHeight(ds);

        _moveObject.transform.position = pos;
        _timer += dt;
    }

    private void Init()
    {
        _distance = Vector3.Distance(_moveObject.transform.position, _target.transform.position);
        _moveObject.transform.LookAt(_target.transform.position);
        _toMoveTime = _distance / _moveSpeed;

        var dir = _target.transform.position - _moveObject.transform.position;
        dir.Normalize();
        var thelta = Vector3.Angle(dir, new Vector3(1, 0, 0));
        _vz = Mathf.Sin(Mathf.Deg2Rad * thelta) * _moveSpeed;
        _vx = Mathf.Cos(Mathf.Deg2Rad * thelta) * _moveSpeed;
    }

    private void CalculateCoff()
    {
        _a = -(4 * _height) / (_distance * _distance);
        _b = 4 * _height / _distance;
    }

    private float GetHeight(float ds)
    {
        float y = _a * ds * ds + _b * ds;
        return y;
    }
}
