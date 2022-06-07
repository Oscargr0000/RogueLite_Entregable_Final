using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator SwordAnimator;
    public Animator HondaAttack;
   

    public GameObject HondaSword;
    public GameObject Player;
    private AudioManager AMS;


    void Start()
    {
        AMS = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AMS.PlaySound(0);
            SwordAnimator.SetTrigger("Attack");
        }
    }
}
