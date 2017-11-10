using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent
{
    protected float mass;
    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 force;
    protected float max_speed;

    public Vector3 Velocity { get; set; }
    public Vector3 Position;
}

public class Boid : Agent
{
    void Update_Agent(float dt)
    {
        acceleration = force / mass;
        velocity += acceleration;
        velocity = Vector3.ClampMagnitude(velocity, max_speed);
        Position += velocity * dt;
    }
    void Add_Force(float f, Vector3 dir)
    {
        velocity += dir * f;
    }
}