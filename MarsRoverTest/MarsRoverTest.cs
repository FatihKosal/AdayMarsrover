using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverTest
    {

        [TestMethod]
        public void ConfilictTest()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");

            var executer = new MarsRoverExecuter();

            executer.Command("5 5");
            executer.Command("1 2 N");
            executer.Command("LMLMLMLMM");

            var actualOutput = executer.GetLocation();

            executer.Command("5 5");
            executer.Command("1 2 N");
            executer.Command("LMLMLMLMM");

            var crashTest = executer.GetLocation();

            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }


        [TestMethod]
        public void Test_12N_LMLMLMLMM()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");

            var executer = new MarsRoverExecuter();

            executer.Command("5 5");
            executer.Command("1 2 N");
            executer.Command("LMLMLMLMM");

            var actualOutput = executer.GetLocation();

            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        


        [TestMethod]
        public void Test_33E_MRRMMRMRRM()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");

            var executer = new MarsRoverExecuter();

             executer.Execute(commandStringBuilder.ToString());

            var actualOutput = executer.GetLocation();
            var expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }


        [TestMethod]
        public void Test_66_32E_LMLM()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("6 6");
            commandStringBuilder.AppendLine("3 2 E");
            commandStringBuilder.Append("LMLM");

            var executer = new MarsRoverExecuter();

            executer.Execute(commandStringBuilder.ToString());

            var actualOutput = executer.GetLocation();
            var expectedOutput = "2 3 W";

            Assert.AreEqual(expectedOutput, actualOutput);
        }


    }
}
