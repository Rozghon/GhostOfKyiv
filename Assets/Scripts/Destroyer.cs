using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _timer;

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(_timer);
        GameObject.Destroy(this.gameObject);
    }
}
