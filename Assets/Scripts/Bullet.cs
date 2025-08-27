using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPooling poolOwner;

    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float strength;

    public void UseBullet()
    {
        //CancelInvoke();

        Invoke("ResetBullet", 5f);
        myRigidbody.AddForce(transform.forward * strength, ForceMode.Impulse);
    }

    public void InitializePooledBullet(BulletPooling owner)
    {
        poolOwner = owner;
        //Do anything else as initializing
    }

    private void ResetBullet()
    {
        myRigidbody.linearVelocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;

        //call ' BulletPooling.ReturnBullet(this); '
        poolOwner.ReturnBullet(this);

        gameObject.SetActive(false);
    }
}
