using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : ScriptableObject
{
    [SerializeField]
    protected float mass;
    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 acceleration;
    [SerializeField]
    protected Vector3 force;
    [SerializeField]
    protected float max_speed;

    public virtual void Initialize() { }
    public Vector3 Velocity { get; set; }
    public Vector3 Position;
}

public class Boid : Agent, IMoveable
{
    public override void Initialize()
    {
        mass = 5;
        velocity = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        acceleration = new Vector3(Random.Range(-2,2), Random.Range(-2, 2), Random.Range(-2, 2));
        force = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        max_speed = 50;
    }

    public Vector3 Update_Agent(float dt)
    {
        acceleration = force / mass;
        velocity += acceleration;
        velocity = Vector3.ClampMagnitude(velocity, max_speed);
        Position += velocity * dt;

        return Position;
    }
    public bool Add_Force(float f, Vector3 dir)
    {
        velocity += dir * f;
        return true;
    }
}

public interface IMoveable
{
    Vector3 Update_Agent(float dt);
    bool Add_Force(float f, Vector3 v);
}