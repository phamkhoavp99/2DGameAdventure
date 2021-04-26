using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	
	public Text HealthCount;
	public Image HealthUI;
    public GameObject OptionsMenu;
	public GameObject DeadMenu;
	public GameObject VictoryMenu;
	public GameObject goNote;
	public Text Note;
	public GameObject GameOverMenu;
	

	private int MAX_HEALTHCOUNT = 3;
	public int livesRemain;

	//

	public int coin = 0;
	public int maxCoin = 0;
	public Text txtCoin;
	public Text txtMaxCoin;
	public int numcoin = 1;
	public SoundManager sound;

    void Start()
    {
		sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
	}
    // Use this for initialization
    void Awake () {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickups");
		foreach(GameObject pickup in pickups) {
			pickup.AddComponent<Pickup> ();
		}
		livesRemain = MAX_HEALTHCOUNT;
		//SetHealthUI ();

		maxCoin = PlayerPrefs.GetInt("MaxCoins", 0);
	

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
		txtMaxCoin.text = " " + maxCoin.ToString();
		SetHealthUI();
	}

    public void SetPlayerHealth (float healthRatio) {
		HealthUI.rectTransform.localScale = new Vector3 (healthRatio, 1, 0);
		if (healthRatio <= 0) {
			PlayerDied();
			HealthUI.rectTransform.localScale = new Vector3 (1, 1, 0);
		}
	}

	void PlayerDied()
	{
		
		livesRemain -= 1;
		if (livesRemain <= 0)
		{
			sound.Playsound("gameover");
			PlayerPrefs.SetInt("MaxCoins", maxCoin += coin);
			PlayerPrefs.DeleteKey("Coins");
			coin = 0;
			DeadMenu.SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void buyLivesRemainx1()
    {
        if (maxCoin >= 70)
        {
			sound.Playsound("buy");
			livesRemain += 1;
			maxCoin -= 70;
			Time.timeScale = 1;
			DeadMenu.SetActive(false);
			goNote.SetActive(false);
		}
        else
        {
			goNote.SetActive(true);
			Note.text = "You don't have enough money";
        }
	}

	public void buyLivesRemainx2()
	{
        if (maxCoin >= 150)
		{
			sound.Playsound("buy");
			livesRemain += 2;
			maxCoin -= 150;
			Time.timeScale = 1;
			DeadMenu.SetActive(false);
			goNote.SetActive(false);
		}
        else
        {
			goNote.SetActive(true);
			Note.text = "You don't have enough money";
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
	
	public void Restartlevel2()
    {
		SetTimeScale();
		SceneManager.LoadScene("Level 2");
	}
	public void LoadScenceLevel2()
    {
		SetTimeScale();
		SceneManager.LoadScene("Level 2");
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
