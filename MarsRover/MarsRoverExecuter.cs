using Autofac;
using MarsRover.Models.Rover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
   public class MarsRoverExecuter
    {
        private readonly ICommandInitializer commandInitializer;
        private readonly IRoverManager roverManager;

        public MarsRoverExecuter()
        {

            var programAssembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(programAssembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            using (var container = builder.Build())
            {
                commandInitializer = container.Resolve<ICommandInitializer>();
                roverManager = container.Resolve<IRoverManager>(); 
            }
        }

        public void Execute(string commandString)
        {
            commandInitializer.Execute(commandString);
        }
        public void Command(string command)
        {
            commandInitializer.Execute(command);
        }

        public string GetLocations()
        {
            string output = "";
            foreach (var rover in roverManager.GetAllRovers())
            {
                output += rover.Location() + "\n";

            }
            return output;
        }

        public string GetLocation()
        {
            return roverManager.GetActiveRover().Location();
        }
    }
}
