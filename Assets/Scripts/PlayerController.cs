using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;

    public float speed = 10f;
    private float RunningSpeed = 2f;
    private float rotationSpeed = 200f;

    private float verticalInput;
    private float horizontalInput;
    private float MouseXInput;

    private Vector3 GravityForce = new Vector3(0, -9.8f, 0);

    public bool itsOntheGround;
    public bool GOP;
    public bool LockCursor;

    private int Jumps;
    public int JumpMax = 1;

    public float HP = 100f;

    public Rigidbody RigidBodyComponent;
    public GameObject RunningPT;
    private AudioManager AMS;
    private Enemy ES;
    private MenuManager MenuManagerScript;
    private AnimatorController ACS;
    public ParticleSystem Deap_ps;
    public ParticleSystem Heal_ps;



    void Start()
    {
        
        AMS = FindObjectOfType<AudioManager>();
        ACS = FindObjectOfType<AnimatorController>();
        ES = FindObjectOfType<Enemy>();
        RigidBodyComponent = GetComponent<Rigidbody>();
        MenuManagerScript = FindObjectOfType<MenuManager>();

        GOP = false;
        Physics.gravity = GravityForce;

        RunningPT.SetActive(false);

        AMS.PlaySound(11);
    }

    private void FixedUpdate()
    {
        // El movimiento funciona con WASD para avanzar y para girar con el raton

        //Movimiento del Raton
        MouseXInput = Input.GetAxis("Mouse X");
        Quaternion CurrenteRotation = Quaternion.Euler(new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime * MouseXInput);
        RigidBodyComponent.MoveRotation(RigidBodyComponent.rotation * CurrenteRotation);

        //Movimiento del Player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 RbMovement = new Vector3(horizontalInput, 0f, verticalInput);
        RbMovement = transform.TransformDirection(RbMovement);

        RigidBodyComponent.MovePosition(RigidBodyComponent.position + RbMovement * speed * Time.deltaTime);
    }

    void Update()
    {

        // Salto + Contador de saltos realizados
        if (Input.GetKeyDown(KeyCode.Space) && Jumps <= JumpMax)
        {
            RigidBodyComponent.AddForce(Vector3.up * 500f, ForceMode.Impulse);
            Jumps++;
        }

        if(LockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }


        //Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += RunningSpeed;
            RunningPT.SetActive(true);
            AMS.PlaySound(8);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= RunningSpeed;
            RunningPT.SetActive(false);
            AMS.StopSound();
        }    
    }


    // Resetea la cantidad de saltos realizados al tocar el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jumps = 0;
        }

        //Intento de evitar que se traspasen las paredes
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 Direccion = transform.position - collision.gameObject.transform.position;
            RigidBodyComponent.AddForce(-Direccion * 50f, ForceMode.Impulse);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            HP += 5;
            Destroy(other.gameObject);
            Instantiate(Heal_ps, transform.position, transform.rotation);
            if (HP >= MenuManagerScript.VidaMaxima)
            {
                HP = MenuManagerScript.VidaMaxima;
            }
        }

        if (other.gameObject.CompareTag("EnemyHit"))
        {
            HP -= ES.Damage;

            int RandomSaound = Random.Range(1, 3);
            AMS.PlaySound(RandomSaound);

            if (HP <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    
}
