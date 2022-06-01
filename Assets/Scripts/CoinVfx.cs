using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVfx : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    public void DestroyCoin()
    {
        SoundManager.PlaySound(Sound.Coin);
        GameObject explotion = Instantiate(particle, transform.position, transform.rotation);
        Destroy(explotion, 1f);
        Destroy(gameObject);
    }
}
