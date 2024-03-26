using System;
using UnityEngine;

public class PizdaUser : MonoBehaviour
{
    [field :SerializeField] public string _name { get; private set; }
    public PizdaUser()
    {
        _name = "���";
    }

    public override string ToString() => _name;
    
    
}
