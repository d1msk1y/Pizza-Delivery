using UnityEngine;
public class CompletionBar : InfoBar {
	private static Transform FinishPosition => GameManager.instance.finishPosition;
	private static Vector3 InitialPlayerPosition => GameManager.instance.initialPlayerPosition;

	private float _distanceToFinish;
	private float _distanceToPlayer;
	
	protected override float FillAmount {
		get {
			_distanceToPlayer = Vector3.Distance(InitialPlayerPosition, Bike.instance.transform.position);
			return _distanceToPlayer/_distanceToFinish;
		}
	}

	private void Start() {
		_distanceToFinish = Vector3.Distance(InitialPlayerPosition, FinishPosition.position);
		_distanceToPlayer = Vector3.Distance(InitialPlayerPosition, Bike.instance.transform.position);
	}
}

