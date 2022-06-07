using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Enemy EnemyScript;
    public PlayerController PCS;

    public float Damage;
    public ParticleSystem HitParticle;

    public bool LFSactivate;
    public float LfsCapacity;


    private void Start()
    {
        PCS = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript = other.gameObject.GetComponent<Enemy>();
            EnemyScript.Empuje(7f);

            if (LFSactivate)
            {
                PCS.HP += LfsCapacity;
            }

            Instantiate(HitParticle, other.gameObject.transform.position, other.gameObject.transform.rotation); // PARTICULAS
            //var HitEm = HitParticle.emission;
            //HitEm.enabled = true;

            EnemyScript.EnemyHP -= Damage;
            Debug.Log($"Enemy:{EnemyScript.EnemyHP}");
            
            if( EnemyScript.EnemyHP <= 0f)
            {
                EnemyScript.DestroyEnemy();
            }
        }
    }
}
