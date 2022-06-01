using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVfx : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    private void OnDestroy()
    {
        GameObject explotion = Instantiate(particle, transform.position, transform.rotation);
        Destroy(explotion, 1.5f);
    }
    
}
