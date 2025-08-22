using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float strength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy(gameObject, 5f);
        Invoke("ResetBullet", 5f);
        myRigidbody.AddForce(transform.forward * strength, ForceMode.Impulse);
    }

    private void ResetBullet()
    {
        myRigidbody.linearVelocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;

        //call ' BulletPooling.ReturnBullet(this); '

        gameObject.SetActive(false);
    }
}
