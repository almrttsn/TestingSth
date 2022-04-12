using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubes : MonoBehaviour
{
    [SerializeField] GameObject[] _cubes; //küpleri array içine aldýk.
    private float _waitTimer = 1f;


    private void Start()
    {
        Debug.Log("Trying to find specific cubes");
        Debug.Log(_cubes[2].name.ToString()); //istediðimiz sýradaki küpün ismini yazdýrdýk.
        StartCoroutine(StartCubesDeactivateProcess()); //1'er saniye aralýklarla küpleri deaktif ettik.
    }

    private IEnumerator StartCubesDeactivateProcess()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            if (_cubes[i].activeInHierarchy == true)
            {
                _cubes[i].SetActive(false);
                yield return new WaitForSeconds(_waitTimer); 
            }
        }


            
    }
}
