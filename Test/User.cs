using System;
using UnityEngine;

public class User : MonoBehaviour
{
    [field :SerializeField] public string _name { get; private set; }
    public User()
    {
        _name = "éöó";
    }

    public override string ToString() => _name;
    
    
}
