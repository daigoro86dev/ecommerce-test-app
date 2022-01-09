using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBomber.Contracts;

namespace PerfTests.Scenarios
{
    public interface IScenarioFixture
    {
        Scenario SetupScenario(string name, params IStep[] steps);
    }
}