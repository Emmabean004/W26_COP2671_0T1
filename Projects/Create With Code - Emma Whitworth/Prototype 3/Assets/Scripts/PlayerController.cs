using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem dirtParticle;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool gameOver = false;
    private Animator playerAnim; // Changed from Animation to Animator
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>(); // Changed from Animation to Animator
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig"); // Animator supports SetTrigger
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
        }
    }
}
