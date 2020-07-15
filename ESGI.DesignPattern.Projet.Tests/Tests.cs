using System;
using Xunit;



namespace ESGI.DesignPattern.Projet.Tests
{
    
    public class Tests
    {
        private readonly Product _product = new Product("phone");
        private UserConfirmation _termsAndCondition = new UserConfirmation("Acceptez vous ?");
    
      

        [Fact]
        public void isAProduct()
        {
            var result = _product;
            Assert.Equal("phone",_product.ToString());

        }

        [Fact]
        public void isOrderCancelled(){
           
           _termsAndCondition.Accepted = false;
            var result = _termsAndCondition.Accepted;
            
            var exception = new OrderCancelledException(_product);

            Assert.NotNull(exception);
            Assert.Contains(_product.ToString(), exception.ToString());

        }
        [Fact]
        public void Checkout()
        {
            
           //Checkout checkout = new Checkout(Prod);
        }
      

    }
    
    
}

