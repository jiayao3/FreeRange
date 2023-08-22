using System.Collections.ObjectModel;
using System.Net;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRipple : MonoBehaviour
{
    private int waveNumber = 1;
    private float[] waveAmplitude = new float[2];
    private Vector2[] impactPos = new Vector2[2];
    private float[] distance = new float[2];
    private float speedWaveSpread = 0.1f;

    [SerializeField] GameObject otherPlane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++) {
            waveAmplitude[i] = GetComponent<Renderer>().material.GetFloat("_CharacterWaveAmplitude" + (i + 1));
            if (waveAmplitude[i] > 0) {
                distance[i] += speedWaveSpread;
                // Decrease wave size by 1% each frame
                GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + (i + 1), waveAmplitude[i] * 0.99f);
                GetComponent<Renderer>().material.SetFloat("_Distance" + (i + 1), distance[i]);
                // Apply changes to the other plane
                otherPlane.GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + (i + 1), waveAmplitude[i] * 0.99f);
                otherPlane.GetComponent<Renderer>().material.SetFloat("_Distance" + (i + 1), distance[i]);
            }
            if (waveAmplitude[i] < 0.01) {
                distance[i] = 0;
                GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + (i + 1), 0);
                otherPlane.GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + (i + 1), 0);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<Rigidbody>()) {
            waveNumber++;
            if (waveNumber == 3) {
                waveNumber = 1;
            }
            waveAmplitude[waveNumber - 1] = 0;
            distance[waveNumber - 1] = 0;
            impactPos[waveNumber - 1].x = other.transform.position.x;
            impactPos[waveNumber - 1].y = other.transform.position.z;

            float amplitude = GetComponent<Renderer>().material.GetFloat("_RippleAmplitude");

            GetComponent<Renderer>().material.SetFloat("_ImpactX" + waveNumber, impactPos[waveNumber - 1].x);
            GetComponent<Renderer>().material.SetFloat("_ImpactZ" + waveNumber, impactPos[waveNumber - 1].y);
            GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + waveNumber, amplitude);

            otherPlane.GetComponent<Renderer>().material.SetFloat("_ImpactX" + waveNumber, impactPos[waveNumber - 1].x);
            otherPlane.GetComponent<Renderer>().material.SetFloat("_ImpactZ" + waveNumber, impactPos[waveNumber - 1].y);
            otherPlane.GetComponent<Renderer>().material.SetFloat("_CharacterWaveAmplitude" + waveNumber, amplitude);
        }
    }   
}
