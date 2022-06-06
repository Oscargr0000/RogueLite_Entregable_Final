using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] Sound;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlaySound(int SoundNum)
    {
        AS.PlayOneShot(Sound[SoundNum], 1);
    }

    public void StopSound()
    {
        AS.Stop();
    }

    // 0 = Sonido Espada
    // 1 y 2 = Sonido Golpe Enemigo
    // 3  = Golpe a Enemigos
    // 4 = seleccion de cartas
    // 5 = GameOver
    // 6 = Muerte enemigo
    // 7 = Escudp
    // 8 = correr
    // Botones MainMenu
    // 10 = Botones GamoOver y Pausa
    //11 Musica
}
