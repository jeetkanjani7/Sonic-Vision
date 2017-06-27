using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjects : MonoBehaviour
{
    public GameObject start;
    private float timer = 0;

    private float timerMax = 0;
    public static int cnt = 0;

    public GameObject sphere1,sphere2, cylinder2, cylinder1, bike, tree;
    public static List<GameObject> objs = new List<GameObject>();
    
    void Start()
    {



        Vector3 rndPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        
        objs.Add(sphere1);
        objs.Add(cylinder2);
        
        objs.Add(bike);
        objs.Add(tree);
        objs.Add(sphere2);
        objs.Add(cylinder1);



    }

    public static void appstart()
    {
        objs[cnt].SetActive(true);
        objs[cnt].GetComponent<AudioSource>().Play();
        cnt++;
        for (int i = 1; i <= objs.Count - 1; i++)
        {
            objs[i].SetActive(false);
        }
    }

    public void objectinit()
    {
        StartCoroutine(selectRandom());
    }

    public IEnumerator selectRandom()
    {


        int len = objs.Count;
       
     
        if (cnt < objs.Count)
        {
            yield return new WaitForSeconds(3);
            objs[cnt].SetActive(true);
            objs[cnt].GetComponent<AudioSource>().Play();
            cnt++;
        }
        else
        {
            GameObject cam = GameObject.Find("HoloLensCamera");
            cam.GetComponent<AudioSource>().Play();
            cnt = 0;
            
            start.SetActive(true);
        }

    }
    /*
    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }

    IEnumerator Example()
    {

        yield return new WaitForSeconds(3);

    }
    */
}
