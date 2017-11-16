using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFactory : MonoBehaviour {

    public int Amount = 10;
    [SerializeField]
    static List<Agent> agents;
    static List<BoidBehavior> boidObjects;

	// Use this for initialization
	void Start ()
    {
        agents = new List<Agent>();
        boidObjects = new List<BoidBehavior>();
        Create(Amount);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void Create(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var go = new GameObject();
            var bb = go.AddComponent(typeof(BoidBehavior));
            var boid = ScriptableObject.CreateInstance<Boid>();
            boid.Initialize();
            boid.Position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            bb.GetComponent<BoidBehavior>().SetMoveable(boid);
            agents.Add(boid);
            boidObjects.Add(bb.GetComponent<BoidBehavior>());
        }
    }

    public List<Boid> GetBoids()
    {
        List<Boid> result = new List<Boid>();
        foreach (Boid i in agents)
            result.Add(i);
        return result;
    }

    public List<BoidBehavior> GetBoidObjects()
    {
        return boidObjects;
    }
}
