using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class STMInput : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private GameObject saltBottle;
    [SerializeField] private ParticleSystem Salt;
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private Animator animator;

    private int Points;
    private bool Left, Right;
    private bool done;
    private float leftProgress;
    private float rightProgress;
    private Vector3 startPos;
    private Vector3 bottlePos;

    private float LastInputDelta, Delta;

    private IEnumerator Move()
    {
        for (int i = 0; i < 100; ++i)
        {
            yield return new WaitForEndOfFrame();
            saltBottle.transform.localPosition = Vector3.MoveTowards(saltBottle.transform.localPosition, new Vector3(-5f, 2f, 0), 0.02f);
        }
        for (int i = 0; i < 100; ++i)
        {
            yield return new WaitForEndOfFrame();
            saltBottle.transform.localPosition = Vector3.MoveTowards(saltBottle.transform.localPosition, new Vector3(1.47f, 1.32f, 0), 0.02f);
        }
        if (!done)
            StartCoroutine(Move());
    }

    private void OnLeftTrigger(InputAction.CallbackContext context)
    {
        leftProgress = context.ReadValue<float>();

        if (context.performed && !Left && !done)
        {

            Left = true;
            Right = false;
            Points += 1;
            LastInputDelta = Delta;
            Salt.Play();
        }
    }

    private void OnRightTrigger(InputAction.CallbackContext context)
    {
        rightProgress = context.ReadValue<float>();

        if (context.performed && !Right && !done)
        {
            Right = true;
            Left = false;
            Points += 1;
            LastInputDelta = Delta;
            Salt.Play();
        }
    }

    private void Start()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnLeftTrigger += OnLeftTrigger;
            PlayerInputCenter.PlayerInputEvents[m_player].OnRightTrigger += OnRightTrigger;
        }

        //StartCoroutine(Move());
        
        Left = false;
        Right = true;
        startPos = saltBottle.transform.position;
        Salt.Stop();

    }

    private void Update()
    {

        float progress = 1;
        if (!done)
        {
            progress -= leftProgress;
            progress += rightProgress;
        }

        Vector3 newPos = Vector3.zero;
        newPos.x = moveCurve.Evaluate(progress / 3) * 1.5f;
        bottlePos = startPos + newPos;

        saltBottle.transform.position = Vector3.Lerp(saltBottle.transform.position, bottlePos, Time.deltaTime * 15f);

        if (Points == 120 && !done)
        {
            done = true;
            animator.SetTrigger("Done");
            MiniGameManager.SetPlayerDone(m_player);
        }

        Delta += Time.deltaTime;

        if (Delta - LastInputDelta > .5f)
        {
            Salt.Stop(); 
        }
    }

    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnLeftTrigger -= OnLeftTrigger;
            PlayerInputCenter.PlayerInputEvents[m_player].OnRightTrigger -= OnRightTrigger;
        }
    }
}
