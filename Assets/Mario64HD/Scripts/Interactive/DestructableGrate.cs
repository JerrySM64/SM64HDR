using UnityEngine;
using System.Collections;

public class DestructableGrate : TriggerableObject {

    public GameObject DeathEffect;

    public CoinBlock EncagedCoinBlock;

    public void Start()
    {
        if (EncagedCoinBlock)
            EncagedCoinBlock.canBeHit = false;
    }

    public override bool Explosion()
    {
        if (EncagedCoinBlock)
            EncagedCoinBlock.canBeHit = true;

        Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);

        return true;
    }
}
