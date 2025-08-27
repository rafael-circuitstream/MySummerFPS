using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    //[SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private BulletPooling poolOfBullets;


    public void Shoot()
    {
        Bullet newBullet = poolOfBullets.GetAvailableBullet();

        //Didn't find available bullet from the pool
        if(newBullet == null)
        {
            return;
        }

        newBullet.transform.position = weaponTip.position;
        newBullet.transform.rotation = weaponTip.rotation;
        newBullet.gameObject.SetActive(true);
        newBullet.UseBullet();
    }
}
