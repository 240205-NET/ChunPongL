using Store.App;

namespace Store.App.Test
{
    public class UnitTest1
    {
        [Fact]
        public void foodtotalAmount()
        {
            //Arrange
            List<Foods> fList = new List<Foods>();
            Foods f1 = new Foods("Apple","CF",10.5,2);
            Foods f2 = new Foods("Orange","DF",11.5,3);
            fList.Add(f1);
            fList.Add(f2);
            double expected = 55.5;
            //Act
            var actual = PetStore.foodtotalAmount(fList);
            // Assert
            Assert.Equal(expected,actual);
        }
    }
}

