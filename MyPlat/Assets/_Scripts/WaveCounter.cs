using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static int waveVal = 0;
    Text Wave;

    private void Start()
    {
        Wave = GetComponent<Text>();
    }

    private void Update()
    {
        Wave.text = "Ondate superate: " + waveVal/6;
    }
}
