using UnityEngine;
using CodeHelper.Unity;
using System.Collections.Generic;
using CodeHelper.Mathematics;

namespace CodeHelper
{
    public class Test : MonoBehaviour
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
        
        private float _time;
        private readonly int[] _testArray = new int[] { 1,2,3,4,5};
        private bool _testFlag = true;
        
        private void Start()
        {
            print("Method add, 5.add95 = " + _testIndex.Add(95));
            _player.FreezeRotation(true);
            print("All numbers without index 5 prints value :");
            _testArray.AllDoWithout((v) => print(v),5);
            print("Test Flag : " + _testFlag);
            _testObjects.AllDo((obj) => obj.Index+=100);
            _testInt.AllDo((value) => value += 200);
            print("Objects");
            _testObjects.AllDo((obj) => print(obj.Index));
            print("ints");
            _testInt.AllDo((value) => print(value));
            this.WaitAndDo(2,() =>
            {
                this.Instantiate(_movableObject.gameObject, _player.position, _player.transform);
                print("bool.Reverse gets link of value: " + _testFlag.Reverse());
                print("Method array[] allDo every component of collection do the action(now print(value)) : ");
                _materialChange.ChangeColor3D(0, 0, 0, 0.5f);
            });
        }

        private void Update()
        {
            _player.TransferControl2D(_speed, 15, KeyCode.Space);
            if (_time < 1) _time += 0.005f;
            else _time = 0;
            _bezierObject.BezieMoves(_traectory, _time);
            _movableObject.position = MathMoving.MoveByPolygon(_polygonTest.GetPositions(), _time, true); 
        }
    }
}

