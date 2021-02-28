using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudselect : MonoBehaviour
{
    private GameObject[] charlist;
  
    public GameObject plcloud;
    public  int index;
     public void Start()
    {       
        charlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            charlist[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in charlist)
        {
            go.SetActive(false);
        }
        if (charlist[index])
        {
            charlist[index].SetActive(true);
        }     
        if (plcloud.GetComponent<playercontrol>().playerscore % 5000== 0)
                {
            index += 1;
            left();
            Debug.Log(index);
        }
    }
    public void left()
    {
        charlist[index].SetActive(false);
        index++;
        if (index == charlist.Length)
            index = 0;
        charlist[index].SetActive(true);

    }


}
