using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float gravityMultiplier;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem expoParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool doubleJump=false;
    public bool dash = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim= GetComponent<Animator>();
        playerRb= GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            dash = true;
            playerAnim.SetFloat("Speed_Multiplier",2);
        }
        else if (dash)
        {
            dash= false;
            playerAnim.SetFloat("Speed_Multiplier", 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !gameOver && !isOnGround)
        {
            playerAudio.PlayOneShot(jumpSound, 1);
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            doubleJump = true;
            playerAnim.SetTrigger("Jump_trig");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isOnGround)
        {
            playerAudio.PlayOneShot(jumpSound,1);
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            {
                dirtParticle.Play();
                isOnGround = true;
                doubleJump = false;
            }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound,1);
            gameOver= true;
            Debug.Log("Game Over");
            /*playerAnim.SetTrigger("Death_b"); b�yle de oluyor. ChatGBT nin dedi�ine g�re �u*/
            //Yani temel fark, SetTrigger'�n bir ge�i�i tetikledi�i ve ilgili animasyonun oynat�lmas�n� ba�latt���,
            //SetBool'un ise bir bool de�i�kenini do�rudan ayarlad���d�r. Bu farka ba�l� olarak, SetTrigger daha �ok ge�i�lerin
            //tetiklenmesi ve animasyonlar�n oynat�lmas� i�in kullan�l�rken, SetBool daha �ok ge�i�lerin kontrol�nde kullan�lan bool de�i�kenlerini ayarlamak i�in kullan�l�r
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1); /*buradan da Animator>parameter daki deathtype_int i de�i�tiriyoruz. de�i�tirmek istersek tabi. de�i�tirmeden de default da ne varsa o �al���r*/
            expoParticle.Play();
            dirtParticle.Stop();

        }
    }
}
