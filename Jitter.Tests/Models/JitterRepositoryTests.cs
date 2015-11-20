﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;


namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanCreateInstance()
        {
            JitterRepository repository = new JitterRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void JitterRepisitoryEnsureICanGetAllUsers()
        {
            //Arrange
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1" },
                new JitterUser { Handle = "rumbadancer2" }
            };
            Mock<JitterContext> mock_context = new Mock<JitterContext>();
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();

            mock_set.Object.AddRange(expected);

            //This is Stubbing the JitterUsers property getter
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
            JitterRepository repository = new JitterRepository(mock_context.Object);
            //Act
            var actual = repository.GetAllUsers();
            //Assert
            //Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            //Arrange
            JitterRepository repository = new JitterRepository();
            //Act
            var actual = repository.Context;
            //Assert
            Assert.IsNotInstanceOfType(actual, typeof(JitterContext)); 
        }



    }
}
