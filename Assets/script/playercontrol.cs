using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class playercontrol : MonoBehaviour
{
   
    public CharacterController cont;
    public  int scale;
    public static int dede=8 ;
    int scalelimit=3;
    public GameObject jj;
    public GameObject lit;
    public GameObject cloudone;
    public GameObject cloudtwo;
    public GameObject rain1;
    public GameObject rain2;
    public GameObject rain3;
    public float speed;  
    float raintime = 0;
    public Button lightopen;
    public Camera cam;
    public int score=0;
    public  int plscore;
    private int amuont;
    public  int playerscore=25000;
    public TextMeshProUGUI textamount;
    public GameObject textbas;
    public TextMeshProUGUI scoretext;
    public GameObject killbot;

    void Start()
    {
        cont = GetComponent<CharacterController>();
        textbas.SetActive(false);
    }
    void Update()
    {
        raintime += Time.deltaTime;
        if (raintime > 10)
        {
            raintime = 0;
            rain1.SetActive(true);
            Invoke("failrain",5f);
        }

        Vector3 mov = new Vector3(SimpleInput.GetAxis("Horizontal") * speed, 0, SimpleInput.GetAxis("Vertical") * speed);
        cont.Move(mov * Time.deltaTime);
        if (scale > scalelimit)
        {

           transform.localScale += new Vector3(1f,0, 0.6f);
           jj. transform.localScale += new Vector3(0, 0, 0.04f);
            cam.transform.position += new Vector3(0, 10, 5f);
            scale = 0;           
            scalelimit += 6;
            if (dede < 15)
            {
                lit.layer = dede;
                dede += 1;
            }
            if (dede == 11)
            {
                cloudone.SetActive(true);
                rain2.SetActive(true);
            }
            else if (dede == 14)
            {
                cloudtwo.SetActive(true);
                rain3.SetActive(true);
            }

        }
        scoretext.text = playerscore.ToString();

    }
    void OnCollisionEnter(Collision col)
    {
        textbas.SetActive(false);
        if (col.gameObject.tag == "botplayer")
        {
            if (playerscore-25 > col.gameObject.GetComponent<bot>().botscore)
            {
                killbot.SetActive(true);
                Invoke("textfalse", 1);
                amuont = 10;
            }
            else if (playerscore < col.gameObject.GetComponent<bot>().botscore)
            {
                col.gameObject.GetComponent<bot>().scaler += 10;
                jj.SetActive(false);
                lit.SetActive(false);
                Invoke("jjclodon", 5);
            }
        }


        if (col.gameObject.tag == "build1")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 1;
            amuont = 1;
        }
       else if (col.gameObject.tag == "build2")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 2;
            amuont = 2;
        }
       else if (col.gameObject.tag == "build3")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 4;
            amuont = 4;
        }
        else if (col.gameObject.tag == "build4")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 6;
            amuont = 6;
        }
        else if (col.gameObject.tag == "build5")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 8;
            amuont = 8;
        }
        else if (col.gameObject.tag == "build6")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 10;
            amuont = 10;
        }
        else if (col.gameObject.tag == "build7")
        {
            col.gameObject.tag = "Untagged";
            Destroy(col.gameObject, 2);
            scale += 12;
            amuont = 12;
        }
        else if (col.gameObject.tag == "buildgas1")
        {
            col.gameObject.tag = "Untagged";
            scale += 2;
            amuont = 2;
        }
        else if (col.gameObject.tag == "buildgas2")
        {
            col.gameObject.tag = "Untagged";
            scale += 5;
            amuont = 5;
        }
        else if (col.gameObject.tag == "buildgas3")
        {
            col.gameObject.tag = "Untagged";
            scale += 10;
            amuont = 10;
        }

        playerscore += amuont;
        textbas.SetActive(true);

        textamount.text = amuont.ToString();
        Invoke("textfalse", 1);
        
    }
    void textfalse()
    {
        killbot.SetActive(false);
        textbas.SetActive(false);
    }
    public void lightning()
    {
        lit.SetActive(true);
        Invoke("fail", 0.2f);
    }
    void fail()
    {
        lightopen.interactable = false;
        lit.SetActive(false);
        Invoke("but", 0.7f);
    }
    void but()
    {
        lightopen.interactable = true;
        
    }
    void failrain()
    {
        rain1.SetActive(false);
    }
    void jjclodon()
    {
        gameObject.SetActive(true);
    }

}



