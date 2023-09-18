using System.Reflection;
using Week2Day1_4.Managers;
using Week2Day1_4.Models;
using NUnit.Framework;
using Moq;
using System.Data;
using System.Data.SqlClient;

namespace TestProject
{
    public class Tests
    {
        private PlayerManager playerManager;
        private Mock<IDbConnection> mockConnection;
        private Mock<IDbCommand> mockCommand;
        //private Mock<DbDataAdapter> mockDataAdapter;

        [SetUp]
        public void Setup()
        {
            mockConnection = new Mock<IDbConnection>();
            mockCommand = new Mock<IDbCommand>();
            //mockDataAdapter = new Mock<DbDataAdapter>();

            // Configure the mock connection to return the mock command when creating a command.
            mockConnection.Setup(conn => conn.CreateCommand()).Returns(() => mockCommand.Object);

            // Configure the mock command to return the mock data adapter when creating a data adapter.
            //mockCommand.Setup(cmd => cmd.CreateDataAdapter()).Returns(() => mockDataAdapter.Object);

            playerManager = new PlayerManager();
        }



        [Test]
        public void Week2_Day1_Player_ClassExists()
        {
            string assemblyName = "Week2Day1_4";
            string typeName = "Week2Day1_4.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type rideType = assembly.GetType(typeName);
            Assert.IsNotNull(rideType);
            var ride = Activator.CreateInstance(rideType);
            Assert.IsNotNull(ride);
        }

        [Test]
        public void Week2_Day1_Player_Properties_Id_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "Week2Day1_4";
            string typeName = "Week2Day1_4.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Id");
            Assert.IsNotNull(propertyInfo, "The property 'ClassID' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'ClassID' property is not as expected (int).");
        }

        [Test]
        public void Week2_Day1_Player_Properties_Name_ReturnExpectedDataTypes_String()
        {
            string assemblyName = "Week2Day1_4";
            string typeName = "Week2Day1_4.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "The property 'ClassID' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'ClassID' property is not as expected (int).");
        }

        [Test]
        public void Week2_Day2_Player_Properties_BiddingPrice_ReturnExpectedDataTypes_Decimal()
        {
            string assemblyName = "Week2Day1_4";
            string typeName = "Week2Day1_4.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("BiddingPrice");
            Assert.IsNotNull(propertyInfo, "The property 'ClassID' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(decimal), propertyType, "The data type of 'ClassID' property is not as expected (int).");
        }

        [Test]
        public void Week2_Day2_PlayerManager_Should_have_AddPlayer()
        {
            // Arrange

            var playerManagerType = typeof(PlayerManager);
            var methodName = "AddPlayer";

            // Specify the parameter types for the DeletePlayer method
            var parameterTypes = new Type[] {  };

            // Act
            var deletePlayerMethod = playerManagerType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, null, parameterTypes, null);

            // Assert
            Assert.IsNotNull(deletePlayerMethod, $"Method '{methodName}' not found in PlayerManager class.");

        }
        [Test]
        public void Week2_Day3_PlayerManager_Should_Have_DeletePlayer_Method()
        {
            // Arrange
            var playerManagerType = typeof(PlayerManager);
            var methodName = "DeletePlayer";

            // Specify the parameter types for the DeletePlayer method
            var parameterTypes = new Type[] { typeof(int) };

            // Act
            var deletePlayerMethod = playerManagerType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, null, parameterTypes, null);

            // Assert
            Assert.IsNotNull(deletePlayerMethod, $"Method '{methodName}' not found in PlayerManager class.");
        }

        [Test]
        public void Week2_Day4_PlayerManager_Should_have_AddPlayerToDatabase()
        {
            // Arrange

            var playerManagerType = typeof(PlayerManager);
            var methodName = "AddPlayerToDatabase";

            // Specify the parameter types for the DeletePlayer method
            var parameterTypes = new Type[] { typeof(Player) };

            // Act
            var addPlayerToDatabaseMethod = playerManagerType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, null, parameterTypes, null);
            Console.WriteLine(addPlayerToDatabaseMethod);
            // Assert
            Assert.IsNotNull(addPlayerToDatabaseMethod, $"Method '{methodName}' not found in PlayerManager class.");
        }



        //**************//***

        //[Test]
        //public void TestAddPlayerToDatabase()
        //{
        //    PlayerManager playerManager = new PlayerManager();
        //    // Arrange
        //    Player playerToAdd = new Player
        //    {
        //        Name = "Test Player",
        //        Age = 25,
        //        Category = "Batsman",
        //        BiddingPrice = 500000m // Use a decimal value
        //    };

        //    // Act
        //    playerManager.AddPlayerToDatabase(playerToAdd);

        //    // Assert
        //    Assert.IsTrue(playerAdded, "Player should be added to the database successfully");
        //}

        
    }
}