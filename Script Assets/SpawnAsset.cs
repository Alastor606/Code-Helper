using UnityEngine;

public class SpawnAsset : MonoBehaviour
{
	[SerializeField] private GameObject _objectToSpawn;
	[SerializeField] private Vector2 _position;

	public void Start()
	{
		Spawn();	
	}

	public void Spawn() =>
		Instantiate(_objectToSpawn, _position, Quaternion.identity);
}