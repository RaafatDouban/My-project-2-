using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody PlayerRB;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
     PlayerRB = GetComponent<Rigidbody>();
     playerAnim = GetComponent<Animator>();
     Physics.gravity *= gravityModifier;
    
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
     {
        playerAudio.PlayOneShot(jumpSound, 1.0f);
      PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
      playerAnim.SetTrigger("Jump_trig");
      dirtParticle.Stop();
     }
    }
    private void OnCollisionEnter(Collision collision){
        //if(collision.gameObject.CompareTag("Ground")){

            isOnGround = true;

            if(collision.gameObject.CompareTag("Ground")){
                isOnGround = true;
                dirtParticle.Play();
            }
            else if(collision.gameObject.CompareTag("Obstacle")){
                dirtParticle.Stop();
                explosionParticle.Play();
                Debug.Log("Game Over!");
                gameOver = true;
                playerAudio.PlayOneShot(crashSound, 1.0f);
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                
            }
       // }
    }
}
