using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
	private void Awake() {
		GameObject[] musicObj = GameObject.FindGameObjectsWithTag("OST");
		if(musicObj.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
