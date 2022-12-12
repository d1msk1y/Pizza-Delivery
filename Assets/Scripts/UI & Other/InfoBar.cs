using UnityEngine;
using UnityEngine.UI;
public abstract class InfoBar : MonoBehaviour {
	[SerializeField] private Image _fillImage;
	[SerializeField] private Scrollbar _scrollbar;
	
	protected virtual float FillAmount { get;}
	protected virtual bool IsUpdating => true;

	private void Update() {
		if (IsUpdating) {
			UpdateBar();
		}
	}

	protected void UpdateBar() {
		_fillImage.fillAmount = FillAmount;
		_scrollbar.value = FillAmount;
	}
}

