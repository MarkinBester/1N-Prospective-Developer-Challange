using System;

namespace Factory
{
    //Reduce tight coupling by implementing the Factory class using the
    //interface IFactory (Bonus)
    public class Factory : IFactory
    {
        //read only fields for safety, to make sure that the injected dependencies
        //can only be initialised in the constructor.
        private readonly RobotService _robotService;
        private readonly CarService _carService;
        private readonly PartsService _partsService;

        //Implement .net core dependency injection, when a dependency is requested in this class an
        //instance of that dependency will be injected.
        public Factory(RobotService robotService, CarService carService, PartsService partsService)
        {
            //With constructor injection it is not necessary to create a new instance of the
            //injected dependencies.
            _robotService = robotService;
            _carService = carService;
            _partsService = partsService;
            //To reduce tight coupling the above services should be implemented using Interfaces (Bonus).
        }

        public Robot BuildRobot(Enum robotType)
        {
            //Only necessary to initialise the parts once according to the robotType.
            var parts = _partsService.GetParts(robotType);

            //Instead of using an If statement I will use a switch expression
            return robotType switch
            {
                RobotType.RoboticDog => _robotService.BuildRobotDog(parts),
                RobotType.RoboticCat => _robotService.BuildRobotCat(parts),
                RobotType.RoboticDrone => _robotService.BuildRobotDrone(parts),
                RobotType.RoboticCar => _robotService.BuildRobotCar(parts),
                _ => null,
            };
        }

        public Car BuildCar(Enum carType)
        {
            //Only necessary to initialise the parts once according to the carType.
            var parts = _partsService.GetParts(carType);

            //If we have the parts for the specified carType we can build it. Not necessary to
            //call the same method multiple times.
            if (parts?.Count > 0)
                return _carService.BuildCar(parts);
            else
                return null;
        }
    }
}
