module PrivateConstructors
    type UnverifiedEmaiil = UnverifiedEmaiil of string

    type VerifiedEmail = private VerifiedMail of string

    let CheckEmail emailAddr = 
        let unveri = UnverifiedEmaiil emailAddr
        VerifiedMail emailAddr