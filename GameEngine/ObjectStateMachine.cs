using System;

namespace GameEngine
{
    class ObjectStateMachine : Componet
    {
        State[] states;

        public ObjectStateMachine()
        {
        }

        public void NewState(string name)
        {

        }

        public void SwitchState(string name)
        {

        }

    }

    class State
    {
        private bool state;
        private string name;
    }
}
