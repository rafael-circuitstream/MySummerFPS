using UnityEngine;
using System.Collections.Generic;
public class BulletPooling : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private List<Bullet> availableBullets = new List<Bullet>();
    [SerializeField] private List<Bullet> unavailableBullets = new List<Bullet>();
    
    void Awake()
    {
        for(int index = 0; index < 20; index++)
        {
            CreatePooledBullet();
        }
    }

    private void CreatePooledBullet()
    {
        Bullet bulletClone = Instantiate(bulletPrefab, transform);

        bulletClone.InitializePooledBullet(this);

        bulletClone.gameObject.name = availableBullets.Count.ToString();
        availableBullets.Add(bulletClone);
        bulletClone.gameObject.SetActive(false);
    }

    public Bullet GetAvailableBullet()
    {
        //No available bullets in the list
        if (availableBullets.Count == 0)
        {
            CreatePooledBullet();
        }

        Bullet firstAvailableBullet = availableBullets[0];

        availableBullets.RemoveAt(0);
        unavailableBullets.Add(firstAvailableBullet);

        return firstAvailableBullet;
    }

    public void ReturnBullet(Bullet usedBullet)
    {
        unavailableBullets.Remove(usedBullet);
        availableBullets.Add(usedBullet);
    }
}
