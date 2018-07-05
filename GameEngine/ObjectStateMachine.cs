using System;
using System.Collections.Generic;

namespace GameEngine
{
    class ObjectStateMachine : Componet
    {
		Dictionary<string, State> states = new Dictionary<string, State>;
		State currentState;

        public ObjectStateMachine()
        {
        }

        public void NewState(string name)
        {
			states.Add(name, new State(name));
        }
		
		public void RemoveState(string name)
		{
			states.Remove(name);
		}

        public void SwitchState(string name)
        {
			currentState = states[name];
        }

    }

    class State
    {
		string name;
		public State(string name)
		{
			this.name = name;
		}
		
    }
}
