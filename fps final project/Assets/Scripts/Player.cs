using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Rigidbody rb;

    public GameObject shotgunShort;
    public GameObject pistol;
    public GameObject flameThrower;

    public GameObject cameraObject;
    public ParticleSystem psFlare;

    public float speed;
    public float turn;

    public int score;

    public TextMeshProUGUI txtScore;

    public static Player instance;

    public int weaponID;
    public float health = 100;
    public Image imageHealth;
    public AudioSource bang;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        psFlare = GetComponentInChildren<ParticleSystem>();
        bang = GetComponentInChildren<AudioSource>();
        speed = 7.5f;
        turn = 30f;
        cameraObject = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp;
        temp = (transform.right * Input.GetAxis("Horizontal") +
            transform.forward * Input.GetAxis("Vertical")) * speed;

        rb.velocity = temp;
        rb.angularVelocity = Vector3.up * Input.GetAxis("Mouse X") * turn;


        RaycastHit rHit;

        if (Input.GetButtonDown("Fire1"))
        {
            bang.pitch = Random.Range(0.5f, 2f);
            bang.Play();
            psFlare.Play();
            if (Physics.Raycast(transform.position, transform.forward, out rHit))
            {

                if (rHit.collider.gameObject.tag == "Enemy")
                    Destroy(rHit.collider.gameObject);
                score++;
            }
        }

       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weaponID < 2)
                weaponID++;
            else
                weaponID = 0;

                flameThrower.SetActive(weaponID==0);
                pistol.SetActive(weaponID==1);
                shotgunShort.SetActive(weaponID==2);

        }

        txtScore.text = "Score: " + score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1f;
            imageHealth.fillAmount = health / 100f;
            if (health <= 0)
                Debug.Log("GAME OVER");
        }
    }
}