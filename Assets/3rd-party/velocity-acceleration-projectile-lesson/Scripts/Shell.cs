using UnityEngine;

public class Shell : MonoBehaviour
{

    public GameObject explosion;
    float speed = 0f;
    float ySpeed = 0f;
    float mass = 10;
    float force = 2;
    float drag = 1;
    float gravity = -9.8f;
    float acceleration;
    float gAccel;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank" || col.gameObject.tag == "ground")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        acceleration = force / mass;
        speed += acceleration;

        gAccel = gravity / mass;

    }

    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        ySpeed += gAccel * Time.deltaTime;
        this.transform.Translate(0, ySpeed, speed);
    }
}
