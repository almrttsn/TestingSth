using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubes : MonoBehaviour
{
    [SerializeField] GameObject[] cubes; //k�pleri array i�ine ald�k.
    private float waitTimer = 1f;


    private void Start()
    {
        Debug.Log("Trying to find specific cubes");
        Debug.Log(cubes[2].name.ToString()); //istedi�imiz s�radaki objenin ismini yazd�rd�k.
        StartCoroutine(StartCubesDeactivateProcess());
    }

    private IEnumerator StartCubesDeactivateProcess()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].activeInHierarchy == true)
            {
                cubes[i].SetActive(false);
                yield return new WaitForSeconds(waitTimer); //1'er saniye aral�klarla objeleri deaktif ettik.
            }
        }


            
    }
}
