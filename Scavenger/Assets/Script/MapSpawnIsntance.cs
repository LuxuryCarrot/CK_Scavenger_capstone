using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnIsntance : MonoBehaviour
{

    public GameObject[] stuffs;
    public GameObject[] pins;

    private void Awake()
    {
        

        int randomSeed = 0;

        for (int i=-2; i<100; i++)
        {
            if (stuffs.Length != 0)
            {
                int newrand = (int)Random.Range(0, stuffs.Length - 1);
                for(;newrand==randomSeed;)
                {
                    newrand = (int)Random.Range(0, stuffs.Length - 1);
                }
                randomSeed = newrand;
                GameObject ruinedStuff 
                    = GameObject.Instantiate(stuffs[randomSeed], new Vector3(-20.0f+i * 1.8f, Random.Range(-0.1f,0), -1.4f), Quaternion.Euler(-90,0,0));
                if(randomSeed==1)
                {
                    ruinedStuff.transform.position += new Vector3(0, 0, -0.2f);
                }
                ruinedStuff.transform.SetParent(this.transform);
                ruinedStuff.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
               


                for (int k=0; k<3; k++)
                {
                    GameObject newPin =
                     GameObject.Instantiate(pins[(int)Random.Range(0, pins.Length - 1)]
                        , new Vector3(-20.0f + i * 1.8f+(k*0.6f), 0.5f+ruinedStuff.transform.position.y+ Random.Range(-0.3f, 0), -1.7f)
                        ,Quaternion.identity);
                    newPin.transform.Rotate(90, 0, 0);
                    newPin.transform.Rotate(0, Random.Range(0, 270), 0);
                    newPin.transform.SetParent(ruinedStuff.transform);
                    newPin.transform.localScale=new Vector3 (0.7f, 0.7f, 0.7f);
                }
                
            }
            
        }
        
        for (int i = -3; i < 100; i++)
        {
            if ( ( i < 20 || i >= 27)&& i!=10 && i!=9)
            {
                if (stuffs.Length != 0)
                {
                    int newrand = (int)Random.Range(0, stuffs.Length - 1);
                    for (; newrand == randomSeed;)
                    {
                        newrand = (int)Random.Range(0, stuffs.Length - 1);
                    }
                    randomSeed = newrand;
                    GameObject ruinedStuff
                        = GameObject.Instantiate(stuffs[randomSeed], new Vector3(-20.0f + i * 1.8f, 8+ Random.Range(-0.1f, 0), -1.4f), Quaternion.Euler(-90, 0, 0));
                    ruinedStuff.transform.SetParent(this.transform);
                    ruinedStuff.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);

                    for (int k = 0; k < 3; k++)
                    {
                        GameObject newPin =
                         GameObject.Instantiate(pins[(int)Random.Range(0, pins.Length - 1)]
                            , new Vector3(-20.0f + i * 1.8f + (k * 0.6f), 0.5f + ruinedStuff.transform.position.y + Random.Range(-0.5f, 0), -1.7f)
                            , Quaternion.identity);
                        newPin.transform.Rotate(90, 0, 0);
                        newPin.transform.Rotate(0, Random.Range(0, 360), 0);
                        newPin.transform.SetParent(ruinedStuff.transform);
                        newPin.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                }

                
            }
            
        }
        

        
        
    }
}
