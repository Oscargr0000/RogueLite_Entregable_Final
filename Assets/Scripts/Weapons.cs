using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float Damage;
    private Enemy EnemyScript;
    private AudioManager AMS;
    private SpawnManager SpawnManagerScript;
    private FollowPlayer FollowPlayerScript;
    public ParticleSystem HitParticle;
    public PlayerController PCS;

    public bool LFSactivate;

    public float LfsCapacity;


    private void Start()
    {
        PCS = FindObjectOfType<PlayerController>();
        AMS = FindObjectOfType<AudioManager>();
        FollowPlayerScript = FindObjectOfType<FollowPlayer>();
        SpawnManagerScript = FindObjectOfType<SpawnManager>();
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

            Instantiate(HitParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
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
