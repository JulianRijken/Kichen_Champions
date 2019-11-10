using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeHole : MonoBehaviour
{
    [SerializeField] private GameObject tape;
    [SerializeField] private ParticleSystem water;
    public bool isFixed;

    private void Start()
    {
        tape.gameObject.SetActive(false);
        isFixed = false;
    }

    private void OnEnable()
    {
        water.Play();
    }

    public void Fix()
    {
        water.Stop();
        tape.gameObject.SetActive(true);
        isFixed = true;
    }
}
