using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataEnemy : MonoBehaviour
{
    private SpawnManager SpawnManagerScript;
    public float HpRed;
    public float DamageRed;
    public float SpeedRed;

    public float HpLila;
    public float DamageLila;
    public float SpeedLila;

    int i;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManagerScript = FindObjectOfType<SpawnManager>();


        DataPersistanceScript.sharedInstance.HpRedData = HpRed;
        DataPersistanceScript.sharedInstance.HpLilaData = HpLila;


        DataPersistanceScript.sharedInstance.DamageRedData = DamageRed;
        DataPersistanceScript.sharedInstance.DamageLilaData = DamageLila;


        DataPersistanceScript.sharedInstance.SpeedRedData = SpeedRed;
        DataPersistanceScript.sharedInstance.SpeedLilaData = SpeedLila;
    }

    private void Update()
    {
       if(SpawnManagerScript.EnemyLeft == 0 && SpawnManagerScript.ShowPowerUps == false)
        {
            AddStats();
        }
        else
        {
            i = 0;
        }

    }

    void AddStats()
    {
         for (i = 0; i < 1; i++)
         {
                HpRed = HpRed + 1f;
                HpLila = HpLila + 1f;
                DamageLila = DamageLila + 0.5f;
                DamageRed = DamageRed + 0.7f;
                SpeedLila = SpeedLila + 0.1f;
                SpeedRed = SpeedRed + 0.1f;

            DataPersistanceScript.sharedInstance.HpRedData = HpRed;
            DataPersistanceScript.sharedInstance.HpLilaData = HpLila;


            DataPersistanceScript.sharedInstance.DamageRedData = DamageRed;
            DataPersistanceScript.sharedInstance.DamageLilaData = DamageLila;


            DataPersistanceScript.sharedInstance.SpeedRedData = SpeedRed;
            DataPersistanceScript.sharedInstance.SpeedLilaData = SpeedLila;

        }
        
    }
}
