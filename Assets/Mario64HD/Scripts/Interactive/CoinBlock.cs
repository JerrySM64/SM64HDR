using UnityEngine;
using System.Collections;

public class CoinBlock : TriggerableObject {

    public GameObject BottomHitCoinToss;
    public GameObject GroundPoundHitCoinToss;
    public Transform ArtController;
    public GameObject DeathEffect;

    public bool canBeHit { get; set; }

    public int NumberOfCoins = 8;

    private bool currentlyTossingCoin;

    private int currentCoins;

    void Awake()
    {
        canBeHit = true;

        currentCoins = NumberOfCoins;
    }

    public override bool BottomHit()
    {
        if (!canBeHit)
            return false;

        currentCoins--;

        if (!currentlyTossingCoin)
        {
            BonkToss();
        }

        return false;
    }

    public override bool GroundPound()
    {
        if (!canBeHit)
            return false;

        currentCoins--;

        if (!currentlyTossingCoin)
        {
            GroundPoundToss();
        }

        return false;
    }

    private void BonkToss()
    {
        currentlyTossingCoin = true;

        GetComponent<AudioSource>().Play();

        GameObject.FindObjectOfType<GameMaster>().AddCoin();
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(1);

        GetComponent<Animation>().Play("bonk");

        Invoke("Reset", GetComponent<Animation>()["bonk"].length);

        Invoke("BonkTossEffect", 0.1f);
    }

    private void GroundPoundToss()
    {
        currentlyTossingCoin = true;

        GetComponent<AudioSource>().Play();

        GameObject.FindObjectOfType<GameMaster>().AddCoin();
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(1);

        GetComponent<Animation>().Play("ground_pound");

        Invoke("Reset", GetComponent<Animation>()["ground_pound"].length);

        Invoke("GroundPoundTossEffect", 0.1f);
    }

    private void BonkTossEffect()
    {
        Instantiate(BottomHitCoinToss, ArtController.position, Quaternion.identity);

        if (currentCoins == 0)
        {
            Death();
        }
    }

    private void GroundPoundTossEffect()
    {
        Instantiate(GroundPoundHitCoinToss, ArtController.position, Quaternion.identity);

        if (currentCoins == 0)
        {
            Death();
        }
    }

    private void Reset()
    {
        currentlyTossingCoin = false;
    }

    private void Death()
    {
        Instantiate(DeathEffect, ArtController.position, Quaternion.identity);

        Destroy(transform.parent.gameObject);
    }
}
