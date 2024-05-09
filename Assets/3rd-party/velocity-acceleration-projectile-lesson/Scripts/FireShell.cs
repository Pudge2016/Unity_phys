using UnityEngine;

public class FireShell : MonoBehaviour
{

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    public Transform turretBase;
    float rotationSpeed = 2f;
    float speed = 15f;

    bool shouldMove = false;
    float moveSpeed = 5f;

    void CreateBullet()
    {
        GameObject shell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        shell.GetComponent<Rigidbody>().velocity = speed * turretBase.forward;
    }

    float? RotateTurret()
    {
        float? angle = CalculateAngle(true);

        if (angle is not null)
        {
            turretBase.localEulerAngles = new Vector3(360f - (float) angle, 0f, 0f);
        }

        return angle;
    }

    float? CalculateAngle(bool low)
    {
        Vector2 targetDir = enemy.transform.position - transform.position;
        float y = targetDir.y;

        targetDir.y = 0f;
        float x = targetDir.magnitude;
        float gravity = 9.8f;
        float sSqr = speed * speed;

        float underSquareRoot = sSqr * sSqr - gravity * ( gravity * x * x + 2 * y * sSqr );

        if (underSquareRoot >= 0f)
        {
            float root = Mathf.Sqrt(underSquareRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low)
            {
                return ( Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg );
            }

            return ( Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg );
        }

        return null;
    }

    void Update()
    {
        Vector3 direction = ( enemy.transform.position - transform.position ).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        float? angle = RotateTurret();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CreateBullet();
        }

        if (angle is null)
        {
            transform.Translate(0, 0, Time.deltaTime * moveSpeed);
        }
        else
        {
            CreateBullet();
        }
    }

}
