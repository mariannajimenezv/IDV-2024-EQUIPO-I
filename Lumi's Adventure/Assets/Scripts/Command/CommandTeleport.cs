using UnityEngine;


public class CommandTeleport : ICommand
{
    private Transform target;
    private Vector3 destination;
    private Rigidbody rb;
    private Vector3 velocity;


    public CommandTeleport(Transform target, Vector3 destination)
    {
        this.target = target;
        this.destination = destination;
        this.rb = target.GetComponent<Rigidbody>();

        if(rb != null)
        {
            velocity = rb.linearVelocity;
        }
    }

    public void Execute()
    {
        target.position = destination;

        if(rb != null)
        {
            rb.linearVelocity = velocity;
        }

        ServiceLocator.Get<IAudioService>()?.PlaySound("Teleport");

        Debug.Log($"Teletransportando a {destination}");
    }

    public void Undo()
    {

    }
}
