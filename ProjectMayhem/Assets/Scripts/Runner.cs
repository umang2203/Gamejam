using UnityEngine;
using System.Collections;

enum RunnerState
{
    Running,
    Jumping,
    Dieing,
    Dead,
    Idel
}

public class Runner : MonoBehaviour {

    Animator            _animator;
    RunnerState         _state;

    public float        runningSpeed = 1f;
    public float        jumpDistance = 1f;
    private Vector3     _direction;

    public GameObject camera;
	
	void Start () 
    {
        _state = RunnerState.Idel;
        _animator = GetComponent<Animator>();
        _direction = new Vector3(1f,0,0);
        Run();
	}
	
    void Update()
    {
        if(_state == RunnerState.Running || _state == RunnerState.Jumping)
        {
            transform.Translate(_direction * runningSpeed);
//            camera.transform.Translate(_direction * runningSpeed);
        }
    }

    public void Jump()
    {
        if(_state == RunnerState.Running)
         _animator.SetTrigger("Jump");
    }

    public void Run()
    {
        if(_state != RunnerState.Running)
            _animator.SetTrigger("Run");
    }

    public void Hit()
    { 
        _animator.SetTrigger("Die");
    }
        


    //Animation Trigger callbacks
    public void OnJump_Started()
    {
        Debug.Log("Jumping");
        _state = RunnerState.Jumping;
        _direction = new Vector3(2f, jumpDistance, 0f);
    }
    public void OnJump_Halfway()
    {
        _direction = new Vector3(2f, -jumpDistance, 0f);
    }
    public void OnRun_Started()
    {
        if(_state != RunnerState.Running)
        {
            Debug.Log("Running");
            _state = RunnerState.Running;
            _direction = new Vector3(1f,0f,0f);
            transform.localPosition = new Vector3(transform.localPosition.x, 0f, 0f);
//            camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, 0f, -10f);
        }
    }
    public void OnDieing_Started()
    {
        if(_state == RunnerState.Running)
        {
            Debug.Log("Dieing");
            _state = RunnerState.Dieing;
        }
    }
  
    public void OnDead_Started()
    {
        if(_state == RunnerState.Dieing)
        {
            Debug.Log("Dead");
            _state = RunnerState.Dead;
        }
    }

}
