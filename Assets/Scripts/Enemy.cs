using UnityEngine;

public enum EnemyType
{
    rojo,
    lila
}
public class Enemy : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
    private AudioManager AMS;

    private Rigidbody enemyRigidbody;


    private GameObject Player;
    public GameObject HpRecover;

    //STATS
    public float EnemyHP;
    public float Damage;
    public float Speed;
    public Animator EnemyAttack;


    public int HPprobability;
    Vector3 direction;

    public EnemyType Type;

    void Start()
    {
        Player = GameObject.Find("Player");

        enemyRigidbody = GetComponent<Rigidbody>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        AMS = FindObjectOfType<AudioManager>();

        if (Type == EnemyType.rojo)
        {
            // Stats enemyRed
            EnemyHP = DataPersistanceScript.sharedInstance.HpRedData;
            Damage = DataPersistanceScript.sharedInstance.DamageRedData;
            Speed = DataPersistanceScript.sharedInstance.SpeedRedData;
        }
        else if( Type == EnemyType.lila)
        {
            // Stats enemyLila
            EnemyHP = DataPersistanceScript.sharedInstance.HpLilaData;
            Damage = DataPersistanceScript.sharedInstance.DamageLilaData;
            Speed = DataPersistanceScript.sharedInstance.SpeedLilaData;
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

        //Movimiento hacia el Player
        Vector3 RBMovement = Vector3.forward;
        RBMovement = transform.TransformDirection(RBMovement);

        enemyRigidbody.MovePosition(enemyRigidbody.position + RBMovement * Speed * Time.deltaTime);
    }

    void Update()
    {
        // LIFE HACK ;)
        if (Input.GetKeyDown(KeyCode.J))
        {
            DestroyEnemy();
        }
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
            Empuje(8f);
            AMS.PlaySound(7);
        }
    }

    public void DestroyEnemy()
    {
        Vector3 RecoverLifeSP = new Vector3(transform.position.x, 1, transform.position.z);

        //Probabilidad del 20% de sacar una orbe de curacion
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
        AMS.PlaySound(6);
    }

    public void Empuje(float Fuerza) 
    {
        enemyRigidbody.AddForce(-direction * Fuerza, ForceMode.VelocityChange);
    }
}
