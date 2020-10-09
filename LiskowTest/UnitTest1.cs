using FluentAssertions;
using LiskovSubst;
using LiskovSubst.Covariance;
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using System;
using System.Globalization;

namespace LiskowTest
{
    [TestClass]
    public class UnitTest1
    {
        public readonly Size<float> ValidDimensions = new Size<float> { X = 2, Y = 4 };
        [TestMethod]
        public void ShippingRegionMustBeProvided()
        {
            var strategy = new  WorldWideShippingStrategy(12);
            //    mockDataAccess.Setup(m => m.CreateProduct(It.IsAny<Product>())).Returns(true);
            // var productBusiness = new ProductBusiness(mockDataAccess.Object);
            //   Moq<WorldWideShippingStrategy> strategy = new WorldWideShippingStrategy(12);
            strategy.Invoking(s =>
                 s.CalculateShippingCost(1f, new Size<float> { X = 2, Y = 4 }, null))
                .Should()
                .Throw<ArgumentNullException>("Destination must be provided")
                .And.ParamName.Should().Be("destination");
                
            //strategy.CalculateShippingCost(1f,new Size<float> { X=1, Y=2 },null).ShouldThrow
            
        }


        [TestMethod]
        public void ShippingDomesticallyIsFree()
        {
            var strategy = new WorldWideShippingStrategy(12);
            strategy.CalculateShippingCost(1f, ValidDimensions, RegionInfo.CurrentRegion)
                .Should().Be(decimal.Zero);


        }

        [TestMethod]
        public void ShippingCostMustBePositiveAndNonZero()
        {
            var strategy = new WorldWideShippingStrategy(12);
            strategy.CalculateShippingCost(1f, ValidDimensions, RegionInfo.CurrentRegion)
                .Should().BeGreaterThan(0m);


        }

        [TestMethod]
        public void ShippingFlatRateCanBeCHanged()
        {
            var strategy = new WorldWideShippingStrategy(12);
            strategy.FlatRate = decimal.MinusOne;
            strategy.FlatRate.Should().Be(decimal.MinusOne);

            strategy.CalculateShippingCost(1f, ValidDimensions, RegionInfo.CurrentRegion)
                .Should().BeGreaterThan(0m);


        }
        [TestMethod]
        public void UserCanBeComparedWithEntityComparer()
        {
            IEqualityComparer<User> entityComparer = new EntityEqualityComparer();


            var user1 = new User();
            var user2 = new User();
            entityComparer.Equals(user1, user2).Should().BeFalse();


        }
    }
}
