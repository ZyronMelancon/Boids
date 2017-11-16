using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBehavior : MonoBehaviour {

    public float kCohesion;
    public float kDispersion;
    public float kAlignment;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 v1, v2, v3;

        foreach (Boid i in GetComponent<AgentFactory>().GetBoids())
        {
            v1 = Cohesion(i);
            v2 = Dispersion(i);
            v3 = Alignment(i);

            i.Add_Force(1, v1);
            i.Add_Force(1, v2);
            i.Add_Force(1, v3);

            i.Update_Agent(Time.deltaTime);
        }

        foreach (BoidBehavior f in GetComponent<AgentFactory>().GetBoidObjects())
            f.LateUpdate();
	}

    Vector3 Dispersion(Boid b)
    {
        Vector3 c = new Vector3();

        foreach (Boid i in GetComponent<AgentFactory>().GetBoids())
            if (i != b)
                if (Vector3.Magnitude(i.Position - b.Position) < 100)
                    c = c - (i.Position - b.Position);
        return c;
    }
    Vector3 Cohesion(Boid b)
    {
        Vector3 pcj = new Vector3();
        foreach (Boid i in GetComponent<AgentFactory>().GetBoids())
            if (i != b)
                pcj = pcj + i.Position;

        pcj = pcj / GetComponent<AgentFactory>().GetBoids().Count;

        return (pcj - b.Position) / 100;
    }
    Vector3 Alignment(Boid b)
    {
        Vector3 pv = new Vector3();

        foreach (Boid i in GetComponent<AgentFactory>().GetBoids())
            if (i != b)
                pv = pv + i.Velocity;

        pv = pv / GetComponent<AgentFactory>().GetBoids().Count;

        return (pv - b.Velocity) / 8;
    }
}
