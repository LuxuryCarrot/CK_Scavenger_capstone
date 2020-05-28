using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnIsntance : MonoBehaviour
{
    public GameObject floor;
    public GameObject wall;
    public GameObject OutFloor;
    public GameObject wallpaper;

    public GameObject[] stuffs;
    public GameObject[] pins;

    private void Awake()
    {
        for (int i = -10; i < -2; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject floorBlock
                    = GameObject.Instantiate(OutFloor, new Vector3(i * 1.8f, 0, j * 1.8f), Quaternion.identity);

                floorBlock.transform.SetParent(this.transform);
                floorBlock.transform.localScale = new Vector3(2, 2, 2);
            }
        }

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
                    = GameObject.Instantiate(stuffs[randomSeed], new Vector3(i * 1.8f, Random.Range(-0.1f,0), -1.4f), Quaternion.Euler(-90,0,0));
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
                        , new Vector3(i * 1.8f+(k*0.6f), 0.5f+ruinedStuff.transform.position.y+ Random.Range(-0.5f, 0), -1.7f)
                        ,Quaternion.identity);
                    newPin.transform.Rotate(90, 0, 0);
                    newPin.transform.Rotate(0, Random.Range(0, 270), 0);
                    newPin.transform.SetParent(ruinedStuff.transform);
                    newPin.transform.localScale=new Vector3 (0.7f, 0.7f, 0.7f);
                }
                
            }
            for(int j=0; j<6; j++)
            {

                GameObject floorBlock
                    = GameObject.Instantiate(floor, new Vector3(i*1.8f, 0, j*1.8f), Quaternion.identity);

                GameObject bedRock =
                    GameObject.Instantiate(floor, new Vector3(i * 1.8f, -2.0f, j * 1.8f), Quaternion.identity);

                floorBlock.transform.SetParent(this.transform);
                floorBlock.transform.localScale = new Vector3(2, 2, 2);

                bedRock.transform.SetParent(this.transform);
                bedRock.transform.localScale = new Vector3(2, 2, 2);
            }
        }
        for (int i = -2; i < 100; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject floorBlock
                    = GameObject.Instantiate(floor, new Vector3(i * 1.8f, 16, j * 1.8f), Quaternion.identity);

                floorBlock.transform.SetParent(this.transform);
                floorBlock.transform.localScale = new Vector3(2, 2, 2);

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
                        = GameObject.Instantiate(stuffs[randomSeed], new Vector3(i * 1.8f, 8+ Random.Range(-0.1f, 0), -1.4f), Quaternion.Euler(-90, 0, 0));
                    ruinedStuff.transform.SetParent(this.transform);
                    ruinedStuff.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);

                    for (int k = 0; k < 3; k++)
                    {
                        GameObject newPin =
                         GameObject.Instantiate(pins[(int)Random.Range(0, pins.Length - 1)]
                            , new Vector3(i * 1.8f + (k * 0.6f), 0.5f + ruinedStuff.transform.position.y + Random.Range(-0.5f, 0), -1.7f)
                            , Quaternion.identity);
                        newPin.transform.Rotate(90, 0, 0);
                        newPin.transform.Rotate(0, Random.Range(0, 360), 0);
                        newPin.transform.SetParent(ruinedStuff.transform);
                        newPin.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                }

                for (int j = -1; j < 6; j++)
                {
                    if (i >= 3 && i <= 5)
                        break;

                    GameObject floorBlock
                        = GameObject.Instantiate(floor, new Vector3(i * 1.8f, 8, j * 1.8f), Quaternion.identity);

                    floorBlock.transform.SetParent(this.transform);
                    floorBlock.transform.localScale = new Vector3(2, 2, 2);
                }
            }
            else
            {
                for (int j = 3; j < 6; j++)
                {
                    

                    GameObject floorBlock
                        = GameObject.Instantiate(floor, new Vector3(i * 1.8f, 8, j * 1.8f), Quaternion.identity);

                    floorBlock.transform.SetParent(this.transform);
                    floorBlock.transform.localScale = new Vector3(2, 2, 2);
                }
            }
        }
        for (int i = -4; i < 200; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == 18 && (j == 0 || j == 1))
                { }
                else
                {
                    GameObject floorBlock
                        = GameObject.Instantiate(wall, new Vector3(i * 2, j * 2, 7.0f), Quaternion.identity);

                    floorBlock.transform.SetParent(this.transform);
                    floorBlock.transform.localScale = new Vector3(2, 2, 2);
                }
            }
        }

        for (int i = -4; i < 200; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject floorBlock
                    = GameObject.Instantiate(wall, new Vector3(i, j * 2+8, 7.0f), Quaternion.identity);

                floorBlock.transform.SetParent(this.transform);
                floorBlock.transform.localScale = new Vector3(2, 2, 2);
            }
        }

        for (int i=0; i<25; i++)
        {
            for(int j=0; j<2; j++)
            {
                if (i == 4)
                { }
                else
                {
                    GameObject wallpap
                        = GameObject.Instantiate(wallpaper, new Vector3(i * 10, j * 10 + 3, 5.9f), Quaternion.identity);

                    wallpap.transform.rotation = Quaternion.Euler(-90, 0, 0);

                    wallpap.transform.SetParent(this.transform);
                }
               
            }
        }
        transform.position -= new Vector3(20, 0, 0);
    }
}
