using System.Collections;
using UnityEngine;
using CodeHelper.Unity;

namespace CodeHelper
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private GameObject _materialChange;
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private float _speed;
        [SerializeField] private int _testIndex;
        private readonly int[] _testArray = new int[] { 1,2,3,4,5};
        private bool _testFlag = true;
        
        private IEnumerator Start()
        {
            print(_testIndex.Add(95));
            _player.FreezeRotation(true);
            _testArray.AllDoWithout((v) => print(v),5);
            print(_testFlag);
            yield return new WaitForSeconds(2);
            print(_testFlag.Reverse());
            print(_testFlag);
            print(_testIndex);
            print(_testIndex.Percent(20));
            _materialChange.ChangeColor3D(0,0,0, 0.5f);
        }

        private void Update()
        {
            _player.TransferControl2D(_speed, 15, KeyCode.Space);
        }
    }
}

