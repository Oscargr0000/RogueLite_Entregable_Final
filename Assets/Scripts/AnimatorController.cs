using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{


    public Animator SwordAnimator;
    public Animator HondaAttack;
   

    public GameObject HondaSword;
    public GameObject Player;
    private AudioManager AMS;
    private MenuManager MenuManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        AMS = FindObjectOfType<AudioManager>();

        MenuManagerScript = FindObjectOfType<MenuManager>();
        //HondaSword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            AMS.PlaySound(0);
            SwordAnimator.SetTrigger("Attack");
        }
    }
}
