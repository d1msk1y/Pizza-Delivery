using UnityEngine;
public class InputController : MonoBehaviour{
	[Header("Parameters")]
	[Range(1f, 10f)]
	[SerializeField] private float _sensitivity;
	
	[Space(10)]
	[SerializeField] private Joystick _joystick;
	
	public float SpeedAxis => _joystick.Vertical * _sensitivity;

	public static InputController instance;
	
	private void Awake() => instance = this;
}

