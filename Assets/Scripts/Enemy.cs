using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    rojo,
    lila
}
public class Enemy : MonoBehaviour
{
    private GameObject Player;
    public float EnemyHP;
    public float Damage;
    public float Speed;
    public int HPprobability;
    public GameObject HpRecover;

    private Rigidbody enemyRigidbody;

    private PlayerController PlayerControllerScript;
    private AudioManager AMS;

    public Animator EnemyAttack;
    

    Vector3 direction;

    public EnemyType Type;



    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");

        enemyRigidbody = GetComponent<Rigidbody>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        AMS = FindObjectOfType<AudioManager>();

        if (Type == EnemyType.rojo)
        {
            EnemyHP = DataPersistanceScript.sharedInstance.HpRedData;
            Damage = DataPersistanceScript.sharedInstance.DamageRedData;
            Speed = DataPersistanceScript.sharedInstance.SpeedRedData;
            // enemyHp = DataPersistanceHProjo + Multiplicador
        }
        else if( Type == EnemyType.lila)
        {
            EnemyHP = DataPersistanceScript.sharedInstance.HpLilaData;
            Damage = DataPersistanceScript.sharedInstance.DamageLilaData;
            Speed = DataPersistanceScript.sharedInstance.SpeedLilaData;
            // enemyHp = DataPersistanceHPlila + Multiplicador
        }
       


    }

    private void FixedUpdate()
    {
        if (PlayerControllerScript.GOP == false)
        {
            direction = (Player.transform.position - transform.position).normalized;

            //Look at con fisicas
            Quaternion RotationP = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = RotationP;
        }
        else
        {
            Speed = 0f;
        }
        Vector3 RBMovement = Vector3.forward;
        RBMovement = transform.TransformDirection(RBMovement);

        enemyRigidbody.MovePosition(enemyRigidbody.position + RBMovement * Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Quitar esta linea de codigo
        if (Input.GetKeyDown(KeyCode.J))
        {
            DestroyEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            EnemyAttack.SetTrigger("AttaqueEnemigo");
            EnemyAttack.SetTrigger("RedAttack");
        }


        if (other.gameObject.CompareTag("Shield"))
        {
            Empuje(7f);
            AMS.PlaySound(7);
        }
    }

    public void DestroyEnemy()
    {
        Vector3 RecoverLifeSP = new Vector3(transform.position.x, 1, transform.position.z);
        HPprobability = Random.Range(1, 10);

        if(HPprobability == 1)
        {
            Instantiate(HpRecover, RecoverLifeSP, transform.rotation);
        }
        else if( HPprobability == 2)
        {
            Instantiate(HpRecover, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        //Partoculas
        AMS.PlaySound(6);
    }

    public void Empuje(float Fuerza)
    {
        enemyRigidbody.AddForce(-direction * Fuerza, ForceMode.VelocityChange);
    }
}
