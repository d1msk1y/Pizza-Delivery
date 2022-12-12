public class SpeedBar : InfoBar {
	protected override float FillAmount => Bike.instance.CurrentSpeed/Bike.instance.MaxSpeed;
	protected override bool IsUpdating => InputController.instance.SpeedAxis != 0;

	private void Start() {
		UpdateBar();
	}
}