using UnityEngine;

public class Bike : MonoBehaviour {
	[Header("Parameters")]
	[SerializeField] private float _accelerationMultiplier;
	[SerializeField] private float _slowDownMultiplier;
	
	[Space(10)]
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _minSpeed;
	private float _currentSpeed;
	
	[Space(10)]
	[SerializeField] private Rigidbody _pedals;
	[SerializeField] private float _pedalVelocityMultiplier;

	private Rigidbody _rigidbody;

	public float CurrentSpeed {
		get => _currentSpeed;
		private set => _currentSpeed = Mathf.Clamp(value, _minSpeed, MaxSpeed);
	}

	private float PedalVelocity => CurrentSpeed / MaxSpeed * _pedalVelocityMultiplier;
	public float MaxSpeed => _maxSpeed;

	public static Bike instance;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		if (!GameManager.instance.IsGameActive) {
			return;
		}
		
		Accelerate();
		SpinPedals();
		SetSpeed();
	}


	private void SetSpeed () {
		var acceleration = InputController.instance.SpeedAxis;
		//Checks if player accelerates or slows down.
		if (CurrentSpeed + InputController.instance.SpeedAxis > CurrentSpeed) {
			//Slows acceleration down.
			acceleration *= _accelerationMultiplier;
		} else {
			acceleration *= _slowDownMultiplier;
		}
		CurrentSpeed += acceleration * Time.deltaTime;
	}

	private void SpinPedals() => _pedals.angularVelocity = new Vector3(PedalVelocity, 0,0);

	private void Accelerate() {
		var velocity = _rigidbody.velocity;
		velocity = new Vector3(velocity.x, velocity.y, CurrentSpeed);
		_rigidbody.velocity = velocity * Time.fixedDeltaTime;
	}
}