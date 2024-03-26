using System;
using UnityEngine;

public class UserAsset : MonoBehaviour
{
    [field :SerializeField] public string _name { get; private set; }
    public UserAsset()
    {
        _name = "���";
    }

    public override string ToString() => _name;
    
    
}
