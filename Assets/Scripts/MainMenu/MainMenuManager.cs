using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public GameObject[] GeneralCanvas;

    private AudioManager AMS;
    public Slider SliderVolum;
    public float VolumValue;

    public Animator Fade;
    public GameObject FadeOBJ;

    private void Start()
    {
        //SONIDOS
        AMS = FindObjectOfType<AudioManager>();
        AMS.PlaySound(0);

        SliderVolum.value = 0.5f;
        AudioListener.volume = SliderVolum.value;

        //CANVAS
        FadeOBJ.SetActive(false);
        GeneralCanvas[0].SetActive(true);
        GeneralCanvas[1].SetActive(false);
    }

    public void ChangeSlider(float Valor)
    {
        SliderVolum.value = Valor;
        AudioListener.volume = SliderVolum.value;
    }



    public void Options()
    {
        GeneralChange(0, 1);
        Sounds();
    }

    public void Play()
    {
        FadeOBJ.SetActive(true);
        Sounds();
        StartCoroutine("WaitPlay");
        
    }

    public void Return()
    {
        GeneralChange(1, 0);
        Sounds();
    }

    void GeneralChange(int FalseCanvas, int TrueCanvas)
    {
        GeneralCanvas[FalseCanvas].SetActive(false);
        GeneralCanvas[TrueCanvas].SetActive(true);
    }
    void Sounds()
    {
        AMS.PlaySound(1);
    }



    IEnumerator WaitPlay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
        SliderVolum.value -= 0.2f;
    }
}
