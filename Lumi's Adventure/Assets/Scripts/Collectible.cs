using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum Type { Fragment, Heart, Exit }
    public Type objectType;

    [Header("Solo para Corazones")]
    public int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectType == Type.Fragment)
            {
                GameManager.Instance.CollectFragment();
                Destroy(gameObject);
            }
            else if (objectType == Type.Heart)
            {
                other.GetComponent<LumiController>().Heal(healAmount);
                Destroy(gameObject);
            }
            else if (objectType == Type.Exit)
            {
                GameManager.Instance.WinLevel();
            }
        }
    }
}
