using UnityEngine;

public abstract class GenericPooledObject : MonoBehaviour
{
    public BulletPooling poolOwner;

    public abstract void InitPooledObject();
    public abstract void ResetPooledObject();
}
