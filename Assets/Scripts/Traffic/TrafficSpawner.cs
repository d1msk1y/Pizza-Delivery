using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrafficSpawner : MonoBehaviour {
	[Header("Parameters")]
	[SerializeField] private float _spawnRate;
	[SerializeField] private float _randomModifier;
	
	[Space(10)]
	public Car[] _traffic;
	
	private float SpawnRate {
		get {
			var random = Random.Range(1, _randomModifier);
			return _spawnRate * random;
		}
	}

	private void OnEnable() {
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn() {
		Instantiate(GetRandomCar(), transform.position, transform.rotation, transform);
		yield return new WaitForSeconds(SpawnRate);
		StartCoroutine(Spawn());
	}

	private Car GetRandomCar() {
		var range = Random.Range(0, _traffic.Length);
		return _traffic[range];
	}
}