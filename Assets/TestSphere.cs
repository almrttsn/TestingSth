using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphere : MonoBehaviour
{
    [SerializeField] List<GameObject> _spheres; //k�releri list i�ine ald�k.
    private float _senderTimeToWait = 1f;

    private void Start()
    {
        Debug.Log("Try to find capacity of list and move objects one by one");
        Debug.Log(_spheres.Count); //listenin kapasitesini yazd�rd�k.
        StartCoroutine(MoveSpheresForward()); //1'er saniye aral�klarla k�releri ileri ta��d�k.
    }

    private IEnumerator MoveSpheresForward()
    {
        for (int i = 0; i < _spheres.Count; i++)
        {
            _spheres[i].transform.position = _spheres[i].transform.position + new Vector3(0, 0, 5f);
            yield return new WaitForSeconds(_senderTimeToWait);
        }
    }


}
