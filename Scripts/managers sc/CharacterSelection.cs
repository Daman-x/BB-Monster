using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private string[] Cn ={"Knight","StoneStar","Dragon","Skeleton","Beast"};
    private GameObject[] Cl;
    private int index;

    public Text text;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelect");
        text.text = Cn[index];

        Cl = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            Cl[i] = transform.GetChild(i).gameObject;
        }

       foreach(GameObject go in Cl)
            go.SetActive(false);


        if (Cl[index])
            Cl[index].SetActive(true);
    }

    public void leftselection()
    {
        Cl[index].SetActive(false);

        index--;

        if (index < 0)
            index = Cl.Length - 1;

        Cl[index].SetActive(true);

        text.text = Cn[index];

         PlayerPrefs.SetInt("CharacterSelect",index);
    }

    public void rightselection()
    {
        Cl[index].SetActive(false);

        index++;

        if (index > Cl.Length-1)
            index = 0;

        Cl[index].SetActive(true);

        text.text = Cn[index];

        PlayerPrefs.SetInt("CharacterSelect", index);
    }
}
