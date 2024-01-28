using UnityEngine;
using CodeHelper.Unity;
using System.Collections.Generic;

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
        private readonly int[] _testArray = new int[] { 5,4,3,2,1};
        private bool _testFlag = true;
        
        private void Start()
        {
            foreach(var item in _testArray.Reverse())
            {
                print(item);
            }
            //print("Method add, 5.add95 = " + _testIndex.Add(95));
            //_player.FreezeRotation(true);
            //print("All numbers without index 5 prints value :");
            //_testArray.AllDoWithout((v) => print(v),5);
            //print("Test Flag : " + _testFlag);
            //_testObjects.AllDo((obj) => obj.Index+=100);
            //_testInt.AllDo((value) => value += 200);
            //print("Objects");
            //_testObjects.AllDo((obj) => print(obj.Index));
            //print("ints");
            //_testInt.AllDo((value) => print(value));
            //this.WaitAndDo(2,() =>
            //{
            //    this.Instantiate(_movableObject.gameObject, _player.position, _player.transform);
            //    print("bool.Reverse gets link of value: " + _testFlag.Reverse());
            //    print("Method array[] allDo every component of collection do the action(now print(value)) : ");
            //    _player.gameObject.SetName("Igrok");
            //    _materialChange.ChangeColor3D(0, 0, 0, 0.5f);
            //});
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

