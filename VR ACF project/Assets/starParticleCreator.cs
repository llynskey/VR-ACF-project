using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starParticleCreator : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public int maxNumberOfParticles = 100;
    public TextAsset starCSV;


    // Use this for initialization
    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.maxParticles = maxNumberOfParticles;
        ParticleSystem.Burst[] burst = new ParticleSystem.Burst[1];
        burst[0].minCount = (short)maxNumberOfParticles;
        burst[0].maxCount = (short)maxNumberOfParticles;
        burst[0].time = 0.0f;
        particleSystem.emission.SetBursts(burst, 1);
    }

   void Start()
    {
        Invoke("Create", 1);
    }

    // Update is called once per frame
    void Create()
    {
        print("enable");
        string[] lines = starCSV.text.Split('\n');

        ParticleSystem.Particle[] particleStars = new ParticleSystem.Particle[maxNumberOfParticles];
        particleSystem.GetParticles(particleStars);

        for (int i = 0; i < maxNumberOfParticles; i++)
        {
            string[] components = lines[i].Split(',');

            particleStars[i].position = new Vector3(
                float.Parse(components[1]),
                float.Parse(components[2]),
                float.Parse(components[3]));

            particleStars[i].remainingLifetime = Mathf.Infinity;
        }
        particleSystem.SetParticles(particleStars, maxNumberOfParticles);

    }

   /* IEnumerator Start()
    {
        yield return StartCoroutine("Create");
    } */
}
