using UnityEngine;

public class SkillFireBender : MonoBehaviour
{
    [SerializeField] GameObject fireBallPrefab; // Préfabriqué de la boule de feu
    [SerializeField] Transform firePoint; // Point de départ du tir de la boule de feu
    [SerializeField] float fireBallSpeed = 1f; // Vitesse de la boule de feu

    public void Fire()
    {
        GameObject newObject = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation, null);

        if (newObject.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody);
        }
    }

    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = firePoint.forward * fireBallSpeed;
        rigidBody.AddForce(force);
    }
}
