using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubes : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject[] _cubes;                       //küpleri array içine aldýk.
    private float _waitTimer = 1f;
    public bool ActivateCubesOrderSent;


    private void Start()
    {
        Debug.Log("Trying to find specific cube");
        Debug.Log(_cubes[2].name.ToString());                   //istediðimiz sýradaki küpün ismini yazdýrdýk.
        StartCoroutine(StartCubesDeactivateProcess());          //1'er saniye aralýklarla küpleri deaktif ettik.
    }

    private IEnumerator StartCubesDeactivateProcess()           //1'er saniye aralýklarla küpleri deaktif ettik.
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            if (_cubes[i].activeInHierarchy == true)    
            {
                _cubes[i].SetActive(false);
                yield return new WaitForSeconds(_waitTimer); 
            }
        }
        ActivateCubes();                                        //küpleri tekrar aktif ettik.
        DeactiveSpheresOrderSent();                             //küreleri deaktif etme emrini gönder.
    }

    public void ActivateCubes()                                 //aktive etme yöntemi.
    {
        if(ActivateCubesOrderSent == true)                      //Game Manager'dan emir geldi. Emri veren TestSpheres
            for (int i = 0; i<_cubes.Length; i++)
            {
                _cubes[i].SetActive(true);
            }
    }

    public void DeactiveSpheresOrderSent()                      //gönderilen emirin içeriði.
    {
        _gameManager.TestSpheres.DeactivateSpheresOrderSent = true;
    }
}
