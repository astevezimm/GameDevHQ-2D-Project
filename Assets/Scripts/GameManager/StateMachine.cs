using System;
using System.Collections.Generic;

public class StateMachine
{
    private IState _currentState;

    private readonly Dictionary<IState, List<StateTransition>> _transitions =
        new Dictionary<IState, List<StateTransition>>();

    public void AddTransition(IState from, IState to, Func<bool> condition)
    {
        if (!_transitions.ContainsKey(from))
            _transitions[from] = new List<StateTransition>();
        _transitions[from].Add(new StateTransition(to, condition));
    } 

    public void Set(IState state)
    {
        if (state == _currentState)
            return;
        _currentState?.OnExit();
        _currentState = state;
        _currentState.OnEnter();
    }

    public void Tick()
    {
        StateTransition transition = CheckForTransition();
        if (transition != null)
            Set(transition.To);
        _currentState.Tick();
    }

    private StateTransition CheckForTransition()
    {
        if (_transitions.ContainsKey(_currentState))
            foreach (StateTransition transition in _transitions[_currentState])
                if (transition.Condition())
                    return transition;
        return null;
    }
}