using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCards : MonoBehaviour
{
    int L; 
    public List<int> PickCardRandom;

    public MenuManager MenuManagerScript;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    private void OnEnable()
    {
        MenuManagerScript = FindObjectOfType<MenuManager>();
        L = MenuManagerScript.PowerUpsButtons.Length;

        ShowCards3();
    }

    private int RandomNumUnic()
    {
        int random = Random.Range(0, L);

        while (PickCardRandom.Contains(random))
        {
            random = Random.Range(0, L);
        }
        PickCardRandom.Add(random);
        return random;
    }

    private void ShowCards3()
    {
        PickCardRandom = new List<int>();
        ResetCards();
        int random1 = RandomNumUnic();
        int random2 = RandomNumUnic();
        int random3 = RandomNumUnic();
        MenuManagerScript.PowerUpsButtons[random1].SetActive(true);
        MenuManagerScript.PowerUpsButtons[random2].SetActive(true);
        MenuManagerScript.PowerUpsButtons[random3].SetActive(true);
    }


    private void ResetCards()
    {
         foreach(GameObject Card in MenuManagerScript.PowerUpsButtons)
        {
            Card.SetActive(false);
        }
    }
}
