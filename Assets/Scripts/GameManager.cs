using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	
	public Text HealthCount;
	public Image HealthUI;
    public GameObject OptionsMenu;

	private int MAX_HEALTHCOUNT = 3;
	private int livesRemain;

	//

	public int coin = 0;
	public int maxCoin = 0;
	public Text txtCoin;
	public Text txtMaxCoin;

	// Use this for initialization
	void Awake () {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickups");
		foreach(GameObject pickup in pickups) {
			pickup.AddComponent<Pickup> ();
		}
		livesRemain = MAX_HEALTHCOUNT;
		SetHealthUI ();

		maxCoin = PlayerPrefs.GetInt("MaxCoins", 0);
		txtMaxCoin.text = " " + maxCoin.ToString();

		if(PlayerPrefs.HasKey("Coins"))
        {
			Scene ActiveScene = SceneManager.GetActiveScene();
            if (ActiveScene.buildIndex != 1)
            {
				coin = PlayerPrefs.GetInt("Coins");
            }
        }
	}

    private void Update()
    {
		txtCoin.text = " " + coin;
	}

    public void SetPlayerHealth (float healthRatio) {
		HealthUI.rectTransform.localScale = new Vector3 (healthRatio, 1, 0);
		if (healthRatio <= 0) {
			PlayerDied();
			HealthUI.rectTransform.localScale = new Vector3 (1, 1, 0);
		}
	}

	void PlayerDied () {
		livesRemain -= 1;
		SetHealthUI ();
		if (livesRemain <= 0) {
			SceneManager.LoadScene("Level 1");
			PlayerPrefs.SetInt("MaxCoins", maxCoin += coin);
			PlayerPrefs.DeleteKey("Coins");
			coin = 0;
		}
		else
        {
			PlayerPrefs.SetInt("MaxCoins", maxCoin += coin);
			PlayerPrefs.DeleteKey("Coins");
			coin = 0;
		}			
	}

	void SetHealthUI () {
		HealthCount.text = "X " + livesRemain.ToString ();
	}

    public void ToggleOptionsMenu ()
    {
        OptionsMenu.SetActive(!OptionsMenu.activeSelf);
        if (OptionsMenu.activeSelf)
        {
            Time.timeScale = 0;
        } else
        {
            SetTimeScale();
        }
    }

	public void Restartlevel()
	{
		SetTimeScale();
		SceneManager.LoadScene("Level 1");
	}

	public void LoadMainMenu ()
    {
        SetTimeScale();
        SceneManager.LoadScene("Menu");
    }

    void SetTimeScale ()
    {
        Time.timeScale = 1;
    }
}
