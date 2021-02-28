using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public int dede = 8;
    public float speed;
    private bool isleft = false;
    private bool isright = false;
    public  int scaler = 0;
    private bool iswander = false;
    public static bool bult;
    float elapsedTime = 0.0f;
    int scalelimit = 6;
    public GameObject cloudone;
    public GameObject cloudtwo;
    public GameObject jj;
    public GameObject clod;
    float raintime = 0;
    public GameObject rain1;
    public int botscore=0;
    
    void Update()
    {
       
        raintime += Time.deltaTime;
        if (raintime > 10)
        {
            raintime = 0;
            rain1.SetActive(true);
            Invoke("failrain", 5f);
        }
        if (iswander == false)
        {
            StartCoroutine(runaway());
        }
        if (isright == true)
        {
            transform.Rotate(transform.up *  50);
            isright = false;
        }
        if (isleft == true)
        {
            transform.Rotate(transform.up * -270);
            isleft = false;
        }
     
          
                transform.position += transform.forward * speed * Time.deltaTime;
       
            elapsedTime += Time.deltaTime;

            if (elapsedTime > 1.5f)
            {
                elapsedTime = 0;
                fok();
            }
        if (scaler > scalelimit)
        {

            transform.localScale += new Vector3(1f, 0, 0.6f);
            jj.transform.localScale += new Vector3(0, 0, 0.04f);
            scaler = 0;
            scalelimit += 3;

            
            if (dede < 15)
            {
                clod.layer = dede;
                dede += 1;
            }
            if (dede == 11)
            {
                cloudone.SetActive(true);
            }
            else if (dede == 14)
            {
                cloudtwo.SetActive(true);
            }

        }

    }
    IEnumerator runaway()
    {
        float rtime = Random.Range(0f, 10f);
        int rrun = Random.Range(1, 3);
        int rrotate = Random.Range(1, 2);

        iswander = true;
        yield return new WaitForSeconds(rrun);
     
        if (rrotate == 1)
        {
            isright = true;
            yield return new WaitForSeconds(rtime);
            isright = false;
        }
        if (rrotate == 2)
        {
            isleft = true;
            yield return new WaitForSeconds(rtime);
            isleft = false;
        }
        iswander = false;
    }

    void OnCollisionEnter(Collision col)

    {
        if (col.gameObject.tag == "botplayer")
        {
            if (botscore < col.gameObject.GetComponent<bot>().botscore)
            {
          jj.SetActive(false);
                clod.SetActive(false);
                Invoke("jjbot", 5);
               col.gameObject.GetComponent<bot>(). scaler += 10;
               
            }
         
        }
        if (col.gameObject.tag == "Player")
        {
            if (botscore < col.gameObject.GetComponent<playercontrol>().playerscore - 25)
            {
                jj.SetActive(false);
                clod.SetActive(false);
                Invoke("jjbot", 5);
                col.gameObject.GetComponent<playercontrol>().scale += 10;

            }

        }
        if (col.gameObject.tag == "wall")
        {
            isleft = true;
        }

        if (col.gameObject.tag == "build1")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 1;
            botscore += 1;
        }
        else if (col.gameObject.tag == "build2")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 2;
            botscore += 2;
        }
        else if (col.gameObject.tag == "build3")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 4;
            botscore += 4;
        }
        else if (col.gameObject.tag == "build4")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 6;
            botscore += 6;
        }
        else if (col.gameObject.tag == "build5")
        {
            Destroy(col.gameObject,  1.5f);
            scaler += 8;
            botscore += 8;
        }
        else if (col.gameObject.tag == "build6")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 11;
            botscore += 11;
        }
        else if (col.gameObject.tag == "build7")
        {
            Destroy(col.gameObject, 1.5f);
            scaler += 15;
            botscore += 15;
        }
        else if (col.gameObject.tag == "buildgas1")
        {
            col.gameObject.tag = "Untagged";
            scaler += 2;
            botscore += 5;
        }
        else if (col.gameObject.tag == "buildgas2")
        {
            col.gameObject.tag = "Untagged";
            scaler += 5;
            botscore += 6;
        }
        else if (col.gameObject.tag == "buildgas3")
        {
            col.gameObject.tag = "Untagged";
            scaler += 10;
            botscore += 9;
        }

    }
    void fok()
    {
        clod.SetActive(true);
        Invoke("cancelfok", 0.2f);
    }
    void cancelfok()
    {
        clod.SetActive(false);
    }
    void failrain()
    {
        rain1.SetActive(false);
    }
    void jjbot()
    {
        jj.SetActive(true);
        clod.SetActive(true);
    }
}
