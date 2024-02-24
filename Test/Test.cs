using UnityEngine;
using CodeHelper.Unity;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CodeHelper
{
    internal class Test : MonoBehaviour
    {
        [SerializeField] private GameObject _materialChange;
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private float _speed;
        [SerializeField] private int _testIndex;
        [Header("List Extentions : ")]
        [SerializeField] private List<HasValueTest> _testObjects;
        [SerializeField] private List<int> _testInt;
        [Header("Bezier : ")]
        [SerializeField] private List<Transform> _traectory;
        [SerializeField] private Transform _bezierObject;
        [Header("Circle move :")]
        [SerializeField] private Transform _movableObject;
        [SerializeField] private float _radius;
        [Header("Polygon move :")]
        [SerializeField] private List<Transform> _polygonTest;
        [SerializeField] private GameObject _bullet;
        
        private float _time;
        
        private void Start()
        {
            _bullet.Instance(Vector2.zero).SetPosition(_player.transform).SetRotation(15, 15, 15).PrintName();
        }

        private void Update()
        {
            _player.TransferControl2D(_speed, 15, KeyCode.Space);
            if (_time < 1) _time += 0.01f;
            else _time = 0;
            _bezierObject.MoveByCurve(_traectory, _time);
            _movableObject.MoveByPolygon(_polygonTest, _time, true);
        }
    }
}

