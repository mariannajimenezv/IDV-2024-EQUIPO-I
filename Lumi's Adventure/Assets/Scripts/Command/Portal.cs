using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

    [Header("Configuracion")]
    public Portal destinationPortal;
    public float teleportCooldown = 1f;

    [Header("Feedback")]
    public ParticleSystem teleportEffect;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canTeleport && destinationPortal != null)
        {
            ExecuteTeleport(other.gameObject);
        }
    }

    private void ExecuteTeleport(GameObject player)
    {
        canTeleport = false;
        if(destinationPortal != null)
        {
            destinationPortal.canTeleport = false;
        }

        if (teleportEffect != null) teleportEffect.Play();
        if (destinationPortal.teleportEffect != null)
            destinationPortal.teleportEffect.Play();

        ICommand teleportCommand = new CommandTeleport(
            player.transform,
            destinationPortal.transform.position
        );
        teleportCommand.Execute();

        StartCoroutine(ResetTeleport());
        if (destinationPortal != null)
        {
            destinationPortal.StartCoroutine(destinationPortal.ResetTeleport());
        }
    }

    private IEnumerator ResetTeleport()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    private void OnDrawGizmos()
    {
        if (destinationPortal != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, destinationPortal.transform.position);
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }
}
