using System;

namespace Kona.Model {
    
    public abstract class PaymentMethod {
        string Name { get; set; }
        string AccountNumber { get; set; }
        DateTime Expiration { get; set; }
        string VerificationCode { get; set; }
    }
}
