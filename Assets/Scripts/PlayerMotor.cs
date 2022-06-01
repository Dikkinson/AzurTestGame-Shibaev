using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [Range(0.5f, 2f)]
    [SerializeField] private float boostMultiplier;
    [SerializeField] private float mouseSens;

    private float currentBoost;
    
    private Rigidbody rb;
    private Animator animator;
    private bool canMove;
    private void Start()
    {
        currentBoost = 1;
        canMove = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && canMove)
        {
            rb.velocity = new Vector3(Input.GetAxis("Mouse X") * mouseSens, 0, startSpeed * currentBoost);
            animator.SetBool("Running", true);
            animator.speed = boostMultiplier;
            SoundManager.PlaySound(Sound.Walk, 0.3f * (2-currentBoost));
        }else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Running", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            ScoreSystem.i.Score++;
            other.GetComponent<CoinVfx>().DestroyCoin();
        }
        if (other.CompareTag("Finish"))
        {
            canMove = false;
            GameManager.i.State = GameState.Victory;
            animator.SetBool("Victory", true);
            SoundManager.PlaySound(Sound.Victory);
        }
        if (other.CompareTag("Boost"))
        {
            currentBoost = boostMultiplier;
            SoundManager.PlaySound(Sound.Boost);
        }
    }
}
