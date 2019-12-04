using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharList_Script : MonoBehaviour {

    private GameObject[] charlist;
    private int index = 0;

	void Start () {
        index = PlayerPrefs.GetInt("CharacterSelected");

        //Make an array includes all of the models from "char list"
        charlist = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            charlist[i] = transform.GetChild(i).gameObject;
            charlist[i].SetActive(false);
        }
        //Set the Selected char active
        if(charlist[index])
        charlist[index].SetActive(true);
	}

    public void ToggleLeft()
    {
        charlist[index].SetActive(false);

        index--;
        if (index == -1)
            index = charlist.Length - 1;

        charlist[index].SetActive(true);
    }

    public void ToggleRight()
    {
        charlist[index].SetActive(false);

        index++;
        if (index == charlist.Length)
            index = 0;

        charlist[index].SetActive(true);
    }

    public void ConfirmBotton()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        Destroy(obj);

        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Game");
    }

}
