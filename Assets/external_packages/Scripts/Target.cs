using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    // Start is called before the first frame update
    public void takeDamage(float amount){
        health -= amount;
        if(health <= 0){
            die();
        }
    }

    public void die(){
        Destroy(gameObject);
    }
}
