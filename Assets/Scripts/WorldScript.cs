using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldScript : MonoBehaviour
{
    readonly float G = 6.6743f * (float)Math.Pow(10, -11);
    float deltaTime = 0.003f; 
    [SerializeField] private GameObject planetPrefab;
    private Vector3 planetPosition = new Vector3(0, 0, 20);
        
    public List<PlanetData> planets = new List<PlanetData>();
    // [SerializeField] private PlanetData planet;
    // [SerializeField] private PlanetData planet2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlanetData planet = Instantiate(planetPrefab, planetPosition, Quaternion.identity).GetComponent<PlanetData>();
            planet.mass = Random.Range(10, 60);
            planet.transform.localScale = new Vector3(planet.mass/10f, planet.mass/10f, planet.mass/10f);
            planet.velocity = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
            planets.Add(planet);    
        }
        // deltaTime = Time.deltaTime;
        updateAllPlanetVelocities();
        moveAllPlanets();
    }

    private void updateAllPlanetVelocities()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            for (int j = i+1; j < planets.Count; j++)
            {
                PlanetData planet = planets[i];
                PlanetData planet2 = planets[j];
                
                float force = calculateForce(planet, planet2);
                Vector3 direction = Vector3.Normalize(planet.transform.position - planet2.transform.position);
                Vector3 planetForce = force * -direction;
                Vector3 planet2Force = force * direction;
                
                planet.velocity += planetForce*deltaTime/planet.mass;
                planet2.velocity += planet2Force*deltaTime/planet2.mass;
            }
        }
    }

    void moveAllPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            movePlanet(planets[i]);
        }
    }

    void movePlanet(PlanetData planet)
    {
        planet.transform.position += planet.velocity*deltaTime;
    }

    float calculateForce(PlanetData planet, PlanetData planet2)
    {
        float distance = Vector3.Distance(planet.transform.position, planet2.transform.position);
        
        float mass1 = planet.mass;
        float mass2 = planet2.mass;
        float compensate = (float)Math.Pow(10, 9);
        
                
        float scale = (float)(G*(mass1*mass2*compensate)/Math.Pow(distance, 2));
        // Vector3 force = scale * direction;
        Debug.Log($"{scale}: {distance}");
        return scale;
    }
}
