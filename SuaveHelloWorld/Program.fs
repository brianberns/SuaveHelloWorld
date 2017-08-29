open Suave

[<EntryPoint>]
let main argv = 
    let config = 
        let port = System.Environment.GetEnvironmentVariable("PORT")
        let ip127  = System.Net.IPAddress.Parse("127.0.0.1")
        let ipZero = System.Net.IPAddress.Parse("0.0.0.0")
        {
            defaultConfig with 
                bindings =
                    [
                        (if port = null then HttpBinding.create HTTP ip127 (uint16 8080)
                        else HttpBinding.create HTTP ipZero (uint16 port))
                    ]
        }
    startWebServer config (Successful.OK "Hello World!")
    0
