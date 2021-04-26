using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, items, sword, enemydie, humanhit, gameover, buy;
    public AudioSource adisrc;
   

   

   
    void Start()
    {
        
        coins = Resources.Load<AudioClip>("GiveCoin");
        items = Resources.Load<AudioClip>("GiveItem");
        sword = Resources.Load<AudioClip>("Sword");
        enemydie = Resources.Load<AudioClip>("EnemyDie");
        humanhit = Resources.Load<AudioClip>("HumanHit");
        gameover = Resources.Load<AudioClip>("GameOver");
        buy = Resources.Load<AudioClip>("Buy");

        adisrc = GetComponent<AudioSource>();
       
    }


   public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;
            case "items":
                adisrc.clip = items;
                adisrc.PlayOneShot(items, 0.6f);
                break;
            case "sword":
                adisrc.clip = sword;
                adisrc.PlayOneShot(sword, 0.6f);
                break;
            case "enemydie":
                adisrc.clip = enemydie;
                adisrc.PlayOneShot(enemydie, 0.6f);
                break;
            case "humanhit":
                adisrc.clip = humanhit;
                adisrc.PlayOneShot(humanhit, 0.6f);
                break;
            case "gameover":
                adisrc.clip = gameover;
                adisrc.PlayOneShot(gameover, 0.6f);
                break;
            case "buy":
                adisrc.clip = buy;
                adisrc.PlayOneShot(buy, 1f);
                break;

        }
    }
}
