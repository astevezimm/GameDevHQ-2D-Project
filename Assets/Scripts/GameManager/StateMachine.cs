using System;
using System.Collections.Generic;

public class StateMachine
{
    public IState CurrentState { get; private set; }

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
        if (state == CurrentState)
            return;
        CurrentState?.OnExit();
        CurrentState = state;
        CurrentState.OnEnter();
    }

    public void Tick()
    {
        StateTransition transition = CheckForTransition();
        if (transition != null)
            Set(transition.To);
        CurrentState.Tick();
    }

    private StateTransition CheckForTransition()
    {
        if (_transitions.ContainsKey(CurrentState))
            foreach (StateTransition transition in _transitions[CurrentState])
                if (transition.Condition())
                    return transition;
        return null;
    }
}