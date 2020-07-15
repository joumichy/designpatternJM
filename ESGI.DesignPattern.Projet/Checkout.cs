using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Checkout
    {
        private readonly Product product;

        private readonly IEmailService emailService;

        private readonly UserConfirmation newsLetterSubscribed;

        private readonly UserConfirmation termsAndConditionsAccepted;

        public Checkout(Product product, IEmailService emailService)
        {
            this.product = product;
            this.emailService = emailService;
            this.newsLetterSubscribed = new UserConfirmation("Subscribe to our product " + product.Name + " newsletter?");
            this.termsAndConditionsAccepted = new UserConfirmation(
                "Accept our terms and conditions?\n" + //
                "(Mandatory to place order for " + product.Name + ")");
        }

        public virtual void ConfirmOrder()
        {
            if (!termsAndConditionsAccepted.Accepted)
            {
                throw new OrderCancelledException(product);
            }
            if (newsLetterSubscribed.Accepted)
            {
                emailService.SubscribeUserFor(product);
            }
        }

        public class CheckoutBuilder{
            private Product _product;
            private UserConfirmation _newsLetterSubscribed;
            private UserConfirmation _termsAndConditionsAccepted;

            private IEmailService _emailService;

            public CheckoutBuilder WithProduct(Product product){
                _product = product;
                return this;
            }

            public CheckoutBuilder WithNewsletterSubscribed(UserConfirmation newsLetterSubscribed ){
                _newsLetterSubscribed = newsLetterSubscribed;
                return this;
            }

            public CheckoutBuilder WithTermsAndConditionsAccepted(UserConfirmation termsAndConditionsAccepted){
                _termsAndConditionsAccepted = termsAndConditionsAccepted;
                return this;
            }

            public CheckoutBuilder WithIEmailService(IEmailService emailService){
                _emailService = emailService;
                return this;
            }
            public Checkout Build(){
                if (!_termsAndConditionsAccepted.Accepted) throw new OrderCancelledException(_product);
            
                return new Checkout(_product,_emailService);
            }
        }

    }
}
