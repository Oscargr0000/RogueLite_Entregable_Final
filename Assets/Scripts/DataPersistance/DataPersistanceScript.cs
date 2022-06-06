using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceScript : MonoBehaviour
{

    public static DataPersistanceScript sharedInstance;

    public float HpRedData;
    public float DamageRedData;
    public float SpeedRedData;

    public float HpLilaData;
    public float DamageLilaData;
    public float SpeedLilaData;


    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
