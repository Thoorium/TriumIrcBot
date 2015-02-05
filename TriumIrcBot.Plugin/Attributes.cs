using System;

namespace TriumIrcBot.Plugin
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Command : Attribute
    {
        public Command(params string[] aCommand)
        {

        }
    }
}
