using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpeclowTutorial
{
    [Binding]
    public sealed class HomePageSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int a)
        {
            Console.WriteLine("a: " + a);
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Click to add button");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine(p0);
        }


    }
}
