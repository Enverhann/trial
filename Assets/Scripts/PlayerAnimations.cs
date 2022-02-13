using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public PlayerController playerController;
    public GameObject confetti;

    void Start()
    {
        anim = GetComponent<Animator>();
        confetti.SetActive(false);
    }

    void Update()
    {
        
    }
    public void Run()
    {
        anim.SetBool("Run", true);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            anim.Play("Jump");         
        }
        if (other.CompareTag("Finish"))
        {//Stop movement, rotate player,activates confetti and start dance animation after finishing the game.
            playerController.MovementStop();
            player.localPosition = new Vector3(0, transform.position.y, transform.position.z);
            player.transform.Rotate(0, 180, 0);
            anim.Play("Dance");
            confetti.SetActive(true);
        }
    }
}
