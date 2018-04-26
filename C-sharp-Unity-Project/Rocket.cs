using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rocket : MonoBehaviour {

    // gets design levers
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineSys;
    [SerializeField] ParticleSystem successSys;
    [SerializeField] ParticleSystem deathSys;


    // gets needed parts
    Rigidbody rigidBody;
    AudioSource audioSource;

    // sets game status
    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    bool collisionsDisabled = true;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()

    {

        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
        if (Debug.isDebugBuild)
        {
          DebugKeys();
            print("Debug is on");
        }
        else if (!Debug.isDebugBuild)
        {
            print("Debug is not on");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || !collisionsDisabled) { return; } // ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "Finished":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successSys.Play();
        Invoke("LoadNextLevel", levelLoadDelay); // parameterise time
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        deathSys.Play();
        Invoke("LoadFirstLevel", levelLoadDelay); // parameterise time
    }

    private void LoadNextLevel()
    {
        SendMessage("LoadLevel");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex); // todo allow for more than 2 levels
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void RespondToThrustInput()
    {
        /* if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
         {
             ApplyThrust();
         }
         else
         {
             audioSource.Stop();
             mainEngineSys.Stop();
         }
         */
        if (CrossPlatformInputManager.GetAxis("Thrust") >= Mathf.Epsilon)
        {
            ApplyThrust();
        }
        else
        {
            StopApplyingThrust();
        }
    }

    private void StopApplyingThrust()
    {
        audioSource.Stop();
        mainEngineSys.Stop();
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying) // so it doesn't layer
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainEngineSys.Play();
    }

    private void RespondToRotateInput()
    {
        /* rigidBody.angularVelocity = Vector3.zero; // re,oves rotation due to physics

         float rotationThisFrame = rcsThrust * Time.deltaTime;
         if (Input.GetKey(KeyCode.A))
         {
             transform.Rotate(Vector3.forward * rotationThisFrame);
         }
         else if (Input.GetKey(KeyCode.D))
         {
             transform.Rotate(-Vector3.forward * rotationThisFrame);
         }
         */
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {
            // Rotation um die Z-Achse (Forward)
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
       // rigidBody.constraints = rigidbodyConstraints;

    }
}
