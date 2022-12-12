using UnityEngine;
public class Car : MonoBehaviour {
	[SerializeField] private float _acceleration;
	[SerializeField] private float _maxSpeed;

	private Rigidbody _rigidbody;

	private void Start() {
		_rigidbody = GetComponent<Rigidbody>();
		Destroy(gameObject,10);
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		_rigidbody.AddForce(transform.forward * (_acceleration * Time.fixedDeltaTime), ForceMode.Force);
		
		var clamp = Mathf.Clamp(_rigidbody.velocity.x, -_maxSpeed, _maxSpeed);
		_rigidbody.velocity = new Vector3(clamp, 0);
	}
}

