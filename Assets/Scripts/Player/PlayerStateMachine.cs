using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine
{
    private List<BaseState> _states;
    public BaseState _currentState;
    
    public PlayerStateMachine()
    {
        _states = new List<BaseState>();
        _currentState = _states[0];
        _currentState.Enter();
    }
    public void ChangeState<T>() where T : BaseState
    {
        BaseState state = _states.FirstOrDefault(state => state is T);
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
    public void Update()
    {
        _currentState.Update();
    }
    private void InitializeStates()
    {
    }
}
