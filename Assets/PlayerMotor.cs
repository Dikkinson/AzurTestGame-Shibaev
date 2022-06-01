using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float mouseSens;
    private Rigidbody rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(Input.GetAxis("Mouse X") * mouseSens, 0, speed);
            animator.SetBool("Running", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Running", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            DOTween.Kill(other.transform);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            GameManager.instance.State = GameState.Victory;
            animator.SetBool("Victory", true);
        }
    }
}
