using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryPoint : MonoBehaviour {
	[Header("Color")]
	[SerializeField] private Color _fadeOutColor;
	[SerializeField] private SpriteRenderer _pointSpriteRenderer;

	[Space(10)]
	[SerializeField] private Animator _animator;

	public UnityEvent onCollect;

	private void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			_animator.SetTrigger("Throw");
			StartCoroutine(FadeOutPoint());
			onCollect?.Invoke();
		}
	}

	private IEnumerator FadeOutPoint() {
		float current = 0;
		while (_pointSpriteRenderer.color.a > 0) {
			var lerpValue = Mathf.InverseLerp(0, 1f, current);
			_pointSpriteRenderer.color = Color.Lerp(_pointSpriteRenderer.color, _fadeOutColor, lerpValue);
			current += Time.deltaTime;
			yield return null;
		}
	}
}
