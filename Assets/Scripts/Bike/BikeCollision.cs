using UnityEngine;
using UnityEngine.SceneManagement;
public class BikeCollision : MonoBehaviour{
	private void OnCollisionEnter (Collision collision) {
		if (collision.collider.CompareTag("Obstacle")) {
			GameManager.instance.GameOver();
		}
	}
}