using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	[Header("UI")]
	[SerializeField] private GameObject _startScreen;
	[SerializeField] private GameObject _hud;
	[SerializeField] private GameObject _gameOverScreen;
	[SerializeField] private GameObject _finishScreen;
	[SerializeField] private GameObject _cameraRotator;

	[Header("Player Info")]
	public Transform finishPosition;
	public Vector3 initialPlayerPosition;

	public bool IsGameActive { get; private set; }
	public bool IsGameOver { get; private set; }
	
	public static GameManager instance;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		initialPlayerPosition = Bike.instance.transform.position;
	}

	private void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) {
			return;
		}
		if (!IsGameActive) {
			StartGame();
		}
		if (IsGameOver) {
			Restart();
		}
	}

	public void Finish() {
		_finishScreen.SetActive(true);
		StopGame();
	}
	
	public void Restart() {
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void GameOver() {
		_gameOverScreen.SetActive(true);
		StopGame();
	}
	private void StopGame() {

		_hud.SetActive(false);
		IsGameOver = true;
		Time.timeScale = 0;
	}

	private void StartGame() {
		_startScreen.SetActive(false);
		_cameraRotator.SetActive(false);
		_hud.SetActive(true);
		IsGameActive = true;
	}
}
