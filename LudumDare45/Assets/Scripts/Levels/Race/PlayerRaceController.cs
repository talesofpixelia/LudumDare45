﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for Player controller in race level
/// </summary>
public class PlayerRaceController : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Field for rigidbody
    /// </summary>
    private Rigidbody2D rgbd;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Gets or sets the speed of the player
    /// </summary>
    public float Speed;

    /// <summary>
    /// Gets or sets the possible movement area of the player
    /// </summary>
    public PlayerMovementArea PossibleMovement;

    #endregion Properties

    #region Functions

    #region Unity system

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Awake()
    {
        this.rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame for display purpose
    /// </summary>
    private void Update()
    {
        // Retrieve user inputs
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Apply the movement within the player movement area
        this.rgbd.position = new Vector2
        (
            Mathf.Clamp(this.rgbd.position.x + (moveHorizontal * this.Speed), this.PossibleMovement.X.Minimum, this.PossibleMovement.X.Maximum),
            Mathf.Clamp(this.rgbd.position.y + (moveVertical * this.Speed), this.PossibleMovement.Y.Minimum, this.PossibleMovement.Y.Maximum)
        );
    }

    /// <summary>
    /// Occurs on collision
    /// </summary>
    /// <param name="col">Collider in collision</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //freeze the player
            this.enabled = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    #endregion Unity system

    #endregion Functions
}
