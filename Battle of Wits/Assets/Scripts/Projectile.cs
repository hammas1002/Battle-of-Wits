using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;
    public Vector3 pos, velocity;
    float angle;
    private BattleSystem _battleSystem;
    public GameObject particleSystem;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        _battleSystem = FindObjectOfType<BattleSystem>();
        Invoke("activateCollider",0.3f);
    }
    void Awake()
    {
        pos = transform.position;
    }

    void activateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
    void Update()
    {
         transform.Translate(Vector2.up * speed * Time.deltaTime);
        velocity = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
       Instantiate(particleSystem,transform.position,Quaternion.identity);
        
        if (collision.collider.name == "shield")
        {
            Vector3 normal = collision.contacts[0].normal;
            Debug.Log("velocity"+velocity);

            Vector3 vel = velocity.y != 0 ? -velocity : velocity;     
            Debug.Log("vel" + vel);
            angle =Vector3.Angle(vel, -normal);
            Shield _shield = collision.collider.transform.parent.transform.parent.GetComponent<Shield>();
            //need to inverse angle after each rotation.
            angle = _shield.isAngleShift() ? -angle : angle;
            
            transform.RotateAround(transform.position, Vector3.forward, angle * 2);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="GFX1")
        {   //player 2 won
            Debug.Log("Player 2 Won");
            _battleSystem.setWinner("Player 2");
            

        }
        else if(collision.name == "GFX2")
        {
            //player 1 won
            Debug.Log("Player 1 Won");
            _battleSystem.setWinner("Player 1");
        }
    }


}
